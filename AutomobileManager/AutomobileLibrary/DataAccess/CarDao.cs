using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDao
    {
        //Using singleton patten
        private static  CarDao instance = null;
        private static readonly object instancelock = new object();
        private CarDao() { }
        //--------------------
        public static CarDao Instance
        {
            get {
                lock(instancelock)
                {
                    if(instance == null)
                    {
                        instance = new CarDao();
                    }
                    return instance;
                }
                
               
            }

        }
        //--------------------
        public IEnumerable<Car> getCarList()
        {
            List<Car> list;
            try
            {
                var myStockBD = new MyStockContext();
                list = myStockBD.Cars.ToList();

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        //------------------------
        public Car getCarById(int id) {
            Car car = null;
            try
            {
                var myStockDB = new MyStockContext();
                car = myStockDB.Cars.SingleOrDefault(car => car.CarId== id);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public void AddNew(Car car)
        {
            try
            {
                Car _car = getCarById(car.CarId);
                if(_car == null )
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This car already exist");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Update
        public void Update(Car car)
        {
            try
            {
                Car _car = getCarById(car.CarId);
                if (_car != null)
                {
                    var myStockDB  = new MyStockContext();  
                    myStockDB.Entry<Car>(car).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This car doesn't already exist in the database");
                }
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Remove
        public void Remove(Car car)
        {
            try
            {
                Car _car = getCarById(car.CarId);
                if (_car != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Remove(car);
                    myStockDB.SaveChanges();
                }
                else
                {
                    throw new Exception("This car doesn't already exist in the database");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



    }
}
