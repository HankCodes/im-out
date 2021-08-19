using System.Collections.Generic;

namespace imout.Core.Model.Repository
{
    public interface IRepository
    {
        List<Notification> Get();

        void Set(List<Notification> notifications);
    }
}
