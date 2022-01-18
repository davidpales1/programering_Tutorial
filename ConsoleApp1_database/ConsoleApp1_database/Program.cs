using System;
using System.Data.SqlClient;

namespace ConsoleApp_ADO_20220117
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Read data from Northwind database!");
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 10 * FROM Products", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Id".PadRight(5) + "Brand".PadRight(35) + "Items");
                    while (reader.Read())
                    {
                        //Console.WriteLine(
                        //    reader[0].ToString().PadRight(5) +
                        //    reader[1].ToString().PadRight(35) +
                        //    reader[4].ToString()
                        //    );

                        Console.WriteLine(
                           reader["ProductID"].ToString().PadRight(5) +
                           reader["ProductName"].ToString().PadRight(35) +
                           reader["QuantityPerUnit"].ToString()
                           );
                    }
                }
                connection.Close();

            }

            Console.ReadLine();
        }
    }
}
