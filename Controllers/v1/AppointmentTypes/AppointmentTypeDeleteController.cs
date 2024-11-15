using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.AppointmentType;

[ApiController]
[Route("api/v1/AppointmentTypes/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("AppointmentType Management")]
public class AppointmentTypeDeleteController : AppointmentTypeController
{
    private readonly AppointmentTypeServices AppointmentTypeServices;

    public AppointmentTypeDeleteController(AppointmentTypeServices AppointmentTypeServices) : base(AppointmentTypeServices)
    {
        this.AppointmentTypeServices = AppointmentTypeServices;
    }

    /// <summary>
    /// Deletes an existing AppointmentType by its ID.
    /// </summary>
    /// <param name="id">The ID of the AppointmentType to be deleted.</param>
    /// <returns>Returns a response indicating the result of the delete operation.</returns>
    /// <response code="200">The AppointmentType was deleted successfully.</response>
    /// <response code="400">The provided ID is null or invalid.</response>
    /// <response code="500">An error occurred during the deletion process.</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing AppointmentType",
        Description = "Allows users to delete a AppointmentType by providing its ID."
    )]
    [SwaggerResponse(200, "The AppointmentType was deleted successfully.")]
    [SwaggerResponse(400, "The provided ID is null or invalid.")]
    [SwaggerResponse(500, "An error occurred during the deletion process.")]
    public async Task<IActionResult> DeleteAppointmentType([FromRoute] int id)
    {
        if (await AppointmentTypeServices.CheckExistence(id) == false)
        {
            return BadRequest("Do not exist");
        }
        else
        {
            try
            {
                await AppointmentTypeServices.Delete(id);
                return Ok("was a success");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error happened during the process", dbEX);
            }
        }
    }
}
