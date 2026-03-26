using System;

namespace Problem6
{

    public class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS Sent: " + message);
        }
    }
}