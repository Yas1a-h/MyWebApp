using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using MyWebApp.Services;

namespace MyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IPatientService _patientService;

    public PatientController(IPatientService patientService)
    {
        _patientService = patientService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Patient>> GetAll()
    {
        return Ok(_patientService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Patient> GetById(Guid id)
    {
        var patient = _patientService.GetById(id);

        if (patient == null)
        {
            return NotFound();
        }

        return Ok(patient);
    }
}
