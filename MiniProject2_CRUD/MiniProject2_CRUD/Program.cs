using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Net;

namespace MiniProject2_CRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = CommounFunctions.ConvertToLocalMonyFromNet(50);
            Console.WriteLine("This line for testing purpose 50 dollar = " + test);

            //variable
            bool moreProduct = true;
            List<Product> products = new List<Product>(); // product list with type product

            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("Add a product and Print all the product by typing 'q' in the name input field!\n");


            try // try this code 
            {
                while (moreProduct)
                {

                    MainFuntions.AskForType(products);

                    Console.WriteLine("--------------------------------------------------------\n");

                    MainFuntions.PrintProducts(products); // print the list of product that the user selcet

                    Console.WriteLine("--------------------------------------------------------");
                    moreProduct = CommounFunctions.AskIfMore(); // ask if the customer need more product to add
                }
            }
            catch (Exception e1) // the exception message 
            {
                Console.WriteLine(e1); // print error handling code
            }
            finally //this code will always be printed
            {
                Console.WriteLine("\n--------------------------------------------------------");
                Console.WriteLine("Press any key to close the window . . .");
                Console.ReadKey(); // break point
            }
        }
    }



}
