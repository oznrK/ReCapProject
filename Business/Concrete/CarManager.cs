using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araba eklendi");
            }
            else
            {
                Console.WriteLine("Araba ekleme başarısız. Günlük fiyatı 0'dan büyük giriniz.");
            }
        }

        public void Delete(Car car)
        {
            try
            {
                _carDal.Delete(car);
                Console.WriteLine("Araba silindi.");
            }
            catch (ArgumentNullException)
            {

                Console.WriteLine("Araba bulunamadı.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();

        }


        public Car GetByBrandId(int brandId)
        {
            return _carDal.Get(b=>b.BrandId == brandId);
        }

        public Car GetByColorId(int colorId)
        {
            return _carDal.Get(c => c.ColorId == colorId);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            if (car.DailyPrice>0)
            {
                _carDal.Update(car);
                Console.WriteLine("Araba güncellendi");
            }
            else
            {
                Console.WriteLine("Araba güncelleme başarısız. Lütfen GünlükFiyat değerini 0'dan büyük giriniz");
            }
        }
    }
}
