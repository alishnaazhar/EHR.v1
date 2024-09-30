using DL.Entities.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class MedicalRecord: BaseEntity
{
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime RecordDate { get; set; }
    public string Diagnosis { get; set; } = String.Empty;
    public string Treatment { get; set; } = String.Empty;
}
