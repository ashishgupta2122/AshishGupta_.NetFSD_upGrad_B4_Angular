using System;

namespace Problem6
{
    public class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email Sent: " + message);
        }
    }
}