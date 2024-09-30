using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.CustomerDTOs;

public class PatientLoginDTO
{
    //[Required(ErrorMessage = "The email is required.")]
    //[EmailAddress]
    public string Email { get; set; }= String.Empty;

    //[Required]
    //[MinLength(8, ErrorMessage = "The minimum length of passsword should be atleast 8.")]
    public string PasswordHash { get; set; } = String.Empty;
}
