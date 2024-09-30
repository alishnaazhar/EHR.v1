using BL.DTOs.AllergyDTOs;
using BL.Services.Interfaces;
using DL;
using DL.Entities;

namespace BL.Services.Implementations;

public class AllergyService : IAllergyService
{
    private ApplicationDBContext _context;
    private IStateHelper _stateHelper;

    public AllergyService(ApplicationDBContext context, IStateHelper stateHelper)
    {
        _context = context;
        _stateHelper = stateHelper;
    }
    public void Delete(int id)
    {
        var allergy = _context.Allergies.FirstOrDefault(_ => _.Id == id);
        if (allergy == null)
            throw new Exception("There is no such allergy found.");

        _context.Allergies.Remove(allergy);
        _context.SaveChanges();
    }

    public List<GetAllergyDTO> GetAll()
    {
        var Allergies = _context.Allergies.ToList();
        List<GetAllergyDTO> AllergyList = new List<GetAllergyDTO>();
        foreach (var allergy in Allergies)
        {
            var newAllergy = new GetAllergyDTO()
            {
                PatientId = allergy.PatientId,
                Id = allergy.Id,
                AllergyName = allergy.AllergyName,
                Severity = allergy.Severity,
            };
            AllergyList.Add(newAllergy);
        }
        return AllergyList;
    }

    public GetAllergyDTO Post(UpsertAllergyDTO dto)
    {
        var allergy = new Allergy
        {
            AllergyName = dto.AllergyName,
            Severity = dto.Severity,
            PatientId = _stateHelper.User().Id
        };
        _context.Allergies.Add(allergy);
        _context.SaveChanges();
        return new GetAllergyDTO {PatientId= allergy.PatientId, Id = allergy.Id, AllergyName = dto.AllergyName, Severity = dto.Severity, };
    }

    public GetAllergyDTO Put(int id,UpsertAllergyDTO dto) 
    {
        var allergy = _context.Allergies.FirstOrDefault(_ => _.Id == id);
        if (allergy == null)
            throw new Exception("There is no such allergy found.");
        allergy.AllergyName = dto.AllergyName;
        allergy.Severity = dto.Severity;
        _context.SaveChanges();
        return new GetAllergyDTO {PatientId= allergy.PatientId, Id = allergy.Id, AllergyName = allergy.AllergyName, Severity = allergy.Severity };
    }
}
