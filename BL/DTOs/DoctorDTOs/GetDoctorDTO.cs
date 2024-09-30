using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.DoctorDTOs;

public class GetDoctorDTO : BaseEntityDTO
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string Specialty { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty;
}
