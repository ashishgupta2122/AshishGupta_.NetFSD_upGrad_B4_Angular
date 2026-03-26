using System;

namespace Problem6
{
    public class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push Notification Sent: " + message);
        }
    }
}