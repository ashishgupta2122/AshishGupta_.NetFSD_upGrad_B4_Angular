using ContactManagement.Core.Entities;
using ContactManagement.Core.Interfaces;

namespace ContactManagement.Infrastructure.Services
{
    public class ContactService : IContactService
    {
        private readonly List<Contact> _contacts = new();
        public void AddContact(Contact contact)
        {
            ValidateContact(contact);
            contact.Id = GenerateId();
            _contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            ValidateContact(contact);
            var existingContact = _contacts.FirstOrDefault(c => c.Id == contact.Id);
            if (existingContact == null)
            {
                throw new Exception("Contact not found.");
            }
            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Phone = contact.Phone;
        }

        public void DeleteContact(int id)
        {
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null)
            {
                throw new Exception("Contact not found.");
            }
            _contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return _contacts;
        }

        private static void ValidateContact(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            if (string.IsNullOrWhiteSpace(contact.Name))
            {
                throw new ArgumentException("Name is required.");
            }

            if (string.IsNullOrWhiteSpace(contact.Email))
            {
                throw new ArgumentException("Email is required.");
            }

            if (string.IsNullOrWhiteSpace(contact.Phone))
            {
                throw new ArgumentException("Phone is required.");
            }
        }

        public int GenerateId()
        {
            return _contacts.Count > 0 ? _contacts.Max(c => c.Id) + 1 : 1;
        }
    }
}