using Core.Domains.Models;

namespace Core.Domains.Repositories;

public interface IPersonRepository
{
    public List<Person> GetAll();
    public Person GetById(Guid id);
    public void Add(Person person);
    public void Delete(Guid id);

}