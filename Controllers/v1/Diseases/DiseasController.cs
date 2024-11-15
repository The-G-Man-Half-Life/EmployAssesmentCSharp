using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployAssesmentCSharp.Controllers.v1.Diseas;

/// <summary>
/// Controller to manage diseases data and operations.
/// </summary>
[ApiController]
[Route("api/v1/Diseas/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[Tags("Diseas Management")]
public class DiseasController : ControllerBase
{
    protected readonly DiseasServices DiseasServices;

    /// <summary>
    /// Constructor for DiseasController.
    /// </summary>
    /// <param name="DiseasServices">Service for handling disease-related operations.</param>
    public DiseasController(DiseasServices DiseasServices)
    {
        this.DiseasServices = DiseasServices;
    }
}
