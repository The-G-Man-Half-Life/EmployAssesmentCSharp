using System.ComponentModel.DataAnnotations;

public class AppointmentTypeDTO
{
    [Required]
    [StringLength(255)]  
    public string Name { get; set; }

    [Required]
    public string Description { get; set; } 
}
