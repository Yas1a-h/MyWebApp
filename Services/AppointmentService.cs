using System;
using System.Collections.Generic;
using MyWebApp.Models;

namespace MyWebApp.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAll();
        Appointment? GetById(Guid id);
    }

    public class AppointmentService : IAppointmentService
    {
        private List<Appointment> _appointments = new();

        public AppointmentService()
        {
            _appointments.Add(new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                PractitionerName = "Dr. House",
                Date = DateTime.Now.AddDays(1),
                Status = AppointmentStatus.Scheduled
            });

            _appointments.Add(new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                PractitionerName = "Dr. Watson",
                Date = DateTime.Now.AddDays(-1),
                Status = AppointmentStatus.Completed
            });

            _appointments.Add(new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                PractitionerName = "Dr. Grey",
                Date = DateTime.Now.AddDays(2),
                Status = AppointmentStatus.Canceled
            });
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointments;
        }

        public Appointment? GetById(Guid id) => _appointments.FirstOrDefault(a => a.Id == id);

        public Appointment Add(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid();
            _appointments.Add(appointment);
            return appointment;
        }
    }
}
