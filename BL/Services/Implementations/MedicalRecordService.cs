using BL.DTOs.MedicalRecordDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementations;

public class MedicalRecordService : IMedicalRecordService
{
    private ApplicationDBContext _context;
    private IStateHelper _stateHelper;

    public MedicalRecordService(ApplicationDBContext context, IStateHelper stateHelper)
    {
        _context = context;
        _stateHelper= stateHelper;
    }
    public void Delete(int id)
    {
        var medicalRecord = _context.MedicalRecords.FirstOrDefault(_ => _.Id == id);
        if (medicalRecord == null)
            throw new Exception("There is no such medicalRecord found.");

        _context.MedicalRecords.Remove(medicalRecord);
        _context.SaveChanges();
    }

    public GetMedicalRecordDTO Get(int id)
    {
        var medicalRecord = _context.MedicalRecords.FirstOrDefault(_ => _.Id == id)
                   ?? throw new Exception("There is no such MedicalRecords found.");

        return new GetMedicalRecordDTO
        {
            Id = id,
            PatientId= medicalRecord.PatientId,
            Treatment= medicalRecord.Treatment,
            Diagnosis= medicalRecord.Diagnosis,
            RecordDate= medicalRecord.RecordDate,
        };
    }

    public GetMedicalRecordDTO Post(UpsertMedicalRecordDTO dto)
    {
        var medicalRecord = new MedicalRecord
        {
            Diagnosis= dto.Diagnosis,
            Treatment= dto.Treatment,
            PatientId= _stateHelper.User().Id,
        };
        _context.MedicalRecords.Add(medicalRecord);
        _context.SaveChanges();

        return new GetMedicalRecordDTO
        {
            Id=medicalRecord.Id,
            PatientId= medicalRecord.PatientId,
            Treatment= medicalRecord.Treatment,
            Diagnosis= medicalRecord.Diagnosis,
            RecordDate= DateTime.Now,
        };
    }

    public GetMedicalRecordDTO Put(int id, UpsertMedicalRecordDTO dto)
    {
        var medicalRecord = _context.MedicalRecords.FirstOrDefault(_ => _.Id == id);
        if (medicalRecord == null)
            throw new Exception("There is no such MedicalRecords found.");
        medicalRecord.Diagnosis = dto.Diagnosis;
        medicalRecord.Treatment = dto.Treatment;
        _context.SaveChanges();
        return new GetMedicalRecordDTO
        {
            Id=medicalRecord.Id,
            PatientId = medicalRecord.PatientId,
            Treatment = medicalRecord.Treatment,
            Diagnosis = medicalRecord.Diagnosis,
            RecordDate = DateTime.Now,
        };
    }
}
