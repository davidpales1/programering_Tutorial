using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Net;

namespace MiniProject2_CRUD
{
    class CommounFunctions
    {
        public static string FindTheOffice()
        {
            try
            {
                WebClient client = new WebClient();
                string userInfo = client.DownloadString("https://ipinfo.io/?token=0df663b976da63");
                dynamic userInfoData = System.Text.Json.JsonDocument.Parse(userInfo).RootElement;
                string country = Convert.ToString(userInfoData.GetProperty("country")); ;
                //Console.Write("Your country is: "+ country+". so this is the office that will select.");
                RegionInfo myRI1 = new RegionInfo(country);
                string isoCurrencySymbol = myRI1.ISOCurrencySymbol;
                return country;

            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }
        }

        public static string ConvertToLocalMonyFromNet(int amount)
        {
            try
            {
                //string[] countr = culture.Split("-");
                //string country = countr[1];
                //Console.Write(country);
                WebClient client = new WebClient();

                string userInfo = client.DownloadString("https://ipinfo.io/?token=0df663b976da63");
                dynamic userInfoData = System.Text.Json.JsonDocument.Parse(userInfo).RootElement;
                string country = Convert.ToString(userInfoData.GetProperty("country")); ;
                //Console.Write("Your country is: "+ country+". so this is the office that will select.");
                RegionInfo myRI1 = new RegionInfo(country);
                string isoCurrencySymbol = myRI1.ISOCurrencySymbol;

                string currencySymbol = myRI1.CurrencySymbol;

                string source = client.DownloadString("https://freecurrencyapi.net/api/v2/latest?apikey=3719a600-7454-11ec-a5e0-dd4ad0c02114&base_currency=USD");
                dynamic data = System.Text.Json.JsonDocument.Parse(source).RootElement;


                string Rate = Convert.ToString(data.GetProperty("data").GetProperty(isoCurrencySymbol));
                //Console.WriteLine(Rate);
                //string RateinAnotherRegion = "0.2";
                string currentCulture = CultureInfo.CurrentCulture.Name; // "SEK", 

                try
                {
                    CultureInfo cultur = new CultureInfo(currentCulture); // I'm assuming german here.
                    double exchangeRate = double.Parse(Rate, cultur);
                    //Console.WriteLine(exchangeRate);

                    //double exchangeRate = double.Parse(number);
                    //double exchangeRate = 1.5;

                    return (amount * exchangeRate).ToString() + " " + isoCurrencySymbol;
                }
                catch (Exception)
                {
                    Rate = Rate.Replace('.', ',');
                    CultureInfo cultur = new CultureInfo("se"); // I'm assuming german here.
                    double exchangeRate = double.Parse(Rate, cultur);
                    //Console.WriteLine(exchangeRate);

                    //double exchangeRate = double.Parse(number);
                    //double exchangeRate = 1.5;

                    return (amount * exchangeRate).ToString() + " " + isoCurrencySymbol;
                }
            }
            catch (Exception e)
            {
                Console.Write("I couldn't convert to another currency becouse i couldn't connect to the server ");
                Console.Write(e);
                return amount + "$";//{0:C}



            }

        }

        public static bool IsQuit(string inputt)
        {
            inputt = inputt.ToLower().Trim(); //check if it's exit  små bokstäver ska inte spela
            if (inputt == "q" || inputt == "quit") // check if it's q  små bokstäver ska inte spela
            {
                return true;
            }
            else if (inputt == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ResetColor();
                return false;
            }
            else
            {
                return false;
            }
        }
        public static bool IsEmpty(string inputt)
        {
            inputt = inputt.ToLower().Trim(); //check if it's exit  små bokstäver ska inte spela

            if (inputt == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have enter an empty value!");
                Console.ResetColor();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsString(string inputt)
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
