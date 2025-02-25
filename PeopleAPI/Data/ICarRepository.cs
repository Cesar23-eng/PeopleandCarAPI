using PeopleAPI.Models;

namespace PeopleAPI.Data;

public interface ICarRepository
{
    Task<List<Car>> GetAllAsync();
    Task<Car?> GetByIdAsync(int id);
    Task AddAsync(Car car);
    Task UpdateAsync(Car car);
    Task DeleteAsync(int id);
}