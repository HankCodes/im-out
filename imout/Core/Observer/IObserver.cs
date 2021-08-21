using imout.Core.Model.Dto;

namespace imout.Core.Observer
{
    public interface IObserver
    {
        void OnCahnge(NotificationDTO notification);
    }
}
