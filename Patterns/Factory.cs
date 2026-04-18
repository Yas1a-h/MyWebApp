using MyWebApp.Models;

public static class PatientFactory
{
    public static Patient Create(string firstName, string lastName, string pesel, DateOnly dateOfBirth)
    {
        return new Patient
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Pesel = pesel,
            DateOfBirth = dateOfBirth,
            Status = new ActiveStatus()
        };
    }
}