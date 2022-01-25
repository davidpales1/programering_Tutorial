using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ConsoleApp2_EF_Annotation_FloabtAPI
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
            Car carUpdate = db.Cars.Where(car => car.MySpecialId == 2).FirstOrDefault();
            carUpdate.Model = "900 Turbo";
            carUpdate.Speed = 150;
            db.Cars.Update(carUpdate);
            db.SaveChanges();

            // delete from db
            Car carDelete = db.Cars.Where(car => car.MySpecialId == 2).FirstOrDefault();
            db.Cars.Remove(carDelete);
            db.SaveChanges();




            //Company companyRead = db.Companies.Find(1);
            Company companyReadInclude = db.Companies
                .Include(co => co.Cars)
                .Include(co => co.Motorcycles)
                .Where(company => company.Id == 1).
                FirstOrDefault();

            Car carRead = db.Cars.Where(car => car.MySpecialId == 1).FirstOrDefault();
            Company company2 = db.Companies.Where(company => company.Id == carRead.MySpecialId).FirstOrDefault();
            Company company3 = carRead.Company;



            // LINQ
            //Method Syntax
            int volvosDbLinqM = db.Cars.Where(car => car.Brand == "Volvo").Count();
            //Query Syntax
            int volvosDbLinqQ = (from car in db.Cars where car.Brand == "Volvo" select car).Count();
        }
    }
    [Table("CarsDA")]
    class Car
    {
        public Car(string brand, string model, int year, int speed)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Speed = speed;
        }
        [Key]
        public int MySpecialId { get; set; }

        public string Brand { get; set; }
        [Column("ModelDA")]
        public string Model { get; set; }

        public int Year { get; set; }
        public int Speed { get; set; }
        public Company Company { get; set; }

    }
    class Company
    {
        public Company(string name)
        {
            Name = name;
            Cars = new List<Car>();
            Motorcycles = new List<Motorcycle>();
        }

        public int Id { get; set; }
        //[Key]
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
        public List<Motorcycle> Motorcycles { get; set; }
    }
    class Motorcycle : Car
    {
        public Motorcycle(string brand, string model, int year, int speed) : base(brand, model, year, speed)
        {
        }
    }
    class VehicleContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Car> Motorcycle { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Cars_01_25;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>entity.HasKey(e=> e.MySpecialId));
            modelBuilder.Entity<Car>(entity => entity.ToTable("CarTable"));
            modelBuilder.Entity<Car>().Property(p => p.Model).HasColumnName("ModelFluent");

        }
    }
}
