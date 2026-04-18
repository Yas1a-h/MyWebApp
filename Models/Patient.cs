namespace MyWebApp.Models;

using System;

public abstract class PatientStatus
{
    public abstract string DisplayName { get; }
}

public class ActiveStatus : PatientStatus
{
    public override string DisplayName => "Active";
}

public class InactiveStatus : PatientStatus
{
    public override string DisplayName => "Inactive";
}

public class DeceasedStatus : PatientStatus
{
    public override string DisplayName => "Deceased";
}
public class Patient
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Pesel { get; set; } = string.Empty;

    public DateOnly DateOfBirth { get; set; }

    public PatientStatus Status { get; set; } = new ActiveStatus();


    
}