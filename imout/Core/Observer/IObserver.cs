using imout.Core.Model;

namespace imout.Core.Observer
{
    public interface IObserver
    {
        public void OnCahnge(NotificationDTO notification);
    }
}
