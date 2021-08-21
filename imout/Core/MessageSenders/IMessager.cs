using imout.Core.Model.Dto;

namespace imout.Core.MessageSenders
{
    public interface IMessager
    {
        void Send(NotificationDTO notification);
    }
}
