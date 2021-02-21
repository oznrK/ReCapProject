using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName+" = "+ car.DailyPrice);
                
            }
            carManager.Add(new Car { CarId = 5, BrandId = 6, BrandName = "Audi", ColorId = 2, DailyPrice = 150, ModelYear = 2020, CarName = "A5", Description = " otomatik vites" });
            
        }
    }
}
