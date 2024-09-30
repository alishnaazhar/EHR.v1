using Application.Models;
using BL.DTOs.CustomerDTOs;
using BL.DTOs.PatientDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Application.Controllers;
[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
    private IPatientService _patientService;
    private IConfiguration _config;

    public PatientController(IConfiguration config, IPatientService patientService)
    {
        _config = config;
        _patientService = patientService;
    }
    [HttpPost("register")]
    public IActionResult Register(UpsertPatientDTO request)
    {
        var patient = _patientService.Add(request);
        return Ok(new ResponseModel { Message = "Patient register successfully.", Data = patient });
    }
    [HttpPost("login")]
    public IActionResult Login(PatientLoginDTO request)
    => Ok(new ResponseModel { Data = CreateToken(_patientService.Login(request.Email, request.PasswordHash)) });
    private string CreateToken(GetPatientDTO patient)
    {
        List<Claim> claims = new List<Claim> {
        new Claim(ClaimTypes.NameIdentifier, patient.Email),
        new Claim(ClaimTypes.Name, patient.Email),
        new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(patient)),
        new Claim(ClaimTypes.Role, "Patient")
    };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _config.GetSection("JWT:SecretKey").Value!));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    [Authorize(Roles ="Patient")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _patientService.Delete(id);
        return Ok(new ResponseModel { Message = "patient deleted successfully." });
    }
    [Authorize(Roles ="Patient")]
    [HttpPut()]
    public IActionResult Put(UpsertPatientDTO request)
        => Ok(new ResponseModel { Message = "patient updated successfully.", Data = _patientService.Put(request) });
    [Authorize(Roles = "Doctor")]
    [HttpGet("{id:int}")]
    public IActionResult Get(int id) =>
        Ok(new ResponseModel { Data = _patientService.Get(id) });

}
