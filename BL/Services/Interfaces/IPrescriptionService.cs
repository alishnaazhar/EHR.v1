using BL.DTOs.PrescriptionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IPrescriptionService
{
    GetPrescriptionDTO Get(int id);
    GetPrescriptionDTO Post(UpsertPrescriptionDTO dto);
    GetPrescriptionDTO Put(int id, UpsertPrescriptionDTO dto);
    void Delete(int id);
}
