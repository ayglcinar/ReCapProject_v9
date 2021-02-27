using System;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarAddTest();            
            //DetailsTest();
            //UserAddTest();
            //CustomerAddTest();

            RentalAddTest();

        }

        private static void RentalAddTest()
        {
            Rental rental1 = new Rental { CarID = 1, CustomerID = 2, RentDate = DateTime.Now };
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            rentalManager.Add(rental1);
        }

        private static void CustomerAddTest()
        {
            Customer customer1 = new Customer { CustomerID = 2, CompanyName = "XXX" };

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer1);


        }

        private static void UserAddTest()
        {
            User user1 = new User { FirstName = "Aygul", LastName = "Cinar", Password = "ac123", Email = "aygl.cinar@gmail.com" };

            UserManager userManager = new UserManager(new EfUserDal());

            userManager.Add(user1);
        }

        private static void DetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.CarName + " | " + car.BrandName + " | " + car.ColorName + " | " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }



        private static void CarAddTest()
        {
            //Araba tanımla
            Car car1 = new Car { ID = 3, BrandID = 1, ColorID = 2, DailyPrice = 500, Description = "Benzinli", ModelYear = "2010" };

            CarManager carManager = new CarManager(new EfCarDal());
            //Yeni araba ekle
            carManager.Add(car1);


        }

    }

