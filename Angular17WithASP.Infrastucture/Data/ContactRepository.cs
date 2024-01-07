using System.Threading;
using Angular17WithASP.Application.DTOs;
using Angular17WithASP.Application.Interfaces;
using Angular17WithASP.Core.Entities;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Angular17WithASP.Infrastucture.Data
{
    public class ContactRepository : IContactRepository
    {
        private readonly DXFullAppContext _dbContext;
        private readonly IMapper _mapper;

        public ContactRepository(DXFullAppContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _dbContext.Contacts.AsNoTracking()
                .Select(c => new Contact
                {
                    Id = c.Id,
                    Name = c.Name,
                    AssignedTo = c.AssignedTo,
                    Company = c.Company,
                    Email = c.Email,
                    Phone = c.Phone,
                    Position = c.Position,
                    Status = c.Status,
                    Image = c.Image
                }).ToListAsync();
        }


        //TODO: refactor this to use a DTO. For now, it's returning a json string with everything
        public async Task<string> GetContactByIdAsJSONAsync(int id)
        {
            var contact = await _dbContext.Contacts.Where(c => c.Id == id).Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.FirstName,
                    c.LastName,
                    c.City,
                    State = new
                    {
                        SateId = c.State.StateId,
                        StateShort = c.State.StateShort,
                        StateLong = c.State.StateLong,
                        StateCoords = c.State.StateCoords,
                        Flag48px = c.State.Flag48px,
                        Flag24px = c.State.Flag24px,
                        SsmaTimeStamp = BitConverter.ToString(c.State.SsmaTimeStamp),
                        Contacts = new string[0]
                    },
                    ZipCode = c.ZipCode,
                    Status = c.Status,
                    Company = c.Company,
                    Position = c.Position,
                    Manager = c.AssignedTo,
                    Phone = c.Phone,
                    Email = c.Email,
                    Address = c.Address,
                    activities = c.Activities.Select(a => new
                    {
                        name = a.Name,
                        date = a.Date,
                        manager = c.AssignedTo
                    }).ToList(),
                    Opportunities = c.Opportunities.Select(o => new
                    {
                        name = o.Name,
                        price = o.Price
                    }).ToList(),
                    Tasks = c.Tasks.Select(t => new
                    {
                        text = t.Text,
                        date = t.Date,
                        status = t.Status,
                        priority = t.Priority,
                        manager = c.AssignedTo
                    }).ToList(),
                }
            ).FirstOrDefaultAsync();


            string json = JsonConvert.SerializeObject(contact, Newtonsoft.Json.Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver()
                });

            return json;
        }

        public async Task<IReadOnlyCollection<OpportunityDTO>> GetOpportunitiesForContactAsync(int contactId)
        {
            var opportunityList = await _dbContext.Opportunities
                .Where(o => o.ContactId == contactId)
                .AsNoTracking()
                .ProjectTo<OpportunityDTO>(_mapper.ConfigurationProvider)
                .OrderBy(o => o.Name)
                .ToListAsync();

            return opportunityList;


        }
    }
}
