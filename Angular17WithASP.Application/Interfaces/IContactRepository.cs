using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angular17WithASP.Application.DTOs;
using Angular17WithASP.Core.Entities;
using Task = System.Threading.Tasks.Task;

namespace Angular17WithASP.Application.Interfaces
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAllContactsAsync();
        Task<string> GetContactByIdAsJSONAsync(int id);
        Task<IReadOnlyCollection<OpportunityDTO>> GetOpportunitiesForContactAsync(int contactId);
    }
}
