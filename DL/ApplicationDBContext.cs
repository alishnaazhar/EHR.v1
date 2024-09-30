using DL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DL;

public class ApplicationDBContext : DbContext
{
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Allergy> Allergies { get; set; }
    public DbSet<Medication> Medications { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<MedicalRecord> MedicalRecords { get; set; }
}
