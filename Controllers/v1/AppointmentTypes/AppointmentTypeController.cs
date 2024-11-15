using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployAssesmentCSharp.Controllers.v1.AppointmentType;

/// <summary>
/// Controller to manage AppointmentTypes data and operations.
/// </summary>
[ApiController]
[Route("api/v1/AppointmentTypes/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[Tags("AppointmentType Management")]
public class AppointmentTypeController : ControllerBase
{
    protected readonly AppointmentTypeServices AppointmentTypeServices;

    /// <summary>
    /// Constructor for AppointmentTypeController.
    /// </summary>
    /// <param name="AppointmentTypeServices">Service for handling AppointmentType-related operations.</param>
    public AppointmentTypeController(AppointmentTypeServices AppointmentTypeServices)
    {
        this.AppointmentTypeServices = AppointmentTypeServices;
    }
}
