using Application.Models;
using BL.DTOs.CustomerDTOs;
using BL.DTOs.DoctorDTOs;
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
public class DoctorController : ControllerBase
{
    private IDoctorService _doctorService;
    private IConfiguration _config;


    public DoctorController(IConfiguration config, IDoctorService doctorService)
    {
        _doctorService = doctorService;
        _config = config;
    }
    [HttpPost("register")]
    public IActionResult Register(UpsertDoctorDTO request)
    {
        var doctor = _doctorService.Add(request);
        return Ok(new ResponseModel { Message = "doctor register successfully.", Data = doctor });
    }

    [HttpPost("login")]
    public IActionResult Login(DoctorLoginDTO request)
=> Ok(new ResponseModel { Data = CreateToken(_doctorService.Login(request.Email, request.Password)) });
    private string CreateToken(GetDoctorDTO doctor)
    {
        List<Claim> claims = new List<Claim> {
    new Claim(ClaimTypes.NameIdentifier, doctor.Email),
    new Claim(ClaimTypes.Name, doctor.Email),
    new Claim(ClaimTypes.UserData, JsonSerializer.Serialize(doctor)),
    new Claim(ClaimTypes.Role, "Doctor")
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
    [HttpGet]
    public IActionResult Get() =>
    Ok(new ResponseModel { Data = _doctorService.GetAll() });

    [Authorize(Roles ="Doctor")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _doctorService.Delete(id);
        return Ok(new ResponseModel { Message = "Doctor deleted successfully." });
    }
    [Authorize(Roles ="Doctor")]
    [HttpPut("{id}")]
    public IActionResult Put(int id, UpsertDoctorDTO request)
        => Ok(new ResponseModel { Message = "Doctor updated successfully.", Data = _doctorService.Put(id, request) });

}
