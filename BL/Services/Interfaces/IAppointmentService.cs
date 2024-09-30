using BL.DTOs.AppointmentDTOs;
using BL.DTOs.PrescriptionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IAppointmentService
{
    GetAppointmentDTO Get(int id); // get by doctor
    GetAppointmentDTO Post(AddAppointmentDTO dto); // appointment added by patient
}
