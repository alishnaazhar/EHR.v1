using BL.DTOs.AllergyDTOs;

namespace BL.Services.Interfaces;

public interface IAllergyService
{
    List<GetAllergyDTO> GetAll();
    GetAllergyDTO Post(UpsertAllergyDTO dto);
    GetAllergyDTO Put(int id, UpsertAllergyDTO dto);
    void Delete(int id);
}
