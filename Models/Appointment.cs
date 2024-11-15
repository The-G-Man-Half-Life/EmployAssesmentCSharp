using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmployAssesmentCSharp.Models;

namespace EmployAssesmentCSharp.Models;

[Table("Appointments")]
public class Appointment
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id {get; set;}

    [Column("start_time")]
    public DateTime StartTime {get; set;}
        
    [Column("end_time")]
    public DateTime EndTime {get; set;}

    [Column("reason")]
    public string Reason {get; set;}


    [Column("diseas_id")]
    public int DiseasId {get; set;}

    [ForeignKey(nameof(DiseasId))]
    public Diseas? Diseas {get; set;}


    [Column("appointment_type_id")]
    public int AppointmentTypeId {get; set;}

    [ForeignKey(nameof(AppointmentTypeId))]
    public AppointmentType? AppointmentType {get; set;}


    [Column("patient_id")]
    public int PatientId {get; set;}

    [ForeignKey(nameof(PatientId))]
    public Patient? Patient {get; set;}


    [Column("doctor_id")]
    public int DoctorId {get; set;}

    [ForeignKey(nameof(DoctorId))]
    public Doctor? Doctor {get; set;}


    public Appointment(DateTime StartTime,DateTime EndTime,string Reason,int DiseasId,int AppointmentTypeId,int PatientId,int DoctorId)
    {
        this.StartTime = StartTime;
        this.EndTime = EndTime;
        this.Reason = Reason;
        this.DiseasId = DiseasId;
        this.AppointmentTypeId = AppointmentTypeId;
        this.PatientId = PatientId;
        this.DoctorId = DoctorId;
    }
    public Appointment() {}
}