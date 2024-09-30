using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.MedicalRecordDTOs;

public class UpsertMedicalRecordDTO
{
   
    public string Diagnosis { get; set; } = String.Empty;
    public string Treatment { get; set; } = String.Empty;
}
