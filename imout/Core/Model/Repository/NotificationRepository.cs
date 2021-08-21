using System.Collections.Generic;
using imout.Core.Utils.Storage;
using Newtonsoft.Json;

namespace imout.Core.Model.Repository
{
    public class NotificationRepository: IRepository
    {
        private IStorageWrapper storage;

        public NotificationRepository(IStorageWrapper storageWrapper)
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
