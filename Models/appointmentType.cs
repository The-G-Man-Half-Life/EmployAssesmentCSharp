using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployAssesmentCSharp.Models;

[Table("AppointmentType")]
public class AppointmentType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string Name { get; set; }

    [Column("description")]
    public string Description { get; set; }

    public AppointmentType(string Name, string Description)
    {
        this.Name = Name;
        this.Description = Description;
    }

    public AppointmentType() { }
}