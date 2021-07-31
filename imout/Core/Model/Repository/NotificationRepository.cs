using System;
using System.Collections.Generic;
using imout.Core.Utils;
using Newtonsoft.Json;

namespace imout.Core.Model.Repository
{
    public class NotificationRepository
    {
        private StorageWrapper storage;

        public NotificationRepository(StorageWrapper storageWrapper)
        {
            storage = storageWrapper;
        }

        public List<Notification> Get()
        {
            string notificationsJSON = storage.Get();
            return JsonConvert.DeserializeObject<List<Notification>>(notificationsJSON);
        }

        public void Set(List<Notification> notifications)
        {
            string notificationsJSON = JsonConvert.SerializeObject(notifications);
            storage.Set(notificationsJSON);
        }
    }
}
