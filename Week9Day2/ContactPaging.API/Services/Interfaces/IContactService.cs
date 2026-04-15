using ContactPaging.API.DTOs;
using ContactPaging.API.Models;

namespace ContactPaging.API.Services.Interfaces
{
    public interface IContactService
    {
        Task<PagedResponse<Contact>> GetPagedContactsAsync(int pageNumber, int pageSize);
    }
}