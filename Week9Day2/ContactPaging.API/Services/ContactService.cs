using ContactPaging.API.DTOs;
using ContactPaging.API.Models;
using ContactPaging.API.Repositories.Interfaces;
using ContactPaging.API.Services.Interfaces;

namespace ContactPaging.API.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<PagedResponse<Contact>> GetPagedContactsAsync(int pageNumber, int pageSize)
        {
            int totalRecords = await _repository.GetTotalCountAsync();
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

            int skip = (pageNumber - 1) * pageSize;

            var data = await _repository.GetPagedAsync(skip, pageSize);

            return new PagedResponse<Contact>
            {
                TotalRecords = totalRecords,
                TotalPages = totalPages,
                CurrentPage = pageNumber,
                PageSize = pageSize,
                Data = data
            };
        }
    }
}