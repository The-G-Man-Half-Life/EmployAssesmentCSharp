using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Diseas;

[ApiController]
[Route("api/v1/Diseases/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Tags("Diseas Management")]
public class DiseasDeleteController : DiseasController
{
    private readonly DiseasServices DiseasServices;

    public DiseasDeleteController(DiseasServices DiseasServices) : base(DiseasServices)
    {
        this.DiseasServices = DiseasServices;
    }

    /// <summary>
    /// Deletes an existing disease by its ID.
    /// </summary>
    /// <param name="id">The ID of the disease to be deleted.</param>
    /// <returns>Returns a response indicating the result of the delete operation.</returns>
    /// <response code="200">The disease was deleted successfully.</response>
    /// <response code="400">The provided ID is null or invalid.</response>
    /// <response code="500">An error occurred during the deletion process.</response>
    [HttpDelete("{id}")]
    [SwaggerOperation(
        Summary = "Delete an existing disease",
        Description = "Allows users to delete a disease by providing its ID."
    )]
    [SwaggerResponse(200, "The disease was deleted successfully.")]
    [SwaggerResponse(400, "The provided ID is null or invalid.")]
    [SwaggerResponse(500, "An error occurred during the deletion process.")]
    public async Task<IActionResult> DeleteDiseas([FromRoute] int id)
    {
        if (await DiseasServices.CheckExistence(id) == false)
        {
            return BadRequest("Do not exist");
        }
        else
        {
            try
            {
                await DiseasServices.Delete(id);
                return Ok("was a success");
            }
            catch (DbUpdateException dbEX)
            {
                throw new DbUpdateException("An error happened during the process", dbEX);
            }
        }
    }
}
