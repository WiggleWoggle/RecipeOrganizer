using System;
using System.Data.SqlClient;

class SQLServer
{

    static void Main()
    {
        string connectionString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true"

        string createDbQuery = "CREATE DATABASE recipies"

        try
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(createDbQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                    console.writeline("LocalDB database 'recipie' created successfully")
                }
            }
        }
        catch (Exception ex)
        {
            Console.writeline("An error occurred: " +  ex.Message);
        }
    }

}