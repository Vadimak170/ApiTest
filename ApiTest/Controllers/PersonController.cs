using Core.Domains.Models;
using Core.Domains.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTest.Controllers;
[Route("person")]
public class PersonController : Controller
{
   private IPersonService _personService;

   public PersonController(IPersonService personService)
   {
      _personService = personService;
   }

   [HttpGet]
   public List<Person> Get()
   {
      return _personService.GetAll();
   }

   [HttpGet("{id}")]
   public Person GetById(Guid id)
   {
      return _personService.GetById(id);
   }

   [HttpPost]
   public IActionResult Add(PersonCreateModel person)
   {
      var personEntity = new Person()
      {
         Id = Guid.NewGuid(),
         Age = person.Age,
         Name = person.Name,
         Phone = person.Phone
      };
      _personService.Add(personEntity);
      return Ok();
   }

   [HttpDelete("{id}")]
   public IActionResult Delete(Guid id)
   {
      _personService.Delete(id);
      return Ok();
   }
}