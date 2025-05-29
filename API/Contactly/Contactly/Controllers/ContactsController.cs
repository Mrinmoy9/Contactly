using Contactly.Data;
using Contactly.Models;
using Contactly.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Contactly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactlyDbContext dbContext;

        public ContactsController(ContactlyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllContacts()
        {
            var contacts = dbContext.contacts.ToList();
            return Ok(contacts);
        }

        [HttpGet("{name}")] 
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactsByName(string name) 
        {
            
            var contacts = await dbContext.contacts
                                          .Where(x => x.Name.ToLower().Contains(name.ToLower())) 
                                          .ToListAsync();

            
            return Ok(contacts); 
        }

    


        [HttpPost]
        public IActionResult AddContact(AddContactRequestDTO request)
        {
            var domainModelContact = new Contact
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                Favorite = request.Favorite
            };

            dbContext.contacts.Add(domainModelContact);
            dbContext.SaveChanges();
            return Ok(domainModelContact);
        }


        [HttpPut("{id:guid}")]
        public IActionResult UpdateContact(Guid id,[FromBody]UpdateContactRequestDTO request)
        {
            var contact= dbContext.contacts.Find(id);
            if (contact is not null)
            {
                contact.Name = request.Name;
                contact.Email = request.Email;
                contact.Phone = request.Phone;
                contact.Favorite = request.Favorite;
                dbContext.SaveChanges();
            }
            return Ok(contact);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteContact(Guid id) 
        {
            var contact= dbContext.contacts.Find(id);
            if (contact is not null)
            {
                dbContext.contacts.Remove(contact);
                dbContext.SaveChanges();
                
            }
            return Ok(contact);
        }

        

       




    }
}
