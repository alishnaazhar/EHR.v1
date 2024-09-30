using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.AppointmentDTOs;

public class AddAppointmentDTO
{
    public DateTime AppointmentDate { get; set; }
    public string Reason { get; set; } = String.Empty;
}
