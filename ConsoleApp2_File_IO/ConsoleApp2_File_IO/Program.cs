using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp2_File_IO
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("File IO!");
            string currentDir = Environment.CurrentDirectory;
            Console.WriteLine(currentDir);
            File.WriteAllText("newfile.txt","Hello world" +Environment.NewLine); // Re Writing the file
            bool exitt = File.Exists("newfile.txt");
            string readFile = File.ReadAllText("newfile.txt");
            List<string> fileData = File.ReadLines("newfile.txt").ToList();
            using (StreamWriter sw = File.CreateText("myFile2.txt"))
            {
                sw.WriteLine("sdfdsf write to file");

            }
            using (StreamReader sw = File.OpenText("myFile2.txt"))
            {
                foreach (string line in fileData)
                {
                    Console.WriteLine(line);
                }
                
 

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

            public int Year { get; set; }
            public int Speed { get; set; }
        }
    }
}
