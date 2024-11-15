using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/Patients/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Patient Management")]
    public class PatientUpdateController : PatientController
    {
        private readonly PatientServices PatientServices;

        public PatientUpdateController(PatientServices PatientServices) : base(PatientServices)
        {
            this.PatientServices = PatientServices;
        }

        /// <summary>
        /// Updates an existing Patient.
        /// </summary>
        /// <param name="id">The ID of the Patient to update.</param>
        /// <param name="PatientDTO">The DTO containing the updated Patient data.</param>
        /// <returns>A success or error message.</returns>
        /// <response code="200">The Patient was successfully updated.</response>
        /// <response code="400">The input model is invalid or contains errors.</response>
        /// <response code="404">No Patient was found with the provided ID.</response>
        /// <response code="500">An error occurred during the update process.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing Patient",
            Description = "Allows updating an existing Patient by providing its ID and updated data."
        )]
        [SwaggerResponse(200, "The Patient was successfully updated.")]
        [SwaggerResponse(400, "The input model is invalid or contains errors.")]
        [SwaggerResponse(404, "No Patient was found with the provided ID.")]
        [SwaggerResponse(500, "An error occurred during the update process.")]
        public async Task<ActionResult> UpdatePatient([FromRoute] int id, [FromBody] PatientDTO PatientDTO)
        {
            if (!await PatientServices.CheckExistence(id))
            {
                return NotFound("No Patient was found with the provided ID.");
            }

            if (PatientDTO == null || !ModelState.IsValid)
            {
                return BadRequest("The input model is invalid.");
            }

            try
            {
                var PatientFound = await PatientServices.GetById(id);

                PatientFound.Name = PatientDTO.Name;
                PatientFound.IdentificationNumber = PatientDTO.IdentificationNumber;
                PatientFound.Email = PatientDTO.Email;
                PatientFound.Password = PatientDTO.Password;

                await PatientServices.Update(PatientFound);
                return Ok("The Patient was successfully updated.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during the update process.");
            }
        }
    }
}
