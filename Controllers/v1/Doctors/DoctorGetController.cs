using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations; 

namespace EmployAssesmentCSharp.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/Doctors/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Doctor Management")]
    public class DoctorGetController : DoctorController
    {
        private readonly DoctorServices DoctorServices;

        public DoctorGetController(DoctorServices DoctorServices) : base(DoctorServices)
        {
            this.DoctorServices = DoctorServices;
        }

        /// <summary>
        /// Retrieves all Doctors.
        /// </summary>
        /// <returns>A list of all Doctors.</returns>
        /// <response code="200">Returns a list of Doctors.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve all Doctors",
            Description = "Fetches and returns a list of all registered Doctors."
        )]
        [SwaggerResponse(200, "List of Doctors retrieved successfully.", typeof(IEnumerable<Models.Doctor>))]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<IEnumerable<Models.Doctor>>> GetAll()
        {
            try
            {
                var Doctors = await DoctorServices.GetAll();
                return Ok(Doctors);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }

        /// <summary>
        /// Retrieves a Doctor by its ID.
        /// </summary>
        /// <param name="id">The ID of the Doctor to retrieve.</param>
        /// <returns>The Doctor that matches the provided ID.</returns>
        /// <response code="200">Returns the found Doctor.</response>
        /// <response code="404">If the Doctor does not exist.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieve a Doctor by ID",
            Description = "Fetches and returns the Doctor that corresponds to the provided ID."
        )]
        [SwaggerResponse(200, "Doctor found successfully.", typeof(DoctorDTO))]
        [SwaggerResponse(404, "Doctor not found.")]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<DoctorDTO>> GetDoctorById([FromRoute] int id)
        {
            if (await DoctorServices.CheckExistence(id) == false)
            {
                return NotFound();
            }
            try
            {
                var foundDoctor = await DoctorServices.GetById(id);
                return Ok(foundDoctor);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }
    }
}
