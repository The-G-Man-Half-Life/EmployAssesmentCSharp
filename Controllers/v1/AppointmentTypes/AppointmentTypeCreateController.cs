using EmployAssesmentCSharp.Models;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.AppointmentType
{
    [ApiController]
    [Route("api/v1/AppointmentTypes/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("AppointmentType Management")]
    public class AppointmentTypeCreateController : AppointmentTypeController
    {
        private readonly AppointmentTypeServices AppointmentTypeServices;

        public AppointmentTypeCreateController(AppointmentTypeServices AppointmentTypeServices) : base(AppointmentTypeServices)
        {
            this.AppointmentTypeServices = AppointmentTypeServices;
        }

        /// <summary>
        /// Creates a new AppointmentType.
        /// </summary>
        /// <param name="AppointmentTypeDTO">The DTO containing the details of the AppointmentType to be created.</param>
        /// <returns>Returns the newly created AppointmentType object.</returns>
        /// <response code="200">The AppointmentType was created successfully.</response>
        /// <response code="400">The input model is null or invalid.</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new AppointmentType",
            Description = "Allows users to create a new AppointmentType by providing the required details."
        )]
        [SwaggerResponse(200, "AppointmentType created successfully.")]
        [SwaggerResponse(400, "The input model is null or invalid.")]
        public async Task<IActionResult> CreateNewAppointmentType([FromBody] AppointmentTypeDTO AppointmentTypeDTO)
        {
            if (AppointmentTypeDTO == null)
            {
                return BadRequest("The input model cannot be null.");
            }

            else if (ModelState.IsValid == false)
            {
                return BadRequest("The input model is invalid.");
            }

            var newAppointmentType = new Models.AppointmentType(
                AppointmentTypeDTO.Name,
                AppointmentTypeDTO.Description
            );

            await AppointmentTypeServices.Add(newAppointmentType);
            return Ok(newAppointmentType);
        }
    }
}
