using MyWebApp.Models;

namespace MyWebApp.Validation;

public interface IValidator<T>
{
    bool IsValid(T input);
}

public class PeselValidator : IValidator<string>
{
    public bool IsValid(string input)
    {
        // Basic PESEL validation (11 digits)
        return !string.IsNullOrEmpty(input) && input.Length == 11 && input.All(char.IsDigit);
    }
}

public class PatientValidator : IValidator<Patient>
{
    private readonly PeselValidator _peselValidator = new();

    public bool IsValid(Patient patient)
    {
        return !string.IsNullOrEmpty(patient.FirstName) &&
               !string.IsNullOrEmpty(patient.LastName) &&
               _peselValidator.IsValid(patient.Pesel);
    }
}

public class AppointmentValidator : IValidator<Appointment>
{
    public bool IsValid(Appointment appointment)
    {
        return appointment.Date > DateTime.Now.AddDays(-1); // Example: appointment not in the past
    }
}
  