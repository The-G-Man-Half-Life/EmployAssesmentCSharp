using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Appointment;

[ApiController]
[Route("api/v1/Appointments/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Appointment Management")]
public class AppointmentDeleteController : AppointmentController
{
    private readonly AppointmentServices AppointmentServices;

    public AppointmentDeleteController(AppointmentServices AppointmentServices) : base(AppointmentServices)
    {
        this.AppointmentServices = AppointmentServices;
    }

    /// <summary>
    /// Deletes an existing Appointment by its ID.
    /// </summary>
    /// <param name="id">The ID of the Appointment to be deleted.</param>
    /// <returns>Returns a response indicating the result of the delete operation.</returns>
    /// <response code="200">The Appointment was deleted successfully.</response>
    /// <response code="400">The provided ID is null or invalid.</response>
    /// <response code="500">An error occurred during the deletion process.</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing Appointment",
        Description = "Allows users to delete a Appointment by providing its ID."
    )]
    [SwaggerResponse(200, "The Appointment was deleted successfully.")]
    [SwaggerResponse(400, "The provided ID is null or invalid.")]
    [SwaggerResponse(500, "An error occurred during the deletion process.")]
    public async Task<IActionResult> DeleteAppointment([FromRoute] int id)
    {
        if (await AppointmentServices.CheckExistence(id) == false)
        {
            return BadRequest("Do not exist");
        }
        else
        {
            try
            {
                await AppointmentServices.Delete(id);
                return Ok("was a success");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error happened during the process", dbEX);
            }
        }
    }
}
