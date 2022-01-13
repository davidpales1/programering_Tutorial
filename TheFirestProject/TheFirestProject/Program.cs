using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Net;

namespace theThirdCheckPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string test = commounFunctions.ConvertToLocalMonyFromNet(50);
            Console.WriteLine(test);

            //variable
            bool moreProduct = true;
            List<Product> products = new List<Product>(); // product list with type product

            Console.WriteLine("--------------------------------------------------------\n");
            Console.WriteLine("Add a product and Print all the product by typing 'q' in the name input field!\n");


            try // try this code 
            {
                while (moreProduct)
                {
                    
                    commounFunctions.AskForType(products);

                    Console.WriteLine("--------------------------------------------------------\n");

                    commounFunctions.printProducts(products); // print the list of product that the user selcet

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
    }

    class Product
    {
        public Product(string Name, string Brand, DateTime Date, int Price)
        {
            this.Name = Name;
            this.Brand = Brand;
            this.Date = Date;
            this.Price = Price;

            this.addDate = DateTime.Now;

    }
        public string Name { get; set; }
        public DateTime addDate = new DateTime();

        public DateTime Date { get; set; }
        public string Brand { get; set; }
        public int Price { get; set; }

        public virtual string GetExtraInfo()
        {
            return "";
        }
        public virtual string Type => "The use didn't specify the Type";
    }
    class laptop : Product
    {
        public laptop(string Name, string Brand, DateTime Date, int Price, string Model, string GPUType) : base(Name, Brand, Date, Price)
        {
            this.GPUType = GPUType;
            this.Model = Model;

        }
        public string GPUType { get; set; }
        public string Model { get; set; }


        public override string GetExtraInfo()
        {
            return " " + GPUType + " " + Model;
        }
        public override string Type => "laptop";

    }
    class mobile : Product
    {
        public mobile(string Name, string Brand, DateTime Date, int Price, string Model, int NumberOfCamera) : base(Name, Brand, Date, Price)
        {
            this.NumberOfCamera = NumberOfCamera;
            this.Model = Model;

        }
        public int NumberOfCamera { get; set; }
        public string Model { get; set; }
        public override string Type => "mobile Phones";

        public override string GetExtraInfo()
        {
            return " " + NumberOfCamera + " " + Model;
        }
    }

    class commounFunctions
    {
        public static string ConvertToLocalMonyFromNet(int amount)
        {
            try
            {
                string culture = CultureInfo.CurrentCulture.Name; // "SEK", 
                string[] countr = culture.Split("-");
                string country = countr[1];
                Console.Write(country);

                RegionInfo myRI1 = new RegionInfo("SE");

                string isoCurrencySymbol = myRI1.ISOCurrencySymbol;
                string currencySymbol = myRI1.CurrencySymbol;
                WebClient client = new WebClient();
                string source = client.DownloadString("https://freecurrencyapi.net/api/v2/latest?apikey=3719a600-7454-11ec-a5e0-dd4ad0c02114&base_currency=USD");
                dynamic data = System.Text.Json.JsonDocument.Parse(source).RootElement;
                string Rate = Convert.ToString(data.GetProperty("data").GetProperty(isoCurrencySymbol)); ;

                double exchangeRate = double.Parse(Rate);
                //double exchangeRate = 1.5;

                return (amount * exchangeRate).ToString() + " " + currencySymbol;
            }
            catch (Exception e)
            {
                Console.Write("I couldn't convert to another currency becouse i couldn't connect to the server ");
                Console.Write(e);
                return amount + "$";//{0:C}



            }

        }
        public static void AskForType(List<Product> products)
        {

            while (true)
            {
                Console.WriteLine("----");
                Console.WriteLine("We have two type of product in our store('Mobile' or 'Laptop'):");
                string productType = Console.ReadLine(); // get the name
                productType = productType.ToLower().Trim();

                if (commounFunctions.isQuit(productType)) { break; } // check if the input == quit
                if (commounFunctions.isEmpty(productType)) { continue; } // check if the input == ""
                if (productType == "mobile") // check if product Type is a mobile
                {
                    string result = commounFunctions.askTheCustomer(products, "mobile"); // ask the custome about which product to add 
                    if (result == "q") { break; } // check if the input == quit
                    if (result == "cancel") { continue; } // check if the input == quit
                    if (result == "add") { continue; } // check if the input == quit
                }

                else if (productType == "laptop") // check if product Type is a laptop
                {
                    string result = commounFunctions.askTheCustomer(products, "laptop"); //ask the customer
                    if (result == "q") { break; } // check if the input == quit
                    if (result == "cancel") { continue; } // check if the input == quit
                    if (result == "add") { continue; } // check if the input == quit
                }

                else { Console.WriteLine("Input one of the two product 'Mobile' or 'Laptop':"); continue; } // check if the input == ""
                //commounFunctions.addProduct(products, productName, productCategory, int.Parse(productPrice));
            }

        }
        public static string askTheCustomer(List<Product> products, string productType)
        {
            Console.WriteLine("----");
            Console.WriteLine("Input the name of the product:");
            string productName = Console.ReadLine(); // get the name
            if (commounFunctions.isQuit(productName)) { return "q"; } // check if the input == quit
            if (commounFunctions.isEmpty(productName)) { return "cancel"; } // check if the input == ""
            Console.WriteLine("Input the Brand of the product:");
            string productBrand = Console.ReadLine(); // get the category of the product
            if (commounFunctions.isQuit(productBrand)) { return "q"; } // check if the input == quit
            if (commounFunctions.isEmpty(productBrand)) { return "cancel"; } // check if the input == ""
            Console.WriteLine("Input the Date of the product in this format(yyyy-MM-dd):");
            string productDate = Console.ReadLine(); // get the category of the product

            if (commounFunctions.isQuit(productDate)) { return "q"; } // check if the input == quit
            if (commounFunctions.isEmpty(productDate)) { return "cancel"; } // check if the input == ""
            


            bool isDateValid = DateTime.TryParseExact(productDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate);
            TimeSpan isExpired = DateTime.Now - resultDate;
            int isExpiredInDays = (int)isExpired.TotalDays;
            if (!isDateValid || isExpiredInDays >= 1095) {
                Console.WriteLine("make sure to use the correct format yyyy-MM-dd and make sure the product is not older than 3 years");
                return "cancel"; } // check if the input is in correct format

            Console.WriteLine("Input the Model of the product:");
                string productModel = Console.ReadLine(); // get the category of the product
                if (commounFunctions.isQuit(productModel)) { return "q"; } // check if the input == quit
                if (commounFunctions.isEmpty(productModel)) { return "cancel"; } // check if the input == ""

                Console.WriteLine("Input the price of the product in dollar:");
                string productPrice = Console.ReadLine(); // get the price
                if (commounFunctions.isQuit(productPrice)) { return "q"; } // check if the input == quit
                if (commounFunctions.isEmpty(productPrice)) { return "cancel"; } // check if the input == ""
                if (!productPrice.All(char.IsDigit)) {
                Console.WriteLine("You must enter a number in the price field!");
                return "cancel"; } // check if the input == ""

            if (productType == "mobile")
                {
                    Console.WriteLine("Input the number of the Camera you want:");
                    string cameraNumber = Console.ReadLine(); // get the category of the product
                    if (commounFunctions.isQuit(cameraNumber)) { return "q"; } // check if the input == quit
                    if (commounFunctions.isEmpty(cameraNumber)) { return "cancel"; } // check if the input == ""
                    if (!cameraNumber.All(char.IsDigit)){
                    Console.WriteLine("You must enter a number in the price field!");
                    return "cancel"; } // check if the input == ""
                    commounFunctions.addMobile(products, productName, productBrand, resultDate, int.Parse(productPrice), productModel, int.Parse(cameraNumber));

                }
                else if (productType == "laptop")
                {
                    Console.WriteLine("Input the name of the Gpu type:");
                    string GpuType = Console.ReadLine(); // get the category of the product
                    if (commounFunctions.isQuit(GpuType)) { return "q"; } // check if the input == quit
                    if (commounFunctions.isEmpty(GpuType)) { return "cancel"; } // check if the input == ""
                    commounFunctions.addLaptop(products, productName, productBrand, resultDate, int.Parse(productPrice), productModel, GpuType);
                }
            return "add";
        }
        public static void addMobile(List<Product> products, string productName, string productBrand, DateTime productDate, int productPrice,string productModel, int cameraNumber)
        {
            Product product = new mobile(productName, productBrand, productDate, productPrice, productModel, cameraNumber);
            products.Add(product);
            string priceInSEK = commounFunctions.ConvertToLocalMonyFromNet(product.Price);

            Console.WriteLine("\n----");
            Console.WriteLine("You added the following mobile:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("".PadRight(10) + "Name".PadRight(10)
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(10)
                + "Model".PadRight(10)
                + "Number Of camera".PadRight(10)
                + "EL Type".PadRight(10));

            Console.WriteLine("".PadRight(10) + product.Name.PadRight(10)
                + product.Brand.PadRight(20)
                + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                + product.addDate.ToString("yyyy-MM-dd").PadRight(20)
                + priceInSEK.PadRight(10)
            + (product as mobile).Model.PadRight(10)
            + (product as mobile).NumberOfCamera.ToString().PadRight(10)
            + (product as mobile).Type.PadRight(10));
            Console.ResetColor();

        }
        public static void addLaptop(List<Product> products, string productName, string productBrand, DateTime productDate, int productPrice, string productModel, string GpuType)
        {
            Product product = new laptop(productName, productBrand, productDate, productPrice, productModel, GpuType);
            string priceInSEK = commounFunctions.ConvertToLocalMonyFromNet(product.Price);

            products.Add(product);
            Console.WriteLine("\n----");
            Console.WriteLine("You added the following laptop:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("".PadRight(10) + "Name".PadRight(10)
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(10)
                + "Model".PadRight(10)
                + "Gpu Type".PadRight(10)
                + "EL Type".PadRight(10));
            Console.WriteLine("".PadRight(10) + product.Name.PadRight(10)
                + product.Brand.PadRight(20)
                + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                + product.addDate.ToString("yyyy-MM-dd").PadRight(20)
                + priceInSEK.PadRight(10)
            + (product as laptop).Model.PadRight(10)
            + (product as laptop).GPUType.PadRight(10)
            + (product as laptop).Type.PadRight(10));
            Console.ResetColor();
        }

        public static void printProducts(List<Product> products)
        {
            
            Console.WriteLine("You specified the following products (sorted by laptop then by date):");
            Console.WriteLine("".PadRight(10) + "Name".PadRight(10) 
                + "Brand".PadRight(20)
                + "Date".PadRight(20)
                + "Added at".PadRight(20)
                + "Price".PadRight(10) 
                + "Model".PadRight(10) 
                + "Gpu Type".PadRight(10) 
                + "Number Of camera".PadRight(10) 
                + "EL Type".PadRight(10));
    
            List<Product> sortedProducts = products.OrderBy(product => product.GetType().Name)
                .ThenBy(product => product.Date).ToList();

            foreach (Product product in sortedProducts) // loop through the array
            {
                string priceInSEK = commounFunctions.ConvertToLocalMonyFromNet(product.Price);

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

                if (product is laptop) {


                    Console.WriteLine("".PadRight(10) + product.Name.PadRight(10)
                        + product.Brand.PadRight(20)
                        + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                        + product.addDate.ToString("yyyy-MM-dd").PadRight(20)
                        + priceInSEK.PadRight(10)
                    +  (product as laptop).Model.PadRight(10)
                    + (product as laptop).GPUType.PadRight(10)
                    + (product as laptop).Type.PadRight(10));
                }
                else if (product is mobile) {
                    Console.WriteLine("".PadRight(10) 
                        + product.Name.PadRight(10) 
                        + product.Brand.PadRight(20)
                        + product.Date.ToString("yyyy-MM-dd").PadRight(20)
                        + product.addDate.ToString("yyyy-MM-dd").PadRight(20)
                        + priceInSEK.PadRight(10)
                        + (product as mobile).Model.PadRight(10)
                        + (product as mobile).NumberOfCamera.ToString().PadRight(10)
                        + (product as mobile).Type.PadRight(10));
                }


                Console.ResetColor();

            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The number of products is:" + products.Count());
            Console.ResetColor();
        }


        public static bool askIfMore()
        {
            while (true)
            {
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


}
