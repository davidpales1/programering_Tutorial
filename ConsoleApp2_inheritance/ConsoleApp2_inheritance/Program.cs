using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2_inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Vehicle car1 = new Vehicle("volvo", "23 fd");
            Car car2 = new Car("firare", "23 fd", 5);
            Vehicle car3= new Car("tesla", "23 fd", 5);
            Vehicle MotorCycle = new MotorCycle("motor volvi", "423 ffdghd");

            //Vehicle car4= new Vehicle();
            List<Vehicle> vehicles =new List<Vehicle>();
            vehicles.Add(car1);
            vehicles.Add(car2);
            vehicles.Add(car3);
            vehicles.Add(MotorCycle);
            List<Vehicle> sortedVehicles = vehicles.OrderBy(vehicles=> vehicles.GetType()).ThenBy(vehicles => vehicles.Brand).ToList();
            Console.WriteLine("Brand " + "Model " + "Extra Info " + "Vehicle Type");
            Console.WriteLine("==================================================");

            foreach (Vehicle vehicle in sortedVehicles)
            {
                Console.WriteLine(vehicle.Brand + " " + vehicle.Model + " " + vehicle.GetExtraInfo() + " " + vehicle.GetType());

                //if(Vehicle is Car)
                //   {
                //     Console.WriteLine(vehicle.Brand +""+ (Vehicle as Car).NumbersOfDors);
                // }
            }
            Console.ReadLine();
        }
        class Vehicle
        {
            public Vehicle(string brand, string model)
            {
                this.Brand = brand;
                this.Model = model;
            }
            public string Brand { get; set; }
            public string Model { get; set; }
            public virtual string GetExtraInfo()
            {
                return "";
            }
            public virtual string GetType()
            {
                return "Vehicle";
            }
        }
        class Car : Vehicle
        {
            public Car(string brand, string model, int numbersOfDors) : base(brand, model)
            {
                NumbersOfDors = numbersOfDors;
            }
            public int NumbersOfDors { get; set; }
            public override string GetExtraInfo()
            {
                return "" + NumbersOfDors;
            }
            public override string GetType()
            {
                return "Car";
            }

        }
        class MotorCycle : Vehicle
        {
            public MotorCycle(string brand, string model) : base(brand, model)
            {

            }
            public override string GetType()
            {
                return "MotorCycle";
            }
        }

    }
}
