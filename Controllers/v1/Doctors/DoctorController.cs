using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployAssesmentCSharp.Controllers.v1.Doctor;

/// <summary>
/// Controller to manage Doctors data and operations.
/// </summary>
[ApiController]
[Route("api/v1/Doctor/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[Tags("Doctor Management")]
public class DoctorController : ControllerBase
{
    protected readonly DoctorServices DoctorServices;

    /// <summary>
    /// Constructor for DoctorController.
    /// </summary>
    /// <param name="DoctorServices">Service for handling Doctor-related operations.</param>
    public DoctorController(DoctorServices DoctorServices)
    {
        this.DoctorServices = DoctorServices;
    }
}
