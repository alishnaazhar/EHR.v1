using BL.DTOs.AppointmentDTOs;
using BL.DTOs.PrescriptionDTOs;
using DL;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public class AppointmentService : IAppointmentService
{
    private ApplicationDBContext _context;
    private IStateHelper _stateHelper;

    public AppointmentService(ApplicationDBContext context, IStateHelper stateHelper)
    {
        _context = context;
        _stateHelper = stateHelper;
    }

    public GetAppointmentDTO Get(int id)
    {
        var appointment = _context.Appointments.FirstOrDefault(_ => _.Id == id)
                            ?? throw new Exception("There is no such appointment found.");

        return new GetAppointmentDTO
        {
            AppointmentDate = appointment.AppointmentDate,
            Reason = appointment.Reason,
            PatientId = appointment.PatientId,
        };
    }

    public GetAppointmentDTO Post(AddAppointmentDTO dto)
    {
        var appointment = new Appointment
        {
            AppointmentDate = dto.AppointmentDate,
            Reason = dto.Reason,
            PatientId= _stateHelper.User().Id,
        };
        _context.Appointments.Add(appointment);
        _context.SaveChanges();
        return new GetAppointmentDTO
        {
            Id=appointment.Id,
            Reason= appointment.Reason,
            PatientId= appointment.PatientId,
            AppointmentDate= dto.AppointmentDate,
        };
    }
}
