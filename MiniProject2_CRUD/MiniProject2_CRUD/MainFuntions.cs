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
        public static void AskForType(List<Product> products)
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
                    string result = MainFuntions.AskTheCustomer(products, "mobile"); // ask the custome about which product to add 
                    if (result == "q") { break; } // check if the input == quit
                    if (result == "cancel") { continue; } // check if the input == quit
                    if (result == "add") { continue; } // check if the input == quit
                }

                else if (productType == "laptop") // check if product Type is a laptop
                {
                    string result = MainFuntions.AskTheCustomer(products, "laptop"); //ask the customer
                    if (result == "q") { break; } // check if the input == quit
                    if (result == "cancel") { continue; } // check if the input == quit
                    if (result == "add") { continue; } // check if the input == quit
                }

                else { Console.WriteLine("Input one of the two product 'Mobile' or 'Laptop':"); continue; } // check if the input == ""
                //CommounFunctions.addProduct(products, productName, productCategory, int.Parse(productPrice));
            }

        }
        public static string AskTheCustomer(List<Product> products, string productType)
        {
            Console.WriteLine("----");
            Console.WriteLine("Input the name of the product:");
            string productName = Console.ReadLine(); // get the name
            if (CommounFunctions.IsQuit(productName)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productName)) { return "cancel"; } // check if the input == ""
            Console.WriteLine("Input the Brand of the product:");
            string productBrand = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productBrand)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productBrand)) { return "cancel"; } // check if the input == ""
            Console.WriteLine("Input the Date of the product in this format(yyyy-MM-dd):");
            string productDate = Console.ReadLine(); // get the category of the product

            if (CommounFunctions.IsQuit(productDate)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productDate)) { return "cancel"; } // check if the input == ""



            bool isDateValid = DateTime.TryParseExact(productDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate);
            TimeSpan isExpired = DateTime.Now - resultDate;
            int isExpiredInDays = (int)isExpired.TotalDays;
            if (!isDateValid || isExpiredInDays >= 1095)
            {
                Console.WriteLine("make sure to use the correct format yyyy-MM-dd and make sure the product is not older than 3 years");
                return "cancel";
            } // check if the input is in correct format

            Console.WriteLine("Input the Model of the product:");
            string productModel = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productModel)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productModel)) { return "cancel"; } // check if the input == ""

            Console.WriteLine("Input the price of the product in dollar:");
            string productPrice = Console.ReadLine(); // get the price
            if (CommounFunctions.IsQuit(productPrice)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productPrice)) { return "cancel"; } // check if the input == ""
            if (!productPrice.All(char.IsDigit))
            {
                Console.WriteLine("You must enter a number in the price field!");
                return "cancel";
            } // check if the input == ""

            if (productType == "mobile")
            {
                Console.WriteLine("Input the number of the Camera you want:");
                string cameraNumber = Console.ReadLine(); // get the category of the product
                if (CommounFunctions.IsQuit(cameraNumber)) { return "q"; } // check if the input == quit
                if (CommounFunctions.IsEmpty(cameraNumber)) { return "cancel"; } // check if the input == ""
                if (!cameraNumber.All(char.IsDigit))
                {
                    Console.WriteLine("You must enter a number in the price field!");
                    return "cancel";
                } // check if the input == ""
                MainFuntions.AddMobile(products, productName, productBrand, resultDate, int.Parse(productPrice), productModel, int.Parse(cameraNumber));

            }
            else if (productType == "laptop")
            {
                Console.WriteLine("Input the name of the Gpu type:");
                string GpuType = Console.ReadLine(); // get the category of the product
                if (CommounFunctions.IsQuit(GpuType)) { return "q"; } // check if the input == quit
                if (CommounFunctions.IsEmpty(GpuType)) { return "cancel"; } // check if the input == ""
                MainFuntions.AddLaptop(products, productName, productBrand, resultDate, int.Parse(productPrice), productModel, GpuType);
            }
            return "add";
        }
        public static void AddMobile(List<Product> products, string productName, string productBrand, DateTime productDate, int productPrice, string productModel, int cameraNumber)
        {
            Product product = new Mobile(productName, productBrand, productDate, productPrice, productModel, cameraNumber);
            products.Add(product);
            string priceInSEK = CommounFunctions.ConvertToLocalMonyFromNet(product.Price);

            Console.WriteLine("\n----");
            Console.WriteLine("You added the following mobile:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("".PadRight(20) + "Name".PadRight(20)
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(20)
                + "Model".PadRight(20)
                + "Number Of camera".PadRight(20)
                + "EL Type".PadRight(20));

            Console.WriteLine("".PadRight(20) + product.Name.PadRight(20)
                + product.Brand.PadRight(20)
                + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                + product.AddDate.ToString("yyyy-MM-dd").PadRight(20)
                + priceInSEK.PadRight(20)
            + (product as Mobile).Model.PadRight(20)
            + (product as Mobile).NumberOfCamera.ToString().PadRight(20)
            + (product as Mobile).Type.PadRight(20));
            Console.ResetColor();

        }
        public static void AddLaptop(List<Product> products, string productName, string productBrand, DateTime productDate, int productPrice, string productModel, string GpuType)
        {
            Product product = new Laptop(productName, productBrand, productDate, productPrice, productModel, GpuType);
            string priceInSEK = CommounFunctions.ConvertToLocalMonyFromNet(product.Price);

            products.Add(product);
            Console.WriteLine("\n----");
            Console.WriteLine("You added the following laptop:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("".PadRight(20) + "Name".PadRight(20)
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(20)
                + "Model".PadRight(20)
                + "EL Type".PadRight(20)
                + "Extra Info".PadRight(20));

            Console.WriteLine("".PadRight(20) + product.Name.PadRight(20)
                + product.Brand.PadRight(20)
                + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                + product.AddDate.ToString("yyyy-MM-dd").PadRight(20)
                + priceInSEK.PadRight(20)
            + (product as Laptop).Model.PadRight(20)
            + (product as Laptop).Type.PadRight(20)
            + (product as Laptop).GPUType.PadRight(20));
            Console.ResetColor();
        }

        public static void PrintProducts(List<Product> products)
        {

            Console.WriteLine("You specified the following products (sorted by laptop then by date):");
            Console.WriteLine("".PadRight(20) + "Name".PadRight(20)
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(20)
                + "Model".PadRight(20)
                + "EL Type".PadRight(20)
                + "Extra Info".PadRight(20));

            List<Product> sortedProducts = products.OrderBy(product => product.GetType().Name)
                .ThenBy(product => product.Date).ToList();

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


                    Console.WriteLine("".PadRight(20) + product.Name.PadRight(20)
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
                    Console.WriteLine("".PadRight(20)
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The number of products is:" + products.Count());
            Console.ResetColor();
        }

    }
}
