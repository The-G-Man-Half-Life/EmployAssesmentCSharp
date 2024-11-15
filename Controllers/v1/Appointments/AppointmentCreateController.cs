using CSharpTest.Models;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/Appointments/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Appointment Management")]
    public class AppointmentCreateController : AppointmentController
    {
        private readonly AppointmentServices AppointmentServices;
        private readonly DiseasServices DiseasServices;
        private readonly AppointmentTypeServices AppointmentTypeServices;
        private readonly PatientServices PatientServices;
        private readonly DoctorServices DoctorServices;

        public AppointmentCreateController(AppointmentServices AppointmentServices,DiseasServices DiseasServices,AppointmentTypeServices AppointmentTypeServices,PatientServices PatientServices,DoctorServices DoctorServices):base(AppointmentServices)
        {
            this.AppointmentServices = AppointmentServices;
            this.DiseasServices = DiseasServices;
            this.AppointmentTypeServices = AppointmentTypeServices;
            this.PatientServices = PatientServices;
            this.DoctorServices = DoctorServices;            
        }

        /// <summary>
        /// Creates a new Appointment.
        /// </summary>
        /// <param name="AppointmentDTO">The DTO containing the details of the Appointment to be created.</param>
        /// <returns>Returns the newly created Appointment object.</returns>
        /// <response code="200">The Appointment was created successfully.</response>
        /// <response code="400">The input model is null or invalid.</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new Appointment",
            Description = "Allows users to create a new Appointment by providing the required details."
        )]
        [SwaggerResponse(200, "Appointment created successfully.")]
        [SwaggerResponse(400, "The input model is null or invalid.")]
        public async Task<IActionResult> CreateNewAppointment([FromBody] AppointmentDTO AppointmentDTO)
        {
            var diseasInrange =await  DiseasServices.CheckExistence(AppointmentDTO.DiseasId);
            var appointmentInrange =await  AppointmentTypeServices.CheckExistence(AppointmentDTO.AppointmentTypeId);
            var patientInrange =await  PatientServices.CheckExistence(AppointmentDTO.PatientId);
            var doctorInrange =await  DoctorServices.CheckExistence(AppointmentDTO.DoctorId);

            var AllAppointments =await AppointmentServices.GetAll();
            var AllAppointmentsWithADoctor = AllAppointments.Where(a=>a.DoctorId == AppointmentDTO.DoctorId);
            bool AnyDateInThatTime = AllAppointmentsWithADoctor.Any(a =>
            a.StartTime < AppointmentDTO.EndTime && a.EndTime > AppointmentDTO.StartTime);
            
            if (AppointmentDTO == null)
            {
                return BadRequest("The input model cannot be null.");
            }

            else if (ModelState.IsValid == false)
            {
                return BadRequest("The input model is invalid.");
            }
            else if(diseasInrange == false)
            {
                return BadRequest("The diseas does not exist");   
            }
            else if(appointmentInrange == false)
            {
                return BadRequest("The appointment does not exist");   
            }
            else if(patientInrange == false)
            {
                return BadRequest("The patient does not exist");   
            }            
            else if(doctorInrange == false)
            {
                return BadRequest("The doctor does not exist");   
            }
            else if(AnyDateInThatTime == true)
            {
                return BadRequest("there is another date in that time already");
            }

            var newAppointment = new Models.Appointment(
                AppointmentDTO.StartTime,
                AppointmentDTO.EndTime,
                AppointmentDTO.Reason,
                AppointmentDTO.DiseasId,
                AppointmentDTO.AppointmentTypeId,
                AppointmentDTO.PatientId,
                AppointmentDTO.DoctorId                
            );

            await AppointmentServices.Add(newAppointment);
            return Ok(newAppointment);
        }
    }
}
