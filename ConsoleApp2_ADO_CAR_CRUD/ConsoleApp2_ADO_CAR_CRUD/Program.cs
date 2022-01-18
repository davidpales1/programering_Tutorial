using System;
using System.Data.SqlClient;

namespace ConsoleApp2_ADO_CAR_CRUD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cars Crud!");

            // c + r + u + d Create + Read + Update + Delete
            string readCommand = "SELECT TOP 10 * FROM Car";
            string createCommand = "INSERT INTO Car(Brand, Model, Year) VALUES(@brand, @model, @year)";
            string updateCommand = "UPDATE Car SET Year=@year WHERE Id=@id";
            string deleteCommand = "DELETE FROM Car WHERE Id=@id";
            try
            {
                createDataFromDB(createCommand);
                readDataFromDB(readCommand);
                updateDataFromDB(updateCommand);
                deleteDataFromDB(deleteCommand);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }

            Console.ReadKey();
        }

        private static void readDataFromDB(string sqlCommand)
        {
            Console.WriteLine("Read data from ADO_Cars database!");

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_Cars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Id".PadRight(5) + "Brand".PadRight(35) + "Model".PadRight(35) + "Year");
                    while (reader.Read())
                    {
                        Console.WriteLine("fdsfs");
                        Console.WriteLine(
                           reader["Id"].ToString().PadRight(5) +
                           reader["Brand"].ToString().PadRight(35) +
                           reader["Model"].ToString().PadRight(35) +
                           reader["Year"].ToString()
                           );
                    }
                }
                connection.Close();
            }
        }
        private static void createDataFromDB(string sqlCommand)
        {
             
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_Cars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@brand", "bmw");
                    command.Parameters.AddWithValue("@model", "dfd");
                    command.Parameters.AddWithValue("@year", 1000);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        private static void updateDataFromDB(string sqlCommand)
        {

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_Cars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", 2);
                    command.Parameters.AddWithValue("@year", 1968);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
        private static void deleteDataFromDB(string sqlCommand)
        {
             
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ADO_Cars;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sqlCommand, connection))
                {
                    command.Parameters.AddWithValue("@id", 2);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
