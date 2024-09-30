using BL.DTOs.PatientDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services.Interfaces;

public interface IPatientService
{
    GetPatientDTO Login(string email, string password);
    GetPatientDTO Get(int id);
    GetPatientDTO Add(UpsertPatientDTO dto);
    GetPatientDTO Put(UpsertPatientDTO dto);
    void Delete(int id);

}
