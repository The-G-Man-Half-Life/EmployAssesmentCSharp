using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/Doctors/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Doctor Management")]
    public class DoctorUpdateController : DoctorController
    {
        private readonly DoctorServices DoctorServices;

        public DoctorUpdateController(DoctorServices DoctorServices) : base(DoctorServices)
        {
            this.DoctorServices = DoctorServices;
        }

        /// <summary>
        /// Updates an existing Doctor.
        /// </summary>
        /// <param name="id">The ID of the Doctor to update.</param>
        /// <param name="DoctorDTO">The DTO containing the updated Doctor data.</param>
        /// <returns>A success or error message.</returns>
        /// <response code="200">The Doctor was successfully updated.</response>
        /// <response code="400">The input model is invalid or contains errors.</response>
        /// <response code="404">No Doctor was found with the provided ID.</response>
        /// <response code="500">An error occurred during the update process.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing Doctor",
            Description = "Allows updating an existing Doctor by providing its ID and updated data."
        )]
        [SwaggerResponse(200, "The Doctor was successfully updated.")]
        [SwaggerResponse(400, "The input model is invalid or contains errors.")]
        [SwaggerResponse(404, "No Doctor was found with the provided ID.")]
        [SwaggerResponse(500, "An error occurred during the update process.")]
        public async Task<ActionResult> UpdateDoctor([FromRoute] int id, [FromBody] DoctorDTO DoctorDTO)
        {
            if (!await DoctorServices.CheckExistence(id))
            {
                return NotFound("No Doctor was found with the provided ID.");
            }

            if (DoctorDTO == null || !ModelState.IsValid)
            {
                return BadRequest("The input model is invalid.");
            }

            try
            {
                var DoctorFound = await DoctorServices.GetById(id);

                DoctorFound.Name = DoctorDTO.Name;
                DoctorFound.IdentificationNumber = DoctorDTO.IdentificationNumber;
                DoctorFound.Email = DoctorDTO.Email;
                DoctorFound.Password = DoctorDTO.Password;
                DoctorFound.Specialty = DoctorDTO.Specialty;
                DoctorFound.StartTime = DoctorDTO.StartTime;
                DoctorFound.EndTime = DoctorDTO.EndTime;

                await DoctorServices.Update(DoctorFound);
                return Ok("The Doctor was successfully updated.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during the update process.");
            }
        }
    }
}
