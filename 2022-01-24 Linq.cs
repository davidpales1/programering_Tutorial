using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp_EF_Linq_20220124
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Linq!");

            //LINQ
            //Language INtegrated Query
            //LINQ Syntaxes
            //1. Query Syntax or Query Expression Syntax
            //2. Method Syntax or Method Expression Syntax or Fluent Syntax

            string[] cars = new string[]
            {
                "Volvo", "Saab", "Volvo", "Opel"
            };

            //Counting number of Volvos in string array with a for loop
            int counter = 0;
            for (int i = 0; i < cars.Length; i++)
            {
                if(cars[i] == "Volvo")
                {
                    counter++;
                }
            }

            //Counting number of Volvos in string array with LINQ
            //Method Syntax
            int volvosLinqM = cars.Where(car => car == "Volvo").Count();
            //Query Syntax
            int volvosLinqQ = (from car in cars where car == "Volvo" select car).Count();

            //Sorting string array with LINQ
            //Method Syntax
            string[] sortedLinqM = cars.OrderBy(car => car).ToArray();
            //Query Syntax
            string[] sortedLinqQ = (from car in cars orderby car select car).ToArray();
            Console.ReadLine();
        }
    }
}
