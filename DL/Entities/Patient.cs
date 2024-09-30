using DL.Entities.Base;
using DL.Enumerations;

namespace DL.Entities;

public class Patient : BaseEntity
{
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Email { get; set; } = String.Empty;
    public string PasswordHash { get; set; } = String.Empty;
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; } = String.Empty;
    public enGender enGender { get; set; }
    public string PhoneNumber { get; set; } = String.Empty;
    public List<Appointment> Appointments { get; set; }
    public List<MedicalRecord> MedicalRecords { get; set; }
    public List<Allergy> Allergies { get; set; }
    public List<Prescription> Prescriptions { get; set; }
}
