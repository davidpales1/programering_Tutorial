using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace MiniProject2_CRUD
{
    internal class MainFuntions
    {
        public static void AskForType(ProductContext db)
        {

            while (true)
            {
                Console.WriteLine("----");
                Console.WriteLine("We have two type of product in our store('Mobile' or 'Laptop'):");
                string productType = Console.ReadLine(); // get the name
                productType = productType.ToLower().Trim();

                if (CommounFunctions.IsQuit(productType)) { break; } // check if the input == quit
                if (CommounFunctions.IsEmpty(productType)) { continue; } // check if the input == ""
                if (productType == "mobile") // check if product Type is a mobile
                {
                    string result = Add.AskTheCustomer(db, "mobile"); // ask the custome about which product to add 
                    if (result == "q") { break; } // check if the input == quit
                    if (result == "cancel") { continue; } // check if the input == quit
                    if (result == "add") { continue; } // check if the input == quit
                }

                else if (productType == "laptop") // check if product Type is a laptop
                {
                    string result = Add.AskTheCustomer(db, "laptop"); //ask the customer
                    if (result == "q") { break; } // check if the input == quit
                    if (result == "cancel") { continue; } // check if the input == quit
                    if (result == "add") { continue; } // check if the input == quit
                }

                else { Console.WriteLine("Input one of the two product 'Mobile' or 'Laptop':"); continue; } // check if the input == ""
                //CommounFunctions.addProduct(products, productName, productCategory, int.Parse(productPrice));
            }

        }



        public static void PrintProducts(ProductContext db)
        {

            Console.WriteLine("You specified the following products (sorted by type then by date):");
            Console.WriteLine("Id".PadRight(20)
                + "Name".PadRight(20)
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(20)
                + "Model".PadRight(20)
                + "EL Type".PadRight(20)
                + "Extra Info".PadRight(20));

            //where product.Type == "Volvo"
            List<Product> sortedProducts = (from product in db.Products orderby product.Discriminator orderby product.Date   select product).ToList();
            // List<Product> sortedProducts = db.Products.OrderBy(product => product.GetType().Name)
            //.ThenBy(product => product.Date).ToList();
            foreach (Product product in sortedProducts) // loop through the array
            {
                string priceInSEK = CommounFunctions.ConvertToLocalMonyFromNet(product.Price);

                TimeSpan expireDate = DateTime.Now - product.Date;
                int expireDateInDays = (int)expireDate.TotalDays;

                if (93 + expireDateInDays >= 1095)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                }
                else if (186 + expireDateInDays >= 1095)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }

                if (product is Laptop)
                {


                    Console.WriteLine(product.Id.ToString().PadRight(20)
                        + product.Name.PadRight(20)
                        + product.Brand.PadRight(20)
                        + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                        + product.AddDate.ToString("yyyy-MM-dd").PadRight(20)
                        + priceInSEK.PadRight(20)
                    + (product as Laptop).Model.PadRight(20)
                    + (product as Laptop).Type.PadRight(20)
                    + (product as Laptop).GetExtraInfo().PadRight(20)
);
                }
                else if (product is Mobile)
                {
                    Console.WriteLine(product.Id.ToString().PadRight(20)
                        + product.Name.PadRight(20)
                        + product.Brand.PadRight(20)
                        + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                        + product.AddDate.ToString("yyyy-MM-dd").PadRight(20)
                        + priceInSEK.PadRight(20)
                        + (product as Mobile).Model.PadRight(20)
                        + (product as Mobile).Type.PadRight(20)
                        + (product as Mobile).GetExtraInfo().PadRight(20));
                }

                Console.ResetColor();

            }
            if (sortedProducts.Count > 0)
            {
                ReportingFuntion(sortedProducts);

            }

        }
        public static void ReportingFuntion(List<Product> sortedProducts)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nThe number of products is:" + sortedProducts.Count());

            Product lastProduct = sortedProducts[sortedProducts.Count() - 1];
            Product firstProduct = sortedProducts[0];

            Console.WriteLine($"\n{lastProduct.Name} is last product thats going to expire.");
            Console.WriteLine($"\n{firstProduct.Name} is the first product thats going to expire.");

            Console.ResetColor();

        }

        public static bool AskIfMore(ProductContext db)
        {
            while (true)
            {
                Console.WriteLine("----");
                Console.WriteLine("Type one of the folloing latter to continue?");
                Console.WriteLine("A) Add a product");
                Console.WriteLine("B) Edit one product");
                Console.WriteLine("C) Delete one product");
                Console.WriteLine("Q) Print the products");
                Console.WriteLine("S) Search the products('Under Development')");
                Console.WriteLine("E) Exit the app");

                ConsoleKey command = Console.ReadKey(true).Key;

                if (command == ConsoleKey.A)
                {
                    MainFuntions.AskForType(db);
                    return true;
                }
                if (command == ConsoleKey.B)
                {
                    Console.WriteLine("Enter the id of the product:");
                    string id = Console.ReadLine();
                    Update.AskTheCustomer(db, int.Parse(id));
                }
                if (command == ConsoleKey.C)
                {
                    Console.WriteLine("Enter the id of the product:");
                    string id = Console.ReadLine();
                    Delete.DeleteProduct(db, int.Parse(id));
                }
                if (command == ConsoleKey.Q)
                {
                    MainFuntions.PrintProducts(db);
                }
                if (command == ConsoleKey.E)
                {
                    return false;
                }
            }
        }
    }
}
