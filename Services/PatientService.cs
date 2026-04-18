using MyWebApp.Models;
using System;
using System.Collections.Generic;

namespace MyWebApp.Services;

public interface IPatientService
{
    IEnumerable<Patient> GetAll();
    Patient? GetById(Guid id);
}

public class PatientService : IPatientService
{
    private readonly List<Patient> _patients = new List<Patient>
    {
        new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = "John",
            LastName = "Doe",
            Pesel = "12345678901",
            DateOfBirth = new DateOnly(1990, 1, 1),
            Status = new ActiveStatus()
        },
        new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = "Jane",
            LastName = "Smith",
            Pesel = "10987654321",
            DateOfBirth = new DateOnly(1985, 5, 15),
            Status = new InactiveStatus()
        },
        new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = "Alice",
            LastName = "Johnson",
            Pesel = "56789012345",
            DateOfBirth = new DateOnly(1975, 10, 30),
            Status = new InactiveStatus()
        }
    };

    public IEnumerable<Patient> GetAll()
    {
        return _patients;
    }

    public Patient? GetById(Guid id) => _patients.FirstOrDefault(p => p.Id == id);

    public Patient Add(Patient patient)
    {
        patient.Id = Guid.NewGuid();
        _patients.Add(patient);
        return patient;
    }
}