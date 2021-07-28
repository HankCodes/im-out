using imout.Core.Model;

namespace imout.Core.Observer
{
    public interface IObserver
    {
        void OnCahnge(NotificationDTO notification);
    }
}
