using System;

namespace Backend.Patterns.DSL
{
    public class Encounter
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
    }

    public class Appointment
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
    }

    public class PlanTask
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        Scheduled,
        Completed,
        Canceled
    }

    public enum AppointmentStatus
    {
        Scheduled,
        Completed,
        Canceled
    }

    public class Test
    {
        private IAppointmentChecker appointmentChecker = new AppointmentCheckerImpl();

        public void Run()
        {
            var encounter = new Encounter
            {
                Id = Guid.NewGuid(),
                PatientId = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Patient reported mild headache."
            };

            var appointment = new Appointment
            {
                Id = Guid.NewGuid(),
                PatientId = encounter.PatientId,
                Date = DateTime.Now.AddDays(7)
            };

            var planTask = new PlanTask
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now.AddDays(1),
                Status = TaskStatus.Scheduled
            };

            var process = Process.For<PlanTask, Appointment, Encounter>()
                .If((plan, appointment) => plan.Date == appointment.Date && plan.Status == TaskStatus.Scheduled)
                .If((plan, appointment) => plan.Date < appointment.Date && appointment.Status == AppointmentStatus.Scheduled)
                .Then((plan, appointment) => appointmentChecker.Check(plan, appointment))
                .If((appointment, encounter) => appointment.Date < encounter.Date && appointment.Status == AppointmentStatus.Scheduled)
                .Then((appointment, encounter) => appointment.Status = AppointmentStatus.Completed);

            var process2 = Process.For<PlanTask, Appointment>()
                .Group()
                .If((plan, appointment) => plan.Date == appointment.Date && plan.Status == TaskStatus.Scheduled)
                .Then((plan, appointment) => plan.Status = TaskStatus.Completed)
                .If((plan, appointment) => plan.Date < appointment.Date && appointment.Status == AppointmentStatus.Scheduled)
                .Then((plan, appointment) => appointment.Status = AppointmentStatus.Completed);

            // var process3 = Process.For<PlanTask, Appointment, Encounter>()
            //     .Join();

            process.Odpalaj(planTask, appointment);

            // var process4 = PaymentProcess()
            //     .Group()
            //     .Discount()
            //     .CreateInvoice();

            // var result = del(planTask, appointment);
            var result2 = appointmentChecker.Check(planTask, appointment);
        }
    }

    public interface IAppointmentChecker
    {
        Appointment Check(PlanTask plan, Appointment appointment);
    }

    public class AppointmentCheckerImpl : IAppointmentChecker
    {
        public Appointment Check(PlanTask plan, Appointment appointment)
        {
            // Implementation logic here
            return appointment;
        }
    }

    public static class Process
    {
        public static ProcessBuilder<T1, T2, T3> For<T1, T2, T3>()
        {
            return new ProcessBuilder<T1, T2, T3>();
        }

        public static ProcessBuilder<T1, T2> For<T1, T2>()
        {
            return new ProcessBuilder<T1, T2>();
        }
    }

    public class ProcessBuilder<T1, T2, T3>
    {
        public ProcessBuilder<T1, T2, T3> If(Func<T1, T2, bool> condition) => this;
        public ProcessBuilder<T1, T2, T3> If(Func<T1, T2, T3, bool> condition) => this;
        public ProcessBuilder<T1, T2, T3> If(Func<T2, T3, bool> condition) => this;
        public ProcessBuilder<T1, T2, T3> Then(Action<T1, T2> action) => this;
        public ProcessBuilder<T1, T2, T3> Then(Action<T2, T3> action) => this;
        public void Odpalaj(T1 t1, T2 t2) { }
    }

    public class ProcessBuilder<T1, T2>
    {
        public ProcessBuilder<T1, T2> Group() => this;
        public ProcessBuilder<T1, T2> If(Func<T1, T2, bool> condition) => this;
        public ProcessBuilder<T1, T2> Then(Action<T1, T2> action) => this;
    }
}