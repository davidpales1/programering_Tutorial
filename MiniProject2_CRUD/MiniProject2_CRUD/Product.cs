using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2_CRUD
{
    class Product
    {
        public Product(string name, string brand, DateTime date, int price)
        {
            this.Name = name;
            this.Brand = brand;
            this.Date = date;
            this.Price = price;

            this.AddDate = DateTime.Now;

        }
        public int Id { get; set; }

        public string Name { get; set; }
        public string Discriminator { get; set; }
        public DateTime AddDate = new DateTime();

        public DateTime Date { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public virtual string GetExtraInfo()
        {
            return "";
        }
        public virtual string Type => "The use didn't specify the Type";
    }
    class Laptop : Product
    {

        public Laptop(string name, string brand, DateTime date, int price) : base(name, brand, date, price)
        {
        }
        public Laptop(string name, string brand, DateTime date, int price, string model, string gpuType) : base(name, brand, date, price)
        {
            this.GPUType = gpuType;
            this.Model = model;

        }

        public string GPUType { get; set; }
        public string Model { get; set; }



        public override string GetExtraInfo()
        {
            return "GPU Type:" + GPUType;
        }
        public override string Type => "laptop";

    }
    class Mobile : Product
    {
        public Mobile(string name, string brand, DateTime date, int price) : base(name, brand, date, price)
        {
        }

        public Mobile(string name, string brand, DateTime data, int price, string model, int numberOfCamera) : base(name, brand, data, price)
        {
            this.NumberOfCamera = numberOfCamera;
            this.Model = model;

        }
        public int NumberOfCamera { get; set; }
        public string Model { get; set; }
        public override string Type => "mobile";

        public override string GetExtraInfo() => "Number Of Camera:" + NumberOfCamera;
    }
    class ProductContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Miniproject2_GehadAlSayed;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Laptop> Laptops { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
    }
}
