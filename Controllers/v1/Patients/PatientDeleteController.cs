using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Patient;

[ApiController]
[Route("api/v1/Patients/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Patient Management")]
public class PatientDeleteController : PatientController
{
    private readonly PatientServices PatientServices;

    public PatientDeleteController(PatientServices PatientServices) : base(PatientServices)
    {
        this.PatientServices = PatientServices;
    }

    /// <summary>
    /// Deletes an existing Patient by its ID.
    /// </summary>
    /// <param name="id">The ID of the Patient to be deleted.</param>
    /// <returns>Returns a response indicating the result of the delete operation.</returns>
    /// <response code="200">The Patient was deleted successfully.</response>
    /// <response code="400">The provided ID is null or invalid.</response>
    /// <response code="500">An error occurred during the deletion process.</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing Patient",
        Description = "Allows users to delete a Patient by providing its ID."
    )]
    [SwaggerResponse(200, "The Patient was deleted successfully.")]
    [SwaggerResponse(400, "The provided ID is null or invalid.")]
    [SwaggerResponse(500, "An error occurred during the deletion process.")]
    public async Task<IActionResult> DeletePatient([FromRoute] int id)
    {
        if (await PatientServices.CheckExistence(id) == false)
        {
            return BadRequest("Do not exist");
        }
        else
        {
            try
            {
                await PatientServices.Delete(id);
                return Ok("was a success");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error happened during the process", dbEX);
            }
        }
    }
}
