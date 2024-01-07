using System.Reflection;
using Angular17WithASP.Application.Interfaces;
using Angular17WithASP.Core.Entities;
using Newtonsoft.Json.Linq;

namespace Angular17WithASP.Application.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task<IEnumerable<Contact>> GetAllContactsAsync()
    {
        return await _contactRepository.GetAllContactsAsync();
    }
    
    public async Task<string> GetContactByIdAsJSONAsync(int id)
    {
        string json = await _contactRepository.GetContactByIdAsJSONAsync(id);
        
        //append the contact's image in the contact json
        string image = GetContactImageAsBase64(id);
JObject jObject = JObject.Parse(json);
jObject["image"] = JToken.FromObject(image);
return jObject.ToString();
    }

    private string GetContactImageAsBase64(int id)
    {
        string currentPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        string imageFilename = @$"{currentPath}\Data\Images\{id}.jpg";
        byte[] imageBytes = File.ReadAllBytes(imageFilename);
        string base64String = Convert.ToBase64String(imageBytes);
        return base64String;
        
    }
}