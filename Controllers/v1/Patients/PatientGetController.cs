using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations; 

namespace EmployAssesmentCSharp.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/Patients/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Patient Management")]
    public class PatientGetController : PatientController
    {
        private readonly PatientServices PatientServices;

        public PatientGetController(PatientServices PatientServices) : base(PatientServices)
        {
            this.PatientServices = PatientServices;
        }

        /// <summary>
        /// Retrieves all Patients.
        /// </summary>
        /// <returns>A list of all Patients.</returns>
        /// <response code="200">Returns a list of Patients.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet]
        [SwaggerOperation(
            Summary = "Retrieve all Patients",
            Description = "Fetches and returns a list of all registered Patients."
        )]
        [SwaggerResponse(200, "List of Patients retrieved successfully.", typeof(IEnumerable<Models.Patient>))]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<IEnumerable<Models.Patient>>> GetAll()
        {
            try
            {
                var Patients = await PatientServices.GetAll();
                return Ok(Patients);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }

        /// <summary>
        /// Retrieves a Patient by its ID.
        /// </summary>
        /// <param name="id">The ID of the Patient to retrieve.</param>
        /// <returns>The Patient that matches the provided ID.</returns>
        /// <response code="200">Returns the found Patient.</response>
        /// <response code="404">If the Patient does not exist.</response>
        /// <response code="500">Occurs if an error happens during the process.</response>
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Retrieve a Patient by ID",
            Description = "Fetches and returns the Patient that corresponds to the provided ID."
        )]
        [SwaggerResponse(200, "Patient found successfully.", typeof(PatientDTO))]
        [SwaggerResponse(404, "Patient not found.")]
        [SwaggerResponse(500, "An error occurred during the process.")]
        public async Task<ActionResult<PatientDTO>> GetPatientById([FromRoute] int id)
        {
            if (await PatientServices.CheckExistence(id) == false)
            {
                return NotFound();
            }
            try
            {
                var foundPatient = await PatientServices.GetById(id);
                return Ok(foundPatient);
            }
            catch (DbUpdateException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error happened during the process");
            }
        }
    }
}
