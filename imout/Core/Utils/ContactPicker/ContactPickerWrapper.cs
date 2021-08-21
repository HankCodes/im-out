using System;
using System.Threading.Tasks;

using XamarinContacts = Xamarin.Essentials.Contacts;
using XamarinContact = Xamarin.Essentials.Contact;

using imout.Core.Model;

namespace imout.Core.Utils.ContactPicker
{
    public class ContactPickerWrapper
    {
        public async Task<Contact> PickContactAsync()
        {
            try
            {
                XamarinContact pickedContact = await XamarinContacts.PickContactAsync();

                if (pickedContact is null) throw new Exception("Could not find contact");

                return new Contact(pickedContact.DisplayName, pickedContact.Phones[0].PhoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
