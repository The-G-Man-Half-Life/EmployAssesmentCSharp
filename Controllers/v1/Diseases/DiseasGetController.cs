using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations; 

namespace EmployAssesmentCSharp.Controllers.v1.Diseas
{
    [ApiController]
    [Route("api/v1/Diseases/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Diseas Management")]
    public class DiseasGetController : DiseasController
    {
        private readonly DiseasServices DiseasServices;

        public DiseasGetController(DiseasServices DiseasServices) : base(DiseasServices)
        {
            this.DiseasServices = DiseasServices;
        }

        /// <summary>
        /// Retrieves all diseases.
        /// </summary>
        /// <returns>A list of all diseases.</returns>
        /// <response code="200">Returns a list of diseases.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve all diseases",
            Description = "Fetches and returns a list of all registered diseases."
        )]
        [SwaggerResponse(200, "List of diseases retrieved successfully.", typeof(IEnumerable<Models.Diseas>))]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<IEnumerable<Models.Diseas>>> GetAll()
        {
            try
            {
                var Diseass = await DiseasServices.GetAll();
                return Ok(Diseass);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }

        /// <summary>
        /// Retrieves a disease by its ID.
        /// </summary>
        /// <param name="id">The ID of the disease to retrieve.</param>
        /// <returns>The disease that matches the provided ID.</returns>
        /// <response code="200">Returns the found disease.</response>
        /// <response code="404">If the disease does not exist.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieve a disease by ID",
            Description = "Fetches and returns the disease that corresponds to the provided ID."
        )]
        [SwaggerResponse(200, "Disease found successfully.", typeof(DiseasDTO))]
        [SwaggerResponse(404, "Disease not found.")]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<DiseasDTO>> GetDiseasById([FromRoute] int id)
        {
            if (await DiseasServices.CheckExistence(id) == false)
            {
                return NotFound();
            }
            try
            {
                var foundDiseas = await DiseasServices.GetById(id);
                return Ok(foundDiseas);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }
    }
}
