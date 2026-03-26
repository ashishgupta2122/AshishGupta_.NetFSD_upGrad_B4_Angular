using System;

namespace Problem6
{
    public class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            switch (type.ToLower())
            {
                case "email":
                    return new EmailNotification();

                case "sms":
                    return new EmailNotification();

                case "push":
                    return new EmailNotification();

                default:
                    throw new AggregateException("Invalid notification type");
            }
        }
    }
}