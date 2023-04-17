using Core.Domains.Models;
using Core.Domains.Repositories;
using Data.Domains.Models;

namespace Data.Domains.Repositories;

public class PersonRepository: IPersonRepository
{
    public List<PersonContactDbModel> PersonContacts;
    public List<PersonDataDbModel> Persons;

    public PersonRepository()
    {
        PersonContacts = new List<PersonContactDbModel>();
        Persons = new List<PersonDataDbModel>();
    }
    public List<Person> GetAll()
    {
        var persons = new List<Person>();
        foreach (var person in Persons)
        {
            var entityPerson = new Person()
            {
                Id = person.Id,
                Name = person.Name,
                Age = person.Age,
                Phone = PersonContacts.First(it => it.PersonId == person.Id).Phone
            };
            persons.Add(entityPerson);
        }

        return persons;
    }

    public Person GetById(Guid id)
    {
        var personEntity = Persons.First(it => it.Id == id);
        var personContact = PersonContacts.First(it => it.PersonId == id);

        return new Person()
        {
            Id = id,
            Age = personEntity.Age,
            Name = personEntity.Name,
            Phone = personContact.Phone
        };
    }

    public void Add(Person person)
    {
        PersonContacts.Add(new PersonContactDbModel()
        {
            Id = Guid.NewGuid(),
            PersonId = person.Id,
            Phone = person.Phone
        });
        Persons.Add(new PersonDataDbModel()
        {
            Id = person.Id,
            Age = person.Age,
            Name = person.Name
        });
    }

    public void Delete(Guid id)
    {
        var personContact = PersonContacts.First(it => it.PersonId == id);
        PersonContacts.Remove(personContact);
        var personEntity = Persons.First(it => it.Id == id);
        Persons.Remove(personEntity);
        
    }
}