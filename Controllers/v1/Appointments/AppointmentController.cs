using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployAssesmentCSharp.Controllers.v1.Appointment;

/// <summary>
/// Controller to manage Appointments data and operations.
/// </summary>
[ApiController]
[Route("api/v1/Appointment/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[Tags("Appointment Management")]
public class AppointmentController : ControllerBase
{
    protected readonly AppointmentServices AppointmentServices;

    /// <summary>
    /// Constructor for AppointmentController.
    /// </summary>
    /// <param name="AppointmentServices">Service for handling Appointment-related operations.</param>
    public AppointmentController(AppointmentServices AppointmentServices)
    {
        this.AppointmentServices = AppointmentServices;
    }
}
