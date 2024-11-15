using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.EntityFrameworkCore;

namespace EmployAssesmentCSharp.Controllers.v1.Diseas
{
    [ApiController]
    [Route("api/v1/Diseas/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Diseas Management")]
    public class DiseasUpdateController : DiseasController
    {
        private readonly DiseasServices DiseasServices;

        public DiseasUpdateController(DiseasServices DiseasServices) : base(DiseasServices)
        {
            this.DiseasServices = DiseasServices;
        }

        /// <summary>
        /// Updates an existing disease.
        /// </summary>
        /// <param name="id">The ID of the disease to update.</param>
        /// <param name="DiseasDTO">The DTO containing the updated disease data.</param>
        /// <returns>A success or error message.</returns>
        /// <response code="200">The disease was successfully updated.</response>
        /// <response code="400">The input model is invalid or contains errors.</response>
        /// <response code="404">No disease was found with the provided ID.</response>
        /// <response code="500">An error occurred during the update process.</response>
        [HttpPut("{id}")]
        [SwaggerOperation(
            Summary = "Update an existing disease",
            Description = "Allows updating an existing disease by providing its ID and updated data."
        )]
        [SwaggerResponse(200, "The disease was successfully updated.")]
        [SwaggerResponse(400, "The input model is invalid or contains errors.")]
        [SwaggerResponse(404, "No disease was found with the provided ID.")]
        [SwaggerResponse(500, "An error occurred during the update process.")]
        public async Task<ActionResult> UpdateDiseas([FromRoute] int id, [FromBody] DiseasDTO DiseasDTO)
        {
            if (!await DiseasServices.CheckExistence(id))
            {
                return NotFound("No disease was found with the provided ID.");
            }

            if (DiseasDTO == null || !ModelState.IsValid)
            {
                return BadRequest("The input model is invalid.");
            }

            try
            {
                var DiseasFound = await DiseasServices.GetById(id);

                DiseasFound.Name = DiseasDTO.Name;
                DiseasFound.Description = DiseasDTO.Description;

                await DiseasServices.Update(DiseasFound);
                return Ok("The disease was successfully updated.");
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred during the update process.");
            }
        }
    }
}
