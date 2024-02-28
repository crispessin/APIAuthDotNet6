using Domain.Entities;
using Domain.FiltersDb;

namespace Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetPeopleAsync();
        Task<Person> CreatAsync(Person person);
        Task EditAsync(Person person);
        Task DeleteAsync(Person person);
        Task<int>GetIdByDocumentAsync(string document);
        Task<PageBaseResponse<Person>> GetPageAsync(PersonFilterDB request);
    }
}
