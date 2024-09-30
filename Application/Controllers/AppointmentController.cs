using Application.Models;
using BL.DTOs.AppointmentDTOs;
using BL.DTOs.PrescriptionDTOs;
using BL.Services.Implementations;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
       
        [Authorize(Roles = "Doctor")]
        [HttpGet("{id:int}")]
        public IActionResult Get(int id) =>
        Ok(new ResponseModel { Data = _appointmentService.Get(id) });
      
        
        [Authorize(Roles = "Patient")]
        [HttpPost]
        public IActionResult Post(AddAppointmentDTO request) =>
       Ok(new ResponseModel { Message = "Appointment added successfully.", Data = _appointmentService.Post(request) });

    }
}
