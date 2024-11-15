using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Models;

[Table("Doctors")]
public class Doctor
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("identification_number")]
    public string IdentificationNumber { get; set; }

    [Column("email")]
    public string Email { get; set; }

    [Column("password")]
    public string Password { get; set; }

    [Column("specialty")]
    public string Specialty { get; set; }

    [Column("start_time", TypeName = "time")]
    public TimeSpan StartTime { get; set; }

    [Column("end_time", TypeName = "time")]
    public TimeSpan EndTime { get; set; }

    public Doctor(string Name, string IdentificationNumber, string Email, string Password, string Specialty, TimeSpan StartTime, TimeSpan EndTime)
    {
        this.Name = Name;
        this.IdentificationNumber = IdentificationNumber;
        this.Email = Email;
        this.Password = Password;
        this.Specialty = Specialty;
        this.StartTime = StartTime;
        this.EndTime = EndTime;
    }

    public Doctor() { }
}
