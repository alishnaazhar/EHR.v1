using Application.Models;
using BL.DTOs.PrescriptionDTOs;
using BL.Services.Implementations;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Authorize(Roles ="Doctor")]
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController : ControllerBase
    {
        private IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }
        [Authorize(Roles ="Patient")]
        [HttpGet("{id:int}")]
        public IActionResult Get(int id) =>
        Ok(new ResponseModel { Data = _prescriptionService.Get(id) });

        [HttpPost]
        public IActionResult Post(UpsertPrescriptionDTO request) =>
        Ok(new ResponseModel { Message = "Prescription added successfully.", Data = _prescriptionService.Post(request) });

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _prescriptionService.Delete(id);
            return Ok(new ResponseModel { Message = "Prescription deleted successfully." });
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpsertPrescriptionDTO request)
        => Ok(new ResponseModel { Message = "Prescription updated successfully.", Data = _prescriptionService.Put(id, request) });

    }
}
