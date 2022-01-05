using System;
using System.Linq;

namespace theFirstCheckPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Your name with out first latter:" + inputName.Substring(1));
            //Console.WriteLine("Your name is with out the secound and the third letter:" + inputName.Substring(1, 2));
            //Console.WriteLine("remove all the latter after the third:" + inputName.Remove(3));
            //Console.WriteLine("replace the d with j:" + inputName.Replace('d', 'j')); ;
            //Console.WriteLine("trim each side from the word if it has space:" + inputName.Trim()); ;
            //string[] names = inputName.Split(" ");

            int index = 0;
            string[] productsArray = new String[1];

            Console.WriteLine("--------------------------------------------------------");
            while (true)
            {

                Console.WriteLine("Skriva in produkter. Avsluta med att skriva 'exit'");
                string product = Console.ReadLine(); // get data
                //product = product.Trim(); // check if it's exit  små bokstäver ska inte spela
                product = product.ToLower().Trim(); //check if it's exit  små bokstäver ska inte spela
                
                if (product == "exit") // check if it's exit  små bokstäver ska inte spela
                {
                    break;
                }
                else if (product == "")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Du får inte ange ett tomt värde");
                    Console.ResetColor();
                    continue;
                }
                else if (!product.Contains("-"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Felaktigt format eftersom du har inte den '-' på prodkten: {0}", product);
                    Console.ResetColor();
                    continue;
                }

                else
                {
                    string[] productSplit = product.Split("-");
                    bool isFirstContainsInt = productSplit[0].Any(char.IsDigit);
                    bool isSecoundInt = int.TryParse(productSplit[1], out int intValue);

                    if (isFirstContainsInt || productSplit[0] == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktigt format på vänster delan av produktnumert: {0}", product);
                        Console.ResetColor();
                    }
                    else if (!isSecoundInt || productSplit[1] == "")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Felaktigt format på höger delan av produktnumert: {0}", product);
                        Console.ResetColor();
                    }
                    else if (intValue < 200 || intValue > 500) // det är inte equal, det är mellan
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Den numeriska delen måste vara mellen 200 och 500", product);
                        Console.ResetColor();
                    }
                    else // print error if the product is wrong
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        //Console.WriteLine("Ange produkt: {0}", data); // another way
                        Console.WriteLine($"Ange produkt: {product}");
                        Console.ResetColor();
                        Array.Resize(ref productsArray, index + 1); //resize the array so its become bigger by one
                        productsArray[index++] = product;
                    }


                }
            
            }
            Console.WriteLine("--------------------------------------------------------");

            Console.WriteLine("Du angev följande produkter (sorterade):");

            Array.Sort(productsArray); // sort the array
            Console.WriteLine($"\n");//print each product

            foreach (string produkt in productsArray) // loop through the array
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"* {produkt}");//print each product
                Console.ResetColor();
            }

            Console.WriteLine($"\n");//print each product
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Press any key to continue . . .");
            Console.ReadKey(); // break point

        }
    }
}
