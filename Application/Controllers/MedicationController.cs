using Application.Models;
using BL.DTOs.MedicalRecordDTOs;
using BL.DTOs.MedicationDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers;

[Authorize(Roles ="Doctor")]
[Route("api/[controller]")]
[ApiController]
public class MedicationController : ControllerBase
{
    private IMedicationService _medicationService;

    public MedicationController(IMedicationService medication)
    {
        _medicationService = medication;
    }
    [Authorize(Roles ="Patient")]
    [HttpGet("{id:int}")]
    public IActionResult Get(int id) =>
        Ok(new ResponseModel { Data = _medicationService.Get(id) });


    [HttpPost]
    public IActionResult Post(UpsertMedicationDTO request) =>
        Ok(new ResponseModel { Message = "Medication added successfully.", Data = _medicationService.Post(request) });

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _medicationService.Delete(id);
        return Ok(new ResponseModel { Message = "Medication deleted successfully." });
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, UpsertMedicationDTO request)
        => Ok(new ResponseModel { Message = "Medication updated successfully.", Data = _medicationService.Put(id, request) });

}
