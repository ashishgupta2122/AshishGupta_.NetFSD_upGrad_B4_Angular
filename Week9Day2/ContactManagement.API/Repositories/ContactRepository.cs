using ContactManagement.API.Models;
using ContactManagement.API.Repositories.Interfaces;

namespace ContactManagement.API.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts;

        public ContactRepository()
        {
            _contacts = new List<Contact>
            {
                new Contact { Id = 1, Name = "Ashish", Email = "ashish@gmail.com" },
                new Contact { Id = 2, Name = "Rahul", Email = "rahul@gmail.com" },
                new Contact { Id = 3, Name = "Kiya", Email = "kiya@gmail.com" }
            };
        }

        public List<Contact> GetAll()
        {
            Console.WriteLine("Fetching from DATABASE...");
            return _contacts;
        }

        public Contact GetById(int id)
        {
            Console.WriteLine("Fetching from DATABASE...");
            return _contacts.FirstOrDefault(x => x.Id == id);
        }
    }
}