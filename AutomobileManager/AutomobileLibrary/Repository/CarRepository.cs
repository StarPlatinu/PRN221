using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(Car car) => CarDao.Instance.Remove(car);
        public Car GetCarById(int carId) => CarDao.Instance.getCarById(carId);
        public IEnumerable<Car> GetCars() => CarDao.Instance.getCarList();
        public void InsertCar(Car car) => CarDao.Instance.AddNew(car);

        public void UpdateCar(Car car) => CarDao.Instance.Update(car);
    }
}
