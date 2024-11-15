using CSharpTest.Models;
using CSharpTest.Seeders;
using EmployAssesmentCSharp.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Data;
public class ApplicationDbContext:DbContext
{
    public DbSet<Diseas> Diseases {get; set;}
    public DbSet<Doctor> Doctors {get; set;}
    public DbSet<AppointmentType> AppointmentTypes {get; set;}
    public DbSet<Patient> Patients {get; set;}
    public DbSet<Appointment> Appointments {get; set;}
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        DoctorSeeder.Seed(modelBuilder);
        PatientSeeder.Seed(modelBuilder);
        DiseasSeeder.Seed(modelBuilder);
        AppointmentTypeSeeder.Seed(modelBuilder);
        AppointmentSeeder.Seed(modelBuilder);

    }
}