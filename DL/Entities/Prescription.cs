using DL.Entities.Base;

namespace DL.Entities;

public class Prescription : BaseEntity
{
    public int PatientId { get; set; }
    public DateTime PrescriptionDate { get; set; }
    public string Medicine { get; set; } = String.Empty;
    public string Instructions { get; set; } = String.Empty;    
}
