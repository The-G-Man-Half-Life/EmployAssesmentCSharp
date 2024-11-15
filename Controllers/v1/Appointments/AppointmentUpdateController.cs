using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;
using CSharpTest.Models;

namespace EmployAssesmentCSharp.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/Appointments/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Appointment Management")]
    public class AppointmentUpdateController : AppointmentController
    {
        private readonly AppointmentServices AppointmentServices;
        private readonly DiseasServices DiseasServices;
        private readonly AppointmentTypeServices AppointmentTypeServices;
        private readonly PatientServices PatientServices;
        private readonly DoctorServices DoctorServices;

        public AppointmentUpdateController(AppointmentServices AppointmentServices,DiseasServices DiseasServices,AppointmentTypeServices AppointmentTypeServices,PatientServices PatientServices,DoctorServices DoctorServices):base(AppointmentServices)
        {
            this.AppointmentServices = AppointmentServices;
            this.DiseasServices = DiseasServices;
            this.AppointmentTypeServices = AppointmentTypeServices;
            this.PatientServices = PatientServices;
            this.DoctorServices = DoctorServices;            
        }

        /// <summary>
        /// Updates an existing Appointment.
        /// </summary>
        /// <param name="id">The ID of the Appointment to update.</param>
        /// <param name="AppointmentDTO">The DTO containing the updated Appointment data.</param>
        /// <returns>A success or error message.</returns>
        /// <response code="200">The Appointment was successfully updated.</response>
        /// <response code="400">The input model is invalid or contains errors.</response>
        /// <response code="404">No Appointment was found with the provided ID.</response>
        /// <response code="500">An error occurred during the update process.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing Appointment",
            Description = "Allows updating an existing Appointment by providing its ID and updated data."
        )]
        [SwaggerResponse(200, "The Appointment was successfully updated.")]
        [SwaggerResponse(400, "The input model is invalid or contains errors.")]
        [SwaggerResponse(404, "No Appointment was found with the provided ID.")]
        [SwaggerResponse(500, "An error occurred during the update process.")]
        public async Task<ActionResult> UpdateAppointment([FromRoute] int id, [FromBody] AppointmentDTO AppointmentDTO)
        {
            var diseasInrange =await  DiseasServices.CheckExistence(AppointmentDTO.DiseasId);
            var appointmentInrange =await  AppointmentTypeServices.CheckExistence(AppointmentDTO.AppointmentTypeId);
            var patientInrange =await  PatientServices.CheckExistence(AppointmentDTO.PatientId);
            var doctorInrange =await  DoctorServices.CheckExistence(AppointmentDTO.DoctorId);

            var AllAppointments =await AppointmentServices.GetAll();
            var AllAppointmentsWithADoctor = AllAppointments.Where(a=>a.DoctorId == AppointmentDTO.DoctorId);
            bool AnyDateInThatTime = AllAppointmentsWithADoctor.Any(a =>
            a.StartTime < AppointmentDTO.EndTime && a.EndTime > AppointmentDTO.StartTime);


            if (!await AppointmentServices.CheckExistence(id))
            {
                return NotFound("No Appointment was found with the provided ID.");
            }

            else if (AppointmentDTO == null || !ModelState.IsValid)
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

            try
            {
                var AppointmentFound = await AppointmentServices.GetById(id);

                AppointmentFound.StartTime = AppointmentDTO.StartTime;
                AppointmentFound.EndTime = AppointmentDTO.EndTime;
                AppointmentFound.Reason = AppointmentDTO.Reason;
                AppointmentFound.DiseasId = AppointmentDTO.DiseasId;
                AppointmentFound.AppointmentTypeId = AppointmentDTO.AppointmentTypeId;
                AppointmentFound.PatientId = AppointmentDTO.PatientId;
                AppointmentFound.DoctorId = AppointmentDTO.DoctorId;

                await AppointmentServices.Update(AppointmentFound);
                return Ok("The Appointment was successfully updated.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during the update process.");
            }
        }
    }
}
