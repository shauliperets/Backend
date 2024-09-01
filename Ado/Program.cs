// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System.Data;
using System.Data.SqlClient;

string connectionString = "Server=your_server_name;Database=your_database_name;Trusted_Connection=True;";


using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    // Your code to interact with the database goes here

    using (SqlCommand command = new SqlCommand("SELECT * FROM your_table_name", connection))
    {
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine(reader["your_column_name"].ToString());
            }
        }
    }
}
