using MyWebApp.Services;
using MyWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IAppointmentService _appointmentService;

    public AppointmentsController(IAppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Appointment>> GetAll()
    {
        return Ok(_appointmentService.GetAll());
    }

    [HttpGet("{id}")]
    public ActionResult<Appointment> GetById(Guid id)
    {
        var appointment = _appointmentService.GetById(id);

        if (appointment == null)
        {
            return NotFound();
        }

        return Ok(appointment);
    }
}
