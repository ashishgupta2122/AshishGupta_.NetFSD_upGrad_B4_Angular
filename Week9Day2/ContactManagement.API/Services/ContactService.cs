using ContactManagement.API.Models;
using ContactManagement.API.Repositories.Interfaces;
using ContactManagement.API.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace ContactManagement.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;
        private readonly IMemoryCache _cache;

        public ContactService(IContactRepository repository, IMemoryCache cache)
        {
            _repository = repository;
            _cache = cache;
        }

        public List<Contact> GetAllContacts()
        {
            string cacheKey = "contactList";

            if (!_cache.TryGetValue(cacheKey, out List<Contact> contacts))
            {
                contacts = _repository.GetAll();

                var options = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                _cache.Set(cacheKey, contacts, options);

                Console.WriteLine("Stored in CACHE");
            }
            else
            {
                Console.WriteLine("Fetching from CACHE");
            }

            return contacts;
        }

        public Contact GetContactById(int id)
        {
            string cacheKey = $"contact_{id}";

            if (!_cache.TryGetValue(cacheKey, out Contact contact))
            {
                contact = _repository.GetById(id);

                if (contact != null)
                {
                    var options = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60));

                    _cache.Set(cacheKey, contact, options);
                }

                Console.WriteLine("Stored in CACHE");
            }
            else
            {
                Console.WriteLine("Fetching from CACHE");
            }

            return contact;
        }
    }
}