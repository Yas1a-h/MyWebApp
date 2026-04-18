using System;

namespace MyWebApp.Models;

public class Appointment
{
    public Guid Id {get;set;}

    public Guid PatientId {get;set;}

    public DateTime Date {get;set;}

    public string PractitionerName {get;set;} = string.Empty;

    public AppointmentStatus Status {get;set;}
}

public enum AppointmentStatus
{
    Scheduled,
    Completed,
    Canceled
}