using System;
namespace imout.Core.Model
{
    public class Contact
    {
        private string Name { get; set; }
        private string PhoneNumber { get; set; }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            phoneNumber = phoneNumber;
        }
    }
}
