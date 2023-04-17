using Core.Domains.Models;
using Core.Domains.Repositories;

namespace Core.Domains.Services;

public interface IPersonService
{
    
    public List<Person> GetAll();
    public Person GetById(Guid id);
    public void Add(Person person);
    public void Delete(Guid id);
}

public class PersonService: IPersonService
{
    private IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public List<Person> GetAll()
    {
        return _personRepository.GetAll();
    }

    public Person GetById(Guid id)
    {
        return _personRepository.GetById(id);
    }

    public void Add(Person person)
    {
        _personRepository.Add(person);
    }

    public void Delete(Guid id)
    {
        _personRepository.Delete(id);
    }
}