using BL.DTOs.DoctorDTOs;
using BL.DTOs.PatientDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;
using Microsoft.EntityFrameworkCore;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementations;

public class DoctorService : IDoctorService
{
    private ApplicationDBContext _context;
    private IStateHelper _stateHelper;

    public DoctorService(ApplicationDBContext context, IStateHelper stateHelper)
    {
        _context = context;
        _stateHelper= stateHelper;
    }
    public GetDoctorDTO Login(string email, string password)
    {
        var doctor = _context.Doctors.FirstOrDefault(c => c.Email == email);
        if (doctor == null)
            throw new Exception("No doctor found.");
        else if (!SecurityHelper.ValidateHash(password, doctor.PasswordHash))
            throw new Exception("Invalid credentials.");
        return new GetDoctorDTO
        {
            Id = doctor.Id,
            Email = email,
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Specialty = doctor.Specialty,
            PhoneNumber = doctor.PhoneNumber,
        };
    }
        public void Delete(int id)
    {
        var doctor = _context.Doctors.FirstOrDefault(_ => _.Id == id);
        if (doctor == null)
            throw new Exception("There is no such Doctor found.");

        _context.Doctors.Remove(doctor);
        _context.SaveChanges();
    }

    public List<GetDoctorDTO> GetAll()
    {
        var Doctors = _context.Doctors.ToList();
        List<GetDoctorDTO> DoctorList = new List<GetDoctorDTO>();
        foreach (var doctor in Doctors)
        {
            var newDoctor = new GetDoctorDTO
            {
                Id = doctor.Id,
                FirstName = doctor.FirstName,
                LastName = doctor.LastName,
                Specialty = doctor.Specialty,
                PhoneNumber = doctor.PhoneNumber,
            };
            DoctorList.Add(newDoctor);
        }
        return DoctorList;
    }

    public GetDoctorDTO Add(UpsertDoctorDTO dto)
    {
        var doctor = new Doctor {Email=dto.Email, PasswordHash= SecurityHelper.GenerateHash(dto.Password), PhoneNumber = dto.PhoneNumber, Specialty = dto.Specialty, FirstName = dto.FirstName, LastName = dto.LastName };
        _context.Doctors.Add(doctor); _context.SaveChanges();
        
       
        return new GetDoctorDTO
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Specialty = doctor.Specialty,
            PhoneNumber = doctor.PhoneNumber,
            Id = doctor.Id,
        };
    }

    public GetDoctorDTO Put(int id, UpsertDoctorDTO dto)
    {
        var doctor = _context.Doctors.FirstOrDefault(_ => _.Id == id);
        if (doctor == null)
            throw new Exception("There is no such Doctor found.");

        return new GetDoctorDTO
        {
            FirstName = doctor.FirstName,
            LastName = doctor.LastName,
            Specialty = doctor.Specialty,
            PhoneNumber = doctor.PhoneNumber,
            Id = doctor.Id,
        };
    }
}
