using EmployAssesmentCSharp.Repositories.Interfaces;
using EmployAssesmentCSharp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployAssesmentCSharp.Controllers.v1.Patient;

/// <summary>
/// Controller to manage Patients data and operations.
/// </summary>
[ApiController]
[Route("api/v1/Patient/[controller]")]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[Tags("Patient Management")]
public class PatientController : ControllerBase
{
    protected readonly PatientServices PatientServices;

    /// <summary>
    /// Constructor for PatientController.
    /// </summary>
    /// <param name="PatientServices">Service for handling Patient-related operations.</param>
    public PatientController(PatientServices PatientServices)
    {
        this.PatientServices = PatientServices;
    }
}
