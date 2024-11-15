using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Models;

[Table("Patients")]
public class Patient
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

    public Patient(string Name, string IdentificationNumber, string Email, string Password)
    {
        this.Name = Name;
        this.IdentificationNumber = IdentificationNumber;
        this.Email = Email;
        this.Password = Password;
    }

    public Patient() { }
}
