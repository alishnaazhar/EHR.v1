namespace BL.DTOs.MedicalRecordDTOs;

public class GetMedicalRecordDTO: BaseEntityDTO
{
    public int PatientId { get; set; }
    public DateTime RecordDate { get; set; }
    public string Diagnosis { get; set; } = String.Empty;
    public string Treatment { get; set; } = String.Empty;
}
