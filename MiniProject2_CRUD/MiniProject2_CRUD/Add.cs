using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2_CRUD
{
    internal class Add
    {
        public static void AddLaptop(ProductContext db, string productName, string productBrand, DateTime productDate, int productPrice, string productModel, string GpuType)
        {
            Laptop product = new Laptop(productName, productBrand, productDate, productPrice, productModel, GpuType);
            string priceInSEK = CommounFunctions.ConvertToLocalMonyFromNet(product.Price);

            db.Laptops.Add(product);
            db.SaveChanges();

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
        public static void AddMobile(ProductContext db, string productName, string productBrand, DateTime productDate, int productPrice, string productModel, int cameraNumber)
        {
            Mobile product = new Mobile(productName, productBrand, productDate, productPrice, productModel, cameraNumber);
            db.Mobiles.Add(product);
            db.SaveChanges();

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
        public static string AskTheCustomer(ProductContext db, string productType)
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
                Add.AddMobile(db, productName, productBrand, resultDate, int.Parse(productPrice), productModel, int.Parse(cameraNumber));

            }
            else if (productType == "laptop")
            {
                Console.WriteLine("Input the name of the Gpu type:");
                string GpuType = Console.ReadLine(); // get the category of the product
                if (CommounFunctions.IsQuit(GpuType)) { return "q"; } // check if the input == quit
                if (CommounFunctions.IsEmpty(GpuType)) { return "cancel"; } // check if the input == ""
                Add.AddLaptop(db, productName, productBrand, resultDate, int.Parse(productPrice), productModel, GpuType);
            }
            return "add";
        }


    }
}
