using BL.DTOs.AppointmentDTOs;
using BL.DTOs.DoctorDTOs;
using BL.DTOs.PatientDTOs;

namespace BL.Services.Interfaces;

public interface IDoctorService
{
    GetDoctorDTO Login(string email, string password);
    List<GetDoctorDTO> GetAll();
    GetDoctorDTO Add(UpsertDoctorDTO dto);
    GetDoctorDTO Put(int id, UpsertDoctorDTO dto);
    void Delete(int id);
}
