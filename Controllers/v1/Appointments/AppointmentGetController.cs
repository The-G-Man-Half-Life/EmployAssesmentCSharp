using CSharpTest.Models;
using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations; 

namespace EmployAssesmentCSharp.Controllers.v1.Appointment
{
    [ApiController]
    [Route("api/v1/Appointments/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Appointment Management")]
    public class AppointmentGetController : AppointmentController
    {
        private readonly AppointmentServices AppointmentServices;

        public AppointmentGetController(AppointmentServices AppointmentServices) : base(AppointmentServices)
        {
            this.AppointmentServices = AppointmentServices;
        }

        /// <summary>
        /// Retrieves all Appointments.
        /// </summary>
        /// <returns>A list of all Appointments.</returns>
        /// <response code="200">Returns a list of Appointments.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve all Appointments",
            Description = "Fetches and returns a list of all registered Appointments."
        )]
        [SwaggerResponse(200, "List of Appointments retrieved successfully.", typeof(IEnumerable<Models.Appointment>))]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<IEnumerable<Models.Appointment>>> GetAll()
        {
            try
            {
                var Appointments = await AppointmentServices.GetAll();
                return Ok(Appointments);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }

        /// <summary>
        /// Retrieves a Appointment by its ID.
        /// </summary>
        /// <param name="id">The ID of the Appointment to retrieve.</param>
        /// <returns>The Appointment that matches the provided ID.</returns>
        /// <response code="200">Returns the found Appointment.</response>
        /// <response code="404">If the Appointment does not exist.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieve a Appointment by ID",
            Description = "Fetches and returns the Appointment that corresponds to the provided ID."
        )]
        [SwaggerResponse(200, "Appointment found successfully.", typeof(AppointmentDTO))]
        [SwaggerResponse(404, "Appointment not found.")]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<AppointmentDTO>> GetAppointmentById([FromRoute] int id)
        {
            if (await AppointmentServices.CheckExistence(id) == false)
            {
                return NotFound();
            }
            try
            {
                var foundAppointment = await AppointmentServices.GetById(id);
                return Ok(foundAppointment);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }
    }
}
