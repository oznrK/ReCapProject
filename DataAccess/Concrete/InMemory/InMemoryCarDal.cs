using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> { 
                new Car{CarId=1, BrandId=1, CarName="Renoult", ColorId=1, DailyPrice=150, Description="yeni araç", ModelYear=2020},
                new Car{CarId=2, BrandId=2, CarName="Pegeout", ColorId=2, DailyPrice=250, Description="eski araç", ModelYear=2000},
                new Car{CarId=3, BrandId=3, CarName="Mercedes", ColorId=2, DailyPrice=300, Description="eski model araç", ModelYear=2000},
                new Car{CarId=4, BrandId=2, CarName="Fiat", ColorId=3, DailyPrice=150, Description="yeni model", ModelYear=2021}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c =>c.CarId == car.CarId);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _cars.Where(c => c.ColorId == colorId).ToList(); //where=>içindeki şarta uyan bütün elemanları yeni bir liste haline getirip onu döndürür. 
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.CarName = car.CarName;
            carToUpdate.CarId = car.CarId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.BrandId = car.BrandId;
            
        }
    }
}
