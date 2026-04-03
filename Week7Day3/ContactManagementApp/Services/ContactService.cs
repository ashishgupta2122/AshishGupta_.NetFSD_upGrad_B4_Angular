using ContactManagementApp.Models;

namespace ContactManagementApp.Services
{
    public class ContactService : IContactService
    {
        private static List<ContactInfo> contacts = new List<ContactInfo>();

        public void AddContact(ContactInfo contact)
        {
            contact.ContactId = contacts.Count + 1;
            contacts.Add(contact);
        }

        public List<ContactInfo> GetAllContacts()
        {
            return contacts;
        }

        public ContactInfo GetContactById(int id)
        {
            return contacts.FirstOrDefault(c => c.ContactId == id)!;
        }
    }
}