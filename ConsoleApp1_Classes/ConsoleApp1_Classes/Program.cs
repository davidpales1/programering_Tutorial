using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------------------------------");

            Console.WriteLine("My Cars!");
            Car car1 = new Car();
            car1.Brand = "Volvo";
            car1.Model = "244 GLT";
            Console.WriteLine(car1.Brand + " " + car1.Model);


            Car car2 = new Car("Saab", "900");
            Car car3 = new Car("Tesla", "T1",1996);
            Console.WriteLine(car2.Brand + " " + car2.Model);
            Console.WriteLine("---------------------------------------");
            List<Car> cars = new List<Car>();
            cars.Add(car1);
            cars.Add(car2);
            cars.Add(car3);
            List<Car> extraCars = new List<Car> {
               new Car("Opele", "ascona",1996,4545),
            new Car("Volvo", "64 GLE", 1996, 4545)

        };
            cars.AddRange(extraCars);

            foreach (Car car in cars)
            {
                if (car.Year == 0)
                {
                    Console.WriteLine(car.Brand + " " + car.Model);

                }
                else
                {
                    Console.WriteLine(car.Brand + " " + car.Model + " " + car.Year);

                }
            }
            Console.WriteLine("---------------------------------------");

            int highestSpeed = cars.Max(car => car.Speed);
            double avreageSpeed = cars.Average(car => car.Speed);
            int sumOfAllSpeed = cars.Sum(car => car.Speed);
            int countSpeed = cars.Count();
            int countVolvo = cars.Where(car => car.Brand.Contains("volvo")).Count();

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("My cars - sorted by brand");
            List<Car> sortedCar = cars.OrderBy(car => car.Brand).ToList();

            Console.WriteLine("Brand".PadRight(10) + "Model".PadRight(10) + "Years".PadRight(10) + "Speed".PadRight(10));

            foreach (Car car in sortedCar)
            {
                Console.WriteLine(car.Brand.PadRight(10) + car.Model.PadRight(10) + car.Year.ToString().PadRight(10) + car.Speed.ToString().PadRight(10));
            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("My cars - filtered by the year");
            List<Car> filterdCar = cars.Where(car => car.Year <=  1998 && car.Year >= 1995).ToList();

            Console.WriteLine("Brand".PadRight(10) + "Model".PadRight(10) + "Years".PadRight(10) + "Speed".PadRight(10));

            foreach (Car car in filterdCar)
            {
                Console.WriteLine(car.Brand.PadRight(10) + car.Model.PadRight(10) + car.Year.ToString().PadRight(10) + car.Speed.ToString().PadRight(10));
            }
            Console.ReadLine();


        }
    }
    class Car
    {
        public Car()
        {
        }
        public Car(string brand, string model)
        {
            this.Brand = brand;
            Model = model;
        }
        public Car(string brand, string model, int year)
        {
            this.Brand = brand;
            Model = model;
            Year = year;
        }
        public Car(string brand, string model, int year, int speed)
        {
            this.Brand = brand;
            Model = model;
            Year = year;
            Speed = speed;
        }
        // Properties
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Speed { get; set; }
    }

}
