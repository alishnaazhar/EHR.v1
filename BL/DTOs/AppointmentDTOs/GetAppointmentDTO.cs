using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.AppointmentDTOs;

public class GetAppointmentDTO : BaseEntityDTO
{
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; } = String.Empty;
    public int PatientId { get; set; }
}
