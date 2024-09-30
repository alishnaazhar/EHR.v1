using BL.DTOs.PrescriptionDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementations;

public class PrescriptiontService : IPrescriptionService
{
    private ApplicationDBContext _context;
    public PrescriptiontService(ApplicationDBContext context)
    {
        _context = context;
    }

    public void Delete(int id)
    {
        var prescription = _context.Prescriptions.FirstOrDefault(_ => _.Id == id);
        if (prescription == null)
            throw new Exception("There is no such prescription found.");

        _context.Prescriptions.Remove(prescription);
        _context.SaveChanges();
    }

    public GetPrescriptionDTO Get(int id)
    {
        var prescription = _context.Prescriptions.FirstOrDefault(_ => _.Id == id)
                            ?? throw new Exception("There is no such prescription found.");

        return new GetPrescriptionDTO
        {
            PatientId = prescription.PatientId,
            PrescriptionDate = prescription.PrescriptionDate,
            Medicine = prescription.Medicine,
            Instructions = prescription.Instructions,
        };
    }

    public GetPrescriptionDTO Post(UpsertPrescriptionDTO dto)
    {
        var prescription = new Prescription {PatientId=dto.PatientId, Instructions = dto.Instructions, Medicine = dto.Medicine };
        _context.Prescriptions.Add(prescription);
        _context.SaveChanges();
        return new GetPrescriptionDTO
        {
            Id=prescription.Id,
            PatientId=prescription.PatientId,
            Medicine=prescription.Medicine,
            Instructions=prescription.Instructions,
            PrescriptionDate=DateTime.Now,
        };
    }

    public GetPrescriptionDTO Put(int id, UpsertPrescriptionDTO dto)
    {
        var prescription = _context.Prescriptions.FirstOrDefault(_ => _.Id == id);
        if (prescription == null)
            throw new Exception("There is no such prescription found.");
        prescription.Instructions = dto.Instructions;
        prescription.Medicine = dto.Medicine;
        prescription.Instructions=dto.Instructions;
        _context.SaveChanges();

        return new GetPrescriptionDTO {

            Id = prescription.Id,
            PatientId=prescription.PatientId,
            Medicine = prescription.Medicine,
            Instructions = prescription.Instructions,
            PrescriptionDate = DateTime.Now,
        };
    }
}
