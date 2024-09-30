using BL.DTOs.MedicationDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IMedicationService
{
    GetMedicationDTO Get(int id);
    GetMedicationDTO Post(UpsertMedicationDTO dto);
    GetMedicationDTO Put(int id, UpsertMedicationDTO dto);
    void Delete(int id);
}
    