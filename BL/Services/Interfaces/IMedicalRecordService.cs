using BL.DTOs.MedicalRecordDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IMedicalRecordService
{
    GetMedicalRecordDTO Get(int id);
    GetMedicalRecordDTO Post(UpsertMedicalRecordDTO dto);
    GetMedicalRecordDTO Put(int id, UpsertMedicalRecordDTO dto);
    void Delete(int id);

}
