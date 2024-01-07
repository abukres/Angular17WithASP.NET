using Angular17WithASP.Core.Entities;

namespace Angular17WithASP.Application.Interfaces
{
public interface IContactService
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<string> GetContactByIdAsJSONAsync(int id);
    }
}
