using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Angular17WithASP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly IContactService _articleService;
        
        public ContactController(IContactService contactService, ILogger<ContactController> logger)
        {
            
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _articleService.GetAllAsync();

            return Ok(contacts);
        }
    }
}