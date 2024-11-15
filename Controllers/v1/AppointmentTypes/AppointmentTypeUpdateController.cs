using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Controllers.v1.AppointmentType
{
    [ApiController]
    [Route("api/v1/AppointmentTypes/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("AppointmentType Management")]
    public class AppointmentTypeUpdateController : AppointmentTypeController
    {
        private readonly AppointmentTypeServices AppointmentTypeServices;

        public AppointmentTypeUpdateController(AppointmentTypeServices AppointmentTypeServices) : base(AppointmentTypeServices)
        {
            this.AppointmentTypeServices = AppointmentTypeServices;
        }

        /// <summary>
        /// Updates an existing AppointmentType.
        /// </summary>
        /// <param name="id">The ID of the AppointmentType to update.</param>
        /// <param name="AppointmentTypeDTO">The DTO containing the updated AppointmentType data.</param>
        /// <returns>A success or error message.</returns>
        /// <response code="200">The AppointmentType was successfully updated.</response>
        /// <response code="400">The input model is invalid or contains errors.</response>
        /// <response code="404">No AppointmentType was found with the provided ID.</response>
        /// <response code="500">An error occurred during the update process.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing AppointmentType",
            Description = "Allows updating an existing AppointmentType by providing its ID and updated data."
        )]
        [SwaggerResponse(200, "The AppointmentType was successfully updated.")]
        [SwaggerResponse(400, "The input model is invalid or contains errors.")]
        [SwaggerResponse(404, "No AppointmentType was found with the provided ID.")]
        [SwaggerResponse(500, "An error occurred during the update process.")]
        public async Task<ActionResult> UpdateAppointmentType([FromRoute] int id, [FromBody] AppointmentTypeDTO AppointmentTypeDTO)
        {
            if (!await AppointmentTypeServices.CheckExistence(id))
            {
                return NotFound("No AppointmentType was found with the provided ID.");
            }

            if (AppointmentTypeDTO == null || !ModelState.IsValid)
            {
                return BadRequest("The input model is invalid.");
            }

            try
            {
                var AppointmentTypeFound = await AppointmentTypeServices.GetById(id);

                AppointmentTypeFound.Name = AppointmentTypeDTO.Name;
                AppointmentTypeFound.Description = AppointmentTypeDTO.Description;

                await AppointmentTypeServices.Update(AppointmentTypeFound);
                return Ok("The AppointmentType was successfully updated.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during the update process.");
            }
        }
    }
}
