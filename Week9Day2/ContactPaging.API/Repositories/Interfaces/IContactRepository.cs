using ContactPaging.API.Models;

namespace ContactPaging.API.Repositories.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetPagedAsync(int skip, int take);
        Task<int> GetTotalCountAsync();
    }
}