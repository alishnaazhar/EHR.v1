using BL.DTOs.MedicationDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Implementations;

public class MedicationService : IMedicationService
{
    private ApplicationDBContext _context;
    public MedicationService(ApplicationDBContext context)
    {
        _context = context;
    }

    public void Delete(int id)
    {
        var medication = _context.Medications.FirstOrDefault(_ => _.Id == id);
        if (medication == null)
            throw new Exception("There is no such Medications found.");

        _context.Medications.Remove(medication);
        _context.SaveChanges();
    }

    public GetMedicationDTO Get(int id)
    {

        var medication = _context.Medications.FirstOrDefault(_ => _.Id == id)
                    ?? throw new Exception("There is no such Medications found.");
        return new GetMedicationDTO { Id = medication.Id, Dosage = medication.Dosage, Name = medication.Name };
    }

    public GetMedicationDTO Post(UpsertMedicationDTO dto)
    {
        var medication = new Medication
        {
            Name = dto.Name,
            Dosage = dto.Dosage,
        };
        _context.Medications.Add(medication);
        _context.SaveChanges();
        return new GetMedicationDTO { Dosage = medication.Dosage, Name = medication.Name, Id = medication.Id };
    }

    public GetMedicationDTO Put(int id, UpsertMedicationDTO dto)
    {
        var medication = _context.Medications.FirstOrDefault(_ => _.Id == id);
        if (medication == null)
            throw new Exception("There is no such Medications found.");
        medication.Name = dto.Name;
        medication.Dosage = dto.Dosage;
        _context.SaveChanges();
        return new GetMedicationDTO { Name = dto.Name, Dosage = dto.Dosage, Id = medication.Id };
    }
}
