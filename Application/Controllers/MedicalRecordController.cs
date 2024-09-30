using Application.Models;
using BL.DTOs.MedicalRecordDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Doctor")]
    [ApiController]
    public class MedicalRecordController : ControllerBase
    {
        private IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecord)
        {
            _medicalRecordService = medicalRecord;
        }
        [Authorize(Roles = "Patient")]
        [HttpGet("{id:int}")]
        public IActionResult Get(int id) =>
            Ok(new ResponseModel { Data = _medicalRecordService.Get(id) });

        [HttpPost]
        public IActionResult Post(UpsertMedicalRecordDTO request) =>
            Ok(new ResponseModel { Message = "MedicalRecord added successfully.", Data = _medicalRecordService.Post(request) });

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _medicalRecordService.Delete(id);
            return Ok(new ResponseModel { Message = "MedicalRecord deleted successfully." });
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpsertMedicalRecordDTO request)
            => Ok(new ResponseModel { Message = "Product updated successfully.", Data = _medicalRecordService.Put(id, request) });

    }
}
