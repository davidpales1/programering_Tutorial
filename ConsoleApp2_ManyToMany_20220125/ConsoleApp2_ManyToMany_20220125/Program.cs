using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2_ManyToMany_20220125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleContext db = new VehicleContext();

            Console.WriteLine("Hello World!");
            Owner owner1 = new Owner("Jihad");
            Owner owner2 = new Owner("Mats");

            Car car1 = new Car("Jihad");
            Car car2 = new Car("Mats");
            owner1.Cars.Add(car1);
            owner2.Cars.Add(car2);

            db.Owners.Add(owner1);
            db.Owners.AddRange(owner1, owner2);
            db.SaveChanges();

            List<Owner> owners = db.Owners.Include("Cars").ToList();
            List<Owner> owners2 = db.Owners.Include(owner => owner.Cars).ToList();


        }
    }
    // One Owner can have multi Cars
    class Owner
    {
        public Owner(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
    class Car
    {
        public Car(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        //public int OwnerId { get; set; }
        public string Name { get; set; }

        //public Owner Owner { get; set; }
        public List<Owner>Owner { get; set; } = new List<Owner>();

    }
    class VehicleContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ManyToMany;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
