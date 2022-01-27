using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2_CRUD
{
    internal class Update
    {
        public static string UpdateLaptop(ProductContext db, int id)
        {
            Laptop product = db.Laptops.Where(product => product.Id == id).FirstOrDefault();
            Console.WriteLine("----");
            Console.WriteLine($"Input the name of the product(default={product.Name}):");
            string productName = Console.ReadLine(); // get the name
            if (CommounFunctions.IsQuit(productName)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productName)) { }
            else { product.Name = productName; }
            Console.WriteLine($"Input the Brand of the product(default={product.Brand}):");
            string productBrand = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productBrand)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productBrand)) { }
            else { product.Brand = productBrand; }
            Console.WriteLine($"Input the Date of the product in this format(yyyy-MM-dd)(default={product.Date}):");
            string productDate = Console.ReadLine(); // get the category of the product

            if (CommounFunctions.IsQuit(productDate)) { return "q"; } // check if the input == quit

            bool isDateValid = DateTime.TryParseExact(productDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate);
            TimeSpan isExpired = DateTime.Now - resultDate;
            int isExpiredInDays = (int)isExpired.TotalDays;
            if (!isDateValid || isExpiredInDays >= 1095)
            {
                Console.WriteLine("make sure to use the correct format yyyy-MM-dd and make sure the product is not older than 3 years");
                return "cancel";
            } // check if the input is in correct format
            if (CommounFunctions.IsEmpty(productDate)) { }
            else { product.Date = resultDate; }
            Console.WriteLine($"Input the Model of the product(default={product.Model}):");
            string productModel = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productModel)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productModel)) { }
            else { product.Model = productModel; }

            Console.WriteLine($"Input the price of the product in dollar(default={product.Price}):");
            string productPrice = Console.ReadLine(); // get the price
            if (CommounFunctions.IsQuit(productPrice)) { return "q"; } // check if the input == quit

            if (!productPrice.All(char.IsDigit))
            {
                Console.WriteLine("You must enter a number in the price field!");
                return "cancel";
            }
            if (CommounFunctions.IsEmpty(productPrice)) { }
            else { product.Price = int.Parse(productPrice); }

                Console.WriteLine($"Input the name of the Gpu type(default={product.GPUType}):");
                string GpuType = Console.ReadLine(); // get the category of the product
                if (CommounFunctions.IsQuit(GpuType)) { return "q"; } // check if the input == quit
                if (CommounFunctions.IsEmpty(GpuType)) { }
                else { product.GPUType = GpuType; }



            db.Products.Update(product);
            db.SaveChanges();

            Console.WriteLine($"The product with id:{id} has been Updated");
            return "add";

        }
        public static string UpdateMobile(ProductContext db, int id)
        {
            Mobile product = db.Mobiles.Where(product => product.Id == id).FirstOrDefault();
            Console.WriteLine("----");
            Console.WriteLine($"Input the name of the product(default={product.Name}):");
            string productName = Console.ReadLine(); // get the name
            if (CommounFunctions.IsQuit(productName)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productName)) {
                Console.WriteLine($"so the value will not be change");

            }
            else { product.Name = productName; }
            Console.WriteLine($"Input the Brand of the product(default={product.Brand}):");
            string productBrand = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productBrand)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productBrand)) { }
            else { product.Brand = productBrand; }
            Console.WriteLine($"Input the Date of the product in this format(yyyy-MM-dd)(default={product.Date}):");
            string productDate = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productDate)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productDate)) { }
            else {
                bool isDateValid = DateTime.TryParseExact(productDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate);
                TimeSpan isExpired = DateTime.Now - resultDate;
                int isExpiredInDays = (int)isExpired.TotalDays;
                if (!isDateValid || isExpiredInDays >= 1095)
                {
                    Console.WriteLine("make sure to use the correct format yyyy-MM-dd and make sure the product is not older than 3 years");
                    return "cancel";
                } // check if the input is in correct format

                product.Date = resultDate; }
            Console.WriteLine($"Input the Model of the product(default={product.Model}):");
            string productModel = Console.ReadLine(); // get the category of the product
            if (CommounFunctions.IsQuit(productModel)) { return "q"; } // check if the input == quit
            if (CommounFunctions.IsEmpty(productModel)) { }
            else { product.Model = productModel; }

            Console.WriteLine($"Input the price of the product in dollar(default={product.Price}):");
            string productPrice = Console.ReadLine(); // get the price
            if (CommounFunctions.IsQuit(productPrice)) { return "q"; } // check if the input == quit

            if (!productPrice.All(char.IsDigit))
            {
                Console.WriteLine("You must enter a number in the price field!");
                return "cancel";
            } // check if the input == ""
            if (CommounFunctions.IsEmpty(productPrice)) { }
            else { product.Price = int.Parse(productPrice); }

            Console.WriteLine($"Input the number of the Camera you want(default={product.NumberOfCamera}):");
            string cameraNumber = Console.ReadLine(); // get the category of the product
                if (CommounFunctions.IsQuit(cameraNumber)) { return "q"; } // check if the input == quit
                if (CommounFunctions.IsEmpty(cameraNumber)) { }
                else { product.NumberOfCamera = int.Parse(cameraNumber); }
                if (!cameraNumber.All(char.IsDigit))
                {
                    Console.WriteLine("You must enter a number in the price field!");
                    return "cancel";
                } 

            db.Products.Update(product);
            db.SaveChanges();
            Console.WriteLine($"The product with id:{id} has been Updated");

            return "add";

        }
        public static string AskTheCustomer(ProductContext db, int id)
        {
            Product product = db.Products.Where(product => product.Id == id).FirstOrDefault();
            if (product != null)
            {

                if (product.Discriminator == "Laptop")
                {
                    return UpdateLaptop(db,id);

                }
                else if (product.Discriminator == "Mobile")
                {
                    return UpdateMobile(db, id);

                }
                

                return "add";
            }
            else
            {
                Console.WriteLine("The Selected product doesn't exist");

            }
            return "";
        }

    }
}
