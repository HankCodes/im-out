using System.Collections.Generic;

namespace imout.Core.Model.Dto
{
    public class NotificationDTO
    {
        public List<Contact> Contacts { get; set; }
        public string Message { get; set; }

        public NotificationDTO(List<Contact> contacts, string message)
        {
            Contacts = contacts;
            Message = message;
        }
    }
}
