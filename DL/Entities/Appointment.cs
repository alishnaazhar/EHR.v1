using DL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL.Entities;

public class Appointment : BaseEntity
{
    [ForeignKey("Patient")]
    public int PatientId { get; set; }
    public Patient Patient { get; set; }
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; } = String.Empty;
}
