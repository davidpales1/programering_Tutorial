using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ctrl + k + C to add comment
            // Ctrl + k + U to remove the comment
            Console.WriteLine("Type your name:");
            string inputName = Console.ReadLine();
            Console.WriteLine("Your name is:" + inputName);
            Console.WriteLine("Your name with out first latter:" + inputName.Substring(1));
            Console.WriteLine("Your name is with out the secound and the third letter:" + inputName.Substring(1, 2));
            Console.WriteLine("remove all the latter after the third:" + inputName.Remove(3));
            Console.WriteLine("replace the d with j:" + inputName.Replace('d', 'j')); ;
            Console.WriteLine("trim each side from the word if it has space:" + inputName.Trim()); ;
            string[] names = inputName.Split(" ");
            Console.WriteLine("--------------------------------------------------------");

            int index = 0;
            string[] myCars = new String[10];

            while (true)
            {

                Console.WriteLine("Add a Car type or type exit to exit:");
                myCars[index] = Console.ReadLine();

                if (myCars[index].ToLower().Trim() == "exit")
                {
                    break;
                }

                index++;

            }
            Array.Resize(ref myCars, index); //resize the array so its become smaller 
            Array.Sort(myCars); // sort the array

            Console.WriteLine("this is a for loop");

            for (int i = 0; i < myCars.Length; i++)
            {
                Console.WriteLine(myCars[i]);
            }
            Console.WriteLine("this is a foreach loop");

            foreach (string car in myCars)
            {
                Console.WriteLine(car);
            }
            Console.WriteLine("--------------------------------------------------------");

            int[] valueArray = new int[1];
            int indexValue = 0;
            while (true)
            {
                Console.WriteLine("Add a number and type 'exit' to show the list:");
                string data = Console.ReadLine();
                if (data.ToLower().Trim() == "exit")
                {
                    break;
                }
                bool isInt = int.TryParse(data, out int value);
                if (isInt)
                {
                    Array.Resize(ref valueArray, indexValue + 1) ; //resize the array so its become smaller
                    valueArray[indexValue++] = value;

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} is not a number", data);
                    Console.WriteLine($"{data} is not a number");
                    Console.WriteLine(data + " is not a number");
                    Console.ResetColor();
                }
            }

            foreach (int value in valueArray)
            {
                Console.WriteLine(value);
            }
        }
    }
}
