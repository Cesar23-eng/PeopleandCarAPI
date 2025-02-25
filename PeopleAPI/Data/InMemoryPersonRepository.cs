using PeopleAPI.Models;

namespace PeopleAPI.Data;

public class InMemoryPersonRepository: IPersonRepository
{
    private readonly List<Person> _people = [];
    //Id actual eso es current
    private int _currentId = 1;
    
    public Task<List<Person>> GetAllAsync()
    {
        return Task.FromResult(_people);
    }

    public Task<Person?> GetByIdAsync(int id)
    {
        var person = _people.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(person);
    }

    public Task AddAsync(Person person)
    {
        person.Id = _currentId;
        _currentId++;
        _people.Add(person);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Person person)
    {
        var existingUser = _people.FirstOrDefault(p => p.Id == person.Id);
        if (existingUser == null)
        {
            return Task.CompletedTask;
        }
        
        existingUser.FirstName = person.FirstName;
        existingUser.LastName = person.LastName;
        existingUser.DateOfBirth = person.DateOfBirth;
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        _people.RemoveAll(p => p.Id == id);
        return Task.CompletedTask;
    }
}