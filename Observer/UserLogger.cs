using System;

namespace MyWebApp.Observers
{
    public class UserLogger : IObserver
    {
        public void Update(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}