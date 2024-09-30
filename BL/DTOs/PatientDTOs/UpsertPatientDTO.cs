using BL.DTOs.AllergyDTOs;
using BL.DTOs.AppointmentDTOs;
using DL.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.PatientDTOs;

public class UpsertPatientDTO
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = String.Empty;
    public enGender enGender { get; set; }
    public string PhoneNumber { get; set; } = String.Empty;
    public string Email {  get; set; } = String.Empty;
    public string PasswordHash {  get; set; } = String.Empty;
}
