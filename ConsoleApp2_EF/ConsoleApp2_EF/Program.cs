using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2_EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            VehicleContext db = new VehicleContext();
            Car car1 = new Car("Volvo", "245 GLT", 1980, 175);
            db.Cars.Add(car1);
            db.SaveChanges();


            // Read from db
            List<Car> carsRead = db.Cars.ToList();

            // update db
            Car carUpdate = db.Cars.Where(car => car.id == 2).FirstOrDefault();
            carUpdate.Model = "900 Turbo";
            carUpdate.Speed = 150;
            db.Cars.Update(carUpdate);
            db.SaveChanges();

            // delete from db
            Car carDelete = db.Cars.Where(car => car.id == 2).FirstOrDefault();
            db.Cars.Remove(carDelete);
            db.SaveChanges();
        }
    }
    class Car
    {
        public Car(string brand, string model, int year, int speed)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Speed = speed;
        }

        public int id { get; set; }

        public string Brand { get; set; }
        public string Model { get; set; }
        
        public int  Year { get; set; }
        public int Speed { get; set; }
    }
    class VehicleContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cars_01_20;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    }
}
