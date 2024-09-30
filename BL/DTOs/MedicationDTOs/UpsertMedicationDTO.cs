using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.MedicationDTOs;

public class UpsertMedicationDTO
{
    public string Name { get; set; } = String.Empty;
    public string Dosage { get; set; } = String.Empty;
}
