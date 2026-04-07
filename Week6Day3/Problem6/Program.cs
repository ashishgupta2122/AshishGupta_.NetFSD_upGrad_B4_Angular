using System;

namespace Problem6
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

            INotification email = factory.CreateNotification("email");
            email.Send("Welcome via Email!");

            INotification sms = factory.CreateNotification("sms");
            sms.Send("Welcome via SMS!");

            INotification push = factory.CreateNotification("push");
            push.Send("Welcome via Push Notification!");
        }
    }
}