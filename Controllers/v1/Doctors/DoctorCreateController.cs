using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Doctor
{
    [ApiController]
    [Route("api/v1/Doctors/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Doctor Management")]
    public class DoctorCreateController : DoctorController
    {
        private readonly DoctorServices DoctorServices;

        public DoctorCreateController(DoctorServices DoctorServices) : base(DoctorServices)
        {
            this.DoctorServices = DoctorServices;
        }

        /// <summary>
        /// Creates a new Doctor.
        /// </summary>
        /// <param name="DoctorDTO">The DTO containing the details of the Doctor to be created.</param>
        /// <returns>Returns the newly created Doctor object.</returns>
        /// <response code="200">The Doctor was created successfully.</response>
        /// <response code="400">The input model is null or invalid.</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new Doctor",
            Description = "Allows users to create a new Doctor by providing the required details."
        )]
        [SwaggerResponse(200, "Doctor created successfully.")]
        [SwaggerResponse(400, "The input model is null or invalid.")]
        public async Task<IActionResult> CreateNewDoctor([FromBody] DoctorDTO DoctorDTO)
        {
            var DoctorsList =await DoctorServices.GetAll();
            bool RepeatedEmail = DoctorsList.Any(b =>b.Email == DoctorDTO.Email);
            bool RepeatedIN = DoctorsList.Any(b=>b.IdentificationNumber == DoctorDTO.IdentificationNumber);

            if (DoctorDTO == null)
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

            var newDoctor = new Models.Doctor(
                DoctorDTO.Name,
                DoctorDTO.IdentificationNumber,
                DoctorDTO.Email,
                DoctorDTO.Password,
                DoctorDTO.Specialty,
                DoctorDTO.StartTime,
                DoctorDTO.EndTime
            );

            await DoctorServices.Add(newDoctor);
            return Ok(newDoctor);
        }
    }
}
