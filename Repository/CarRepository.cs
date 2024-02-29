using Microsoft.EntityFrameworkCore;
using MVCAssign1.Models;

namespace MVCAssign1.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly CarContext _carContext;

        public CarRepository(CarContext carContext)
        {
            _carContext = carContext;
        }

        public bool Add(Car car)
        {
            _carContext.Cars.Add(car);
            return Save();
        }

        public bool Delete(Car car)
        {
           _carContext.Cars.Remove(car);
            return Save();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _carContext.Cars.ToListAsync();
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _carContext.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _carContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
