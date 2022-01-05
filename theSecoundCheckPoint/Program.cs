using System;
using System.Collections.Generic;
using System.Linq;

namespace theSecoundCheckPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //variable
            bool moreProduct = true; 
            List<Product> products = new List<Product>(); // product list with type product

            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("Add a product and Print all the product by typing 'q' in the name input field:\n");

        
            try // try this code 
            {
                while (moreProduct)
                {
                    commounFunctions.askTheCustomer(products); // ask the custome about which product to add 

                    Console.WriteLine("--------------------------------------------------------\n");

                    commounFunctions.printProducts(products); // print the list of product that the user selcet

                    // Add a Search function making it possible to search for products in presented list
                    // color the search

                    Console.WriteLine("--------------------------------------------------------");
                    commounFunctions.searchProducts(products); // ask if the customer need more product to add
                    
                    Console.WriteLine("--------------------------------------------------------");
                    moreProduct = commounFunctions.askIfMore(); // ask if the customer need more product to add
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

        class commounFunctions
        {
            public static void askTheCustomer(List<Product> products)
            {
                while (true)
                {
                    Console.WriteLine("----");
                    Console.WriteLine("Input the name of the product:");
                    string productName = Console.ReadLine(); // get the name
                    if (commounFunctions.isQuit(productName)) { break; } // check if the input == quit
                    if (commounFunctions.isEmpty(productName)) { continue; } // check if the input == ""
                    Console.WriteLine("Input the category of the product:");
                    string productCategory = Console.ReadLine(); // get the category of the product
                    if (commounFunctions.isQuit(productCategory)) { break; } // check if the input == quit
                    if (commounFunctions.isEmpty(productCategory)) { continue; } // check if the input == ""

                    Console.WriteLine("Input the price of the product:");
                    string productPrice = Console.ReadLine(); // get the price
                    if (commounFunctions.isQuit(productPrice)) { break; } // check if the input == quit
                    if (commounFunctions.isEmpty(productPrice)) { continue; } // check if the input == ""
                    if (commounFunctions.isString(productPrice)) { continue; } // check if the input == ""

                    commounFunctions.addProduct(products,productName, productCategory, int.Parse(productPrice));


                }
            }
            public static void addProduct(List<Product> products, string productName, string productCategory, int productPrice)
            {
                Product product = new Product(productName, productCategory, productPrice);
                products.Add(product);

                Console.WriteLine("\n----");
                Console.WriteLine("You added the following product:");
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("".PadRight(10) + "Name: " + product.Name.PadRight(10)
                    + "Category: " + product.Category.PadRight(10)
                    + "Price: " + product.Price.ToString().PadRight(10));
                Console.ResetColor();

            }

            public static void printProducts(List<Product> products)
            {

                Console.WriteLine("You specified the following products (sorted by price by using LinQ):");

                Console.WriteLine("".PadRight(10) + "Product".PadRight(10) + "Category".PadRight(10) + "Price".PadRight(10));

                //List<Product> sortedProducts = products.OrderBy(product => product.Price).ToList();
                List<Product> sortedProductsByUsingLinQ = (List<Product>)(from product in products
                                                                                    orderby product.Price ascending
                                                                                    select product).ToList();
                int calculatedPrice = 0;
                foreach (Product product in sortedProductsByUsingLinQ) // loop through the array
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("".PadRight(10) + product.Name.PadRight(10) + product.Category.PadRight(10) + product.Price.ToString().PadRight(10));
                    Console.ResetColor();
                    calculatedPrice += product.Price;

                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The number of products is:" + products.Count());
                Console.WriteLine("The calculated price of each product is:" + calculatedPrice + "\n");
                Console.ResetColor();

            }
            public static void searchProducts(List<Product> products)
            {
                while (true)
                {
                    Console.WriteLine("search for product by the name and type 'q' to quit the search:\n");
                    string searchWord = Console.ReadLine(); // get the name
                    if (commounFunctions.isQuit(searchWord)) { break; } // check if the input == quit
                    if (commounFunctions.isEmpty(searchWord)) { continue; } // check if the input == ""

                    Console.WriteLine("".PadRight(10) + "Product".PadRight(10) + "Category".PadRight(10) + "Price".PadRight(10));

                    List<Product> sortedProducts = products.OrderBy(product => product.Price).ToList();

                    List<Product> filteredProducts = sortedProducts.Where(product => product.Name.Contains(searchWord)).ToList();

                    Console.WriteLine("This is is a normal filtered and searched products\n");

                    foreach (Product product in filteredProducts) // loop through the array
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("".PadRight(10) + product.Name.PadRight(10) + product.Category.PadRight(10) + product.Price.ToString().PadRight(10));
                            Console.ResetColor();
                        }

                    Console.WriteLine("This is is a products that filtered and searched by Linq:\n");

                    List<Product> filteredAndOrderProductsByUsingLinQ = (List<Product>)(from product in products
                                                                where product.Name.Contains(searchWord)
                                                                orderby product.Price ascending
                                                                select product).ToList();

                    foreach (Product product in filteredAndOrderProductsByUsingLinQ) // loop through the array
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("".PadRight(10) + product.Name.PadRight(10) + product.Category.PadRight(10) + product.Price.ToString().PadRight(10));
                        Console.ResetColor();
                    }
                }
            }

            public static bool askIfMore()
            {
                while (true) { 
                    Console.WriteLine("Do you want to add more product to the list(yes/no)(y/n):");
                    string answer = Console.ReadLine();
                    answer = answer.Trim().ToLower();

                    if (answer == "yes" || answer == "y") // check if it's q  små bokstäver ska inte spela
                    {
                        return true;
                    }
                
                    else if (answer == "no" || answer == "n")
                    {
                        Console.WriteLine("\n--------------------------------------------------------");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you for your purchase!");
                        Console.ResetColor();
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("You must selct 'yes'/'y' or 'no'/'n':");
                    }
                }
            }
            public static bool isQuit(string inputt)
            {
                //product = product.Trim(); // check if it's exit  små bokstäver ska inte spela
                inputt = inputt.ToLower().Trim(); //check if it's exit  små bokstäver ska inte spela

                if (inputt == "q" || inputt == "quit") // check if it's q  små bokstäver ska inte spela
                {
                    return true;
                }
                else if (inputt == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must not enter an empty value!");
                    Console.ResetColor();
                    return false;
                }
                else
                {
                    return false;
                }
            }
            public static bool isEmpty(string inputt)
            {
                //product = product.Trim(); // check if it's exit  små bokstäver ska inte spela
                inputt = inputt.ToLower().Trim(); //check if it's exit  små bokstäver ska inte spela

                if (inputt == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must not enter an empty value!");
                    Console.ResetColor();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static bool isString(string inputt)
            {
                //product = product.Trim(); // check if it's exit  små bokstäver ska inte spela
                inputt = inputt.ToLower().Trim(); //check if it's exit  små bokstäver ska inte spela
                bool isFirstContainsInt = inputt.Any(char.IsDigit);
                if (isFirstContainsInt)
                {
                    return false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You must enter a number in the price field!");
                    Console.ResetColor();
                    return true;
                }
            }
        }

    class Product
        {
            public Product()
            {
            }
            public Product(string name)
            {
                Name = name;
            }
            public Product(string category, string name)
            {
                this.Category = category;
                Name = name;
            }
            public Product(string category, string name, int price)
            {
                this.Category = category;
                Name = name;
                Price = price;
            }
            public string Category { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
        }

    }
}
