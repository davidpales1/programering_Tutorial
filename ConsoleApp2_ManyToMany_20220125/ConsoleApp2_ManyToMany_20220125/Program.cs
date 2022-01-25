﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ConsoleApp2_ManyToMany_20220125
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
    // One Owner can have multi Cars
    class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
    class Car
    {
        public int Id { get; set; }
        //public int OwnerId { get; set; }
        public string Name { get; set; }

        //public Owner Owner { get; set; }
        public List<Owner>Owner { get; set; }

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