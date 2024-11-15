using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Patient
{
    [ApiController]
    [Route("api/v1/Patients/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Patient Management")]
    public class PatientCreateController : PatientController
    {
        private readonly PatientServices PatientServices;

        public PatientCreateController(PatientServices PatientServices) : base(PatientServices)
        {
            this.PatientServices = PatientServices;
        }

        /// <summary>
        /// Creates a new Patient.
        /// </summary>
        /// <param name="PatientDTO">The DTO containing the details of the Patient to be created.</param>
        /// <returns>Returns the newly created Patient object.</returns>
        /// <response code="200">The Patient was created successfully.</response>
        /// <response code="400">The input model is null or invalid.</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new Patient",
            Description = "Allows users to create a new Patient by providing the required details."
        )]
        [SwaggerResponse(200, "Patient created successfully.")]
        [SwaggerResponse(400, "The input model is null or invalid.")]
        public async Task<IActionResult> CreateNewPatient([FromBody] PatientDTO PatientDTO)
        {
            var PatientsList =await PatientServices.GetAll();
            bool RepeatedEmail = PatientsList.Any(b =>b.Email == PatientDTO.Email);
            bool RepeatedIN = PatientsList.Any(b=>b.IdentificationNumber == PatientDTO.IdentificationNumber);

            if (PatientDTO == null)
            {
                return BadRequest("The input model cannot be null.");
            }

            else if (ModelState.IsValid == false)
            {
                return BadRequest("The input model is invalid.");
            }
            else if(RepeatedEmail == true)
            {
                return BadRequest("The email is already in use try another email");   
            }
            else if(RepeatedIN == true)
            {
                return BadRequest("The IN user is already in the datbase");
            }

            var newPatient = new Models.Patient(
                PatientDTO.Name,
                PatientDTO.IdentificationNumber,
                PatientDTO.Email,
                PatientDTO.Password
            );

            await PatientServices.Add(newPatient);
            return Ok(newPatient);
        }
    }
}
