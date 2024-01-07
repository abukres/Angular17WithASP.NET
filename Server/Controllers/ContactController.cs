using Angular17WithASP.Application.Interfaces;
using Angular17WithASP.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace a_Angular17WithASP.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            _contactService = contactService;
        }

        [HttpGet("contacts", Name = "Contacts")]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _contactService.GetAllContactsAsync();

            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public async Task<OkObjectResult> GetContactByIdAsJSONAsync(int id)
        {
            var json = await _contactService.GetContactByIdAsJSONAsync(id);

            return Ok(json);
        }
    }
}