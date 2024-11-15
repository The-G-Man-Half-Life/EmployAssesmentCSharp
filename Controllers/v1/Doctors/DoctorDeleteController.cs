using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Doctor;

[ApiController]
[Route("api/v1/Doctors/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Doctor Management")]
public class DoctorDeleteController : DoctorController
{
    private readonly DoctorServices DoctorServices;

    public DoctorDeleteController(DoctorServices DoctorServices) : base(DoctorServices)
    {
        this.DoctorServices = DoctorServices;
    }

    /// <summary>
    /// Deletes an existing Doctor by its ID.
    /// </summary>
    /// <param name="id">The ID of the Doctor to be deleted.</param>
    /// <returns>Returns a response indicating the result of the delete operation.</returns>
    /// <response code="200">The Doctor was deleted successfully.</response>
    /// <response code="400">The provided ID is null or invalid.</response>
    /// <response code="500">An error occurred during the deletion process.</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing Doctor",
        Description = "Allows users to delete a Doctor by providing its ID."
    )]
    [SwaggerResponse(200, "The Doctor was deleted successfully.")]
    [SwaggerResponse(400, "The provided ID is null or invalid.")]
    [SwaggerResponse(500, "An error occurred during the deletion process.")]
    public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
    {
        if (await DoctorServices.CheckExistence(id) == false)
        {
            return BadRequest("Do not exist");
        }
        else
        {
            try
            {
                await DoctorServices.Delete(id);
                return Ok("was a success");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error happened during the process", dbEX);
            }
        }
    }
}
