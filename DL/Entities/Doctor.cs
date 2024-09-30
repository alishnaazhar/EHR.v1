using DL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class Doctor : BaseEntity
{
    public string Email { get; set; } = String.Empty; 
    public string PasswordHash { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Specialty { get; set; } = String.Empty;
    public string PhoneNumber { get; set; } = String.Empty; 


}
