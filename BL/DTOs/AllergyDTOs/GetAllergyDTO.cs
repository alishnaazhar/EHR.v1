using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.AllergyDTOs;

public class GetAllergyDTO : BaseEntityDTO
{
    public string AllergyName { get; set; } = String.Empty;
    public string Severity { get; set; } = String.Empty;
    public int PatientId {  get; set; }
}