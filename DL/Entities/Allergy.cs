using DL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class Allergy : BaseEntity
{
    public int PatientId { get; set; }
    public string AllergyName { get; set; } = String.Empty;
    public string Severity { get; set; } = String.Empty;
    public Patient Patient { get; set; }
}
