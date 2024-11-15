using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations; 

namespace EmployAssesmentCSharp.Controllers.v1.AppointmentType
{
    [ApiController]
    [Route("api/v1/AppointmentTypes/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("AppointmentType Management")]
    public class AppointmentTypeGetController : AppointmentTypeController
    {
        private readonly AppointmentTypeServices AppointmentTypeServices;

        public AppointmentTypeGetController(AppointmentTypeServices AppointmentTypeServices) : base(AppointmentTypeServices)
        {
            this.AppointmentTypeServices = AppointmentTypeServices;
        }

        /// <summary>
        /// Retrieves all AppointmentTypes.
        /// </summary>
        /// <returns>A list of all AppointmentTypes.</returns>
        /// <response code="200">Returns a list of AppointmentTypes.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve all AppointmentTypes",
            Description = "Fetches and returns a list of all registered AppointmentTypes."
        )]
        [SwaggerResponse(200, "List of AppointmentTypes retrieved successfully.", typeof(IEnumerable<Models.AppointmentType>))]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<IEnumerable<Models.AppointmentType>>> GetAll()
        {
            try
            {
                var AppointmentTypes = await AppointmentTypeServices.GetAll();
                return Ok(AppointmentTypes);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }

        /// <summary>
        /// Retrieves a AppointmentType by its ID.
        /// </summary>
        /// <param name="id">The ID of the AppointmentType to retrieve.</param>
        /// <returns>The AppointmentType that matches the provided ID.</returns>
        /// <response code="200">Returns the found AppointmentType.</response>
        /// <response code="404">If the AppointmentType does not exist.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieve a AppointmentType by ID",
            Description = "Fetches and returns the AppointmentType that corresponds to the provided ID."
        )]
        [SwaggerResponse(200, "AppointmentType found successfully.", typeof(AppointmentTypeDTO))]
        [SwaggerResponse(404, "AppointmentType not found.")]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<AppointmentTypeDTO>> GetAppointmentTypeById([FromRoute] int id)
        {
            if (await AppointmentTypeServices.CheckExistence(id) == false)
            {
                return NotFound();
            }
            try
            {
                var foundAppointmentType = await AppointmentTypeServices.GetById(id);
                return Ok(foundAppointmentType);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }
    }
}
