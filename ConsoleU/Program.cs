using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.Entity_Framework;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //BrandList();

            RentCarTest();

        }

        private static void RentCarTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            CarManager carManager = new CarManager(new EfCarDal());
            string kontrol = "";

            foreach (var rental in carManager.GetAll().Data)
            {
                var selectedCar = rentalManager.Add(new Rental { CarId = rental.CarId, CustomerId = 3, RentDate = "26.02.2021" });
                if (selectedCar.Success == true)
                {
                    //döngüyü bitir
                    kontrol = "araç bulundu";
                    Console.WriteLine(selectedCar.Message);
                    break;

                }
            }

            if (kontrol == "") { Console.WriteLine("boşta araç bulunmadı"); }
        }

        private static void BrandList()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result1 = brandManager.GetAll();
            if (result1.Success==true)
            {
                foreach (var brand in result1.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result1.Message);
            }
           
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " - " + car.BrandName + " - " + car.ColorName + " - " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
            
            
        }
    }
}
