using imout.Core.Model;

namespace imout.Core.MessageSenders
{
    public interface IMessager
    {
        void Send(NotificationDTO notification);
    }
}
