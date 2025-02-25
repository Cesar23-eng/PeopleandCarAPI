using PeopleAPI.Models;

namespace PeopleAPI.Data;

public class InMemoryCarRepository : ICarRepository
{
    private readonly List<Car> _car = [];
    private int _carId = 1;
    public Task<List<Car>> GetAllAsync()
    {
        return Task.FromResult(_car);
    }

    public Task<Car?> GetByIdAsync(int id)
    {
        var car = _car.FirstOrDefault(c => c.Id == id);
        return Task.FromResult(car);
    }

    public Task AddAsync(Car car)
    {
        car.Id = _carId;
        _carId++;
        _car.Add(car);
        return Task.CompletedTask;
    }

    public Task UpdateAsync(Car car)
    {
        var existingCar = _car.FirstOrDefault(c => c.Id == car.Id);
        if (existingCar == null)
        {
            return Task.CompletedTask;
        }
        
        existingCar.NameCar = car.NameCar;
        existingCar.ColorCar = car.ColorCar;
        existingCar.DateCar = car.DateCar;
        
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        _car.RemoveAll(c => c.Id == id);
        return Task.CompletedTask;
        
    }
}