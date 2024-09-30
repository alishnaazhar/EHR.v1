﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.DTOs.PrescriptionDTOs;

public class GetPrescriptionDTO: BaseEntityDTO
{
    public DateTime PrescriptionDate { get; set; }
    public string Medicine { get; set; } = String.Empty;
    public string Instructions { get; set; } = String.Empty;
    public int PatientId { get; set; }
}
