using System;
using System.Collections.Generic;
using imout.Core.Model.Repository;

namespace imout.Core.Model.Service
{
    public class NotificationService
    {
        private IRepository notificationRepo;

        public NotificationService(IRepository notificationRepository)
        {
            notificationRepo = notificationRepository;
        }

        public void Create(Notification notification)
        {
            if (notification is null) throw new ArgumentNullException("notification", "Argument passed to Notification.Update() cannot be null");

            List<Notification> notifications = notificationRepo.Get();
            notifications.ForEach(not => {
                if (not.Id == notification.Id) throw new Exception("Notification already exists");
            });

            notifications.Add(notification);

            notificationRepo.Set(notifications);
        }

        public void Update(Notification updatedNotification)
        {
            if (updatedNotification is null) throw new ArgumentNullException("updatedNotification", "Argument passed to Notification.Update() cannot be null");

            List<Notification> notifications = notificationRepo.Get();
            Notification oldNotification = notifications.Find(not => not.Id == updatedNotification.Id);
            if (oldNotification is null) throw new Exception("Notification does not exists");

            notifications.Remove(oldNotification);
            notifications.Add(updatedNotification);

            notificationRepo.Set(notifications);
        }

        public void Delete(Notification notificationToDelete)
        {
            if (notificationToDelete is null) throw new ArgumentNullException("notificationToDelete", "Argument passed to Notification.Delete() cannot be null");

            List<Notification> notifications = notificationRepo.Get();
            Notification notification = notifications.Find(not => not.Id == notificationToDelete.Id);
            if (notification is null) throw new Exception("Notification does not exists");

            notifications.Remove(notification);
            notificationRepo.Set(notifications);
        }
    }
}
