using MVCAssign1.Models;

namespace MVCAssign1.Repository
{
    public interface ICarRepository
    {
       Task<IEnumerable<Car>> GetAll(); 
       Task<Car> GetCarById(int id);

        bool Add(Car car);

        bool Delete(Car car);
        bool Save();
    }
}
