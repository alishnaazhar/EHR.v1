using BL.DTOs.AppointmentDTOs;
using DL.Entities;

namespace BL.DTOs.DoctorDTOs;

public class UpsertDoctorDTO
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Specialty { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
    public string Email { get; set; }= String.Empty;
    public string Password {  get; set; } = String.Empty;
}
