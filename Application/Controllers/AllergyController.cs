using Application.Models;
using BL.DTOs.AllergyDTOs;
using BL.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyController : ControllerBase
    {
        private IAllergyService _allergyService;

        public AllergyController(IAllergyService productService)
        {
            _allergyService = productService;
        }
        [Authorize(Roles = "Doctor, Patient")]
        [HttpGet]
        public IActionResult Get() =>
        Ok(new ResponseModel { Data = _allergyService.GetAll() });
        [Authorize(Roles = "Patient")]
        [HttpPost]
        public IActionResult Post(UpsertAllergyDTO request) =>
        Ok(new ResponseModel { Message = "Product added successfully.", Data = _allergyService.Post(request) });
        [Authorize(Roles = "Doctor")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _allergyService.Delete(id);
            return Ok(new ResponseModel { Message = "Product deleted successfully." });
        }
        [Authorize(Roles = "Patient")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, UpsertAllergyDTO request)
            => Ok(new ResponseModel { Message = "Product updated successfully.", Data = _allergyService.Put(id, request) });

    }
}
