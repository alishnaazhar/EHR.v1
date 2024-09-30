using BL.DTOs.MedicationDTOs;
using BL.DTOs.PatientDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;
using Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementations;

public class PatientService : IPatientService
{
    private IStateHelper _stateHelper;
    private ApplicationDBContext _context;
    public PatientService(ApplicationDBContext context, IStateHelper stateHelper)
    {
        _stateHelper = stateHelper;
        _context = context;
    }
    public void Delete(int id)
    {
        var patient = _context.Patients.FirstOrDefault(_ => _.Id == id);
        if (patient == null)
            throw new Exception("There is no such patient found.");

        _context.Patients.Remove(patient);
        _context.SaveChanges();
    }

    public GetPatientDTO Get(int id)
    {
        var patient = _context.Patients.FirstOrDefault(_ => _.Id == id)
                            ?? throw new Exception("There is no such Patient found.");
        return new GetPatientDTO { FirstName = patient.FirstName, LastName = patient.LastName, DateOfBirth = patient.DateOfBirth, Address = patient.Address, enGender = patient.enGender, PhoneNumber = patient.PhoneNumber, Allergies = patient.Allergies, Appointments = patient.Appointments, MedicalRecords = patient.MedicalRecords, Prescriptions = patient.Prescriptions };
    }

    public GetPatientDTO Login(string email, string password)
    {
        var patient = _context.Patients.FirstOrDefault(c => c.Email == email);
        if (patient == null)
            throw new Exception("No patient found.");
        else if (!SecurityHelper.ValidateHash(password, patient.PasswordHash))
            throw new Exception("Invalid credentials.");
        return new GetPatientDTO
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            PhoneNumber = patient.PhoneNumber,
            enGender = patient.enGender,
            DateOfBirth = patient.DateOfBirth,
            Address = patient.Address,
            Appointments = patient.Appointments,
            Allergies = patient.Allergies,
            MedicalRecords = patient.MedicalRecords,
            Prescriptions = patient.Prescriptions
        };
    }

    public GetPatientDTO Add(UpsertPatientDTO dto)
    {
        var patient = new Patient
        {
            Email = dto.Email,
            PasswordHash= SecurityHelper.GenerateHash(dto.PasswordHash),
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            PhoneNumber = dto.PhoneNumber,
            enGender = dto.enGender,
            DateOfBirth = dto.DateOfBirth,
            Address = dto.Address,
        };
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return new GetPatientDTO
        {
            Id=patient.Id,
            Email = patient.Email,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            PhoneNumber = patient.PhoneNumber,
            Address = patient.Address,
            enGender = patient.enGender,
            DateOfBirth = dto.DateOfBirth,
            Allergies = patient.Allergies,
            MedicalRecords = patient.MedicalRecords,
            Prescriptions = patient.Prescriptions,
            Appointments = patient.Appointments
        };
    }

    public GetPatientDTO Put(UpsertPatientDTO dto)
    {
        int id = _stateHelper.User().Id;
        var patient = _context.Patients.FirstOrDefault(_ => _.Id == id);
        if (patient == null)
            throw new Exception("There is no such Patients found.");
        patient.FirstName = dto.FirstName;
        patient.LastName = dto.LastName;
        patient.Email = dto.Email;
        patient.PasswordHash = dto.PasswordHash;
        patient.PhoneNumber = dto.PhoneNumber;
        patient.DateOfBirth = dto.DateOfBirth;
        patient.Address = dto.Address;
        patient.enGender = dto.enGender;
        _context.Patients.Add(patient);
        _context.SaveChanges();
        return new GetPatientDTO
        {
            Id = patient.Id,
            Email = patient.Email,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            PhoneNumber = patient.PhoneNumber,
            Address = patient.Address,
            enGender = patient.enGender,
            DateOfBirth = dto.DateOfBirth,
            Allergies = patient.Allergies,
            MedicalRecords = patient.MedicalRecords,
            Prescriptions = patient.Prescriptions,
            Appointments = patient.Appointments

        };
    }
}
