using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace EmployAssesmentCSharp.Controllers.v1.Diseas
{
    [ApiController]
    [Route("api/v1/Diseases/[controller]")]
    [ApiExplorerSettings(GroupName = "v1")]
    [Tags("Diseas Management")]
    public class DiseasCreateController : DiseasController
    {
        private new readonly DiseasServices DiseasServices;

        public DiseasCreateController(DiseasServices DiseasServices) : base(DiseasServices)
        {
            this.DiseasServices = DiseasServices;
        }

        /// <summary>
        /// Creates a new disease.
        /// </summary>
        /// <param name="DiseasDTO">The DTO containing the details of the disease to be created.</param>
        /// <returns>Returns the newly created disease object.</returns>
        /// <response code="200">The disease was created successfully.</response>
        /// <response code="400">The input model is null or invalid.</response>
        [HttpPost]
        [SwaggerOperation(
            Summary = "Create a new disease",
            Description = "Allows users to create a new disease by providing the required details."
        )]
        [SwaggerResponse(200, "Disease created successfully.")]
        [SwaggerResponse(400, "The input model is null or invalid.")]
        public async Task<IActionResult> CreateNewDiseas([FromBody] DiseasDTO DiseasDTO)
        {
            if (DiseasDTO == null)
            {
                return BadRequest("The input model cannot be null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest("The input model is invalid.");
            }

            var newDiseas = new Models.Diseas(
                DiseasDTO.Name,
                DiseasDTO.Description
            );

            await DiseasServices.Add(newDiseas);
            return Ok(newDiseas);
        }
    }
}
