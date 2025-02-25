using PeopleAPI.Models;

namespace PeopleAPI.Data;

public interface IPersonRepository
{
    //Lectura
    Task<List<Person>> GetAllAsync();
    Task<Person?> GetByIdAsync(int id);
    //Escrutura
    Task AddAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(int id);
}