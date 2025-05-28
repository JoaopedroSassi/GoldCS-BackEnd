using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Services
{
    public interface INotificationService
    {
        bool HasNotifications();
        List<string> GetNotifications();
        void AddNotification(string notification);
        public void ClearNotifications();
    }
    public class NotificationService : INotificationService
    {
        private readonly List<string> _notifications; 

        public NotificationService()
        {
            _notifications = new List<string>();
        }
        public void AddNotification(string notification)
        {
            _notifications.Add(notification);
        }

        public void ClearNotifications()
        {
            _notifications.Clear();
        }

        public List<string> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotifications()
        {
            return _notifications.Count > 0;
        }
    }
}
