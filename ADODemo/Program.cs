using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Reader();
            DataSets();

            Console.WriteLine("Press <ENTER>...");
        }

        // Disconnected Archiercture of ADO.NET
        static void DataSets()
        {
            //string connectionString = "Server=.;Initial Catalog=ECommerce;userid=sa;password=1234";
            string connectionString = "Server=.;Initial Catalog=ECommerce;Integrated Security=SSPI";

            // Create a connection.
            SqlConnection conn = new SqlConnection(connectionString);
            // Define a query
            string query = "SELECT * FROM Customers";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customers");
            DataTable tableCustomers = ds.Tables["Customers"];

            string query2 = "SELECT * FROM Orders";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, conn);
            da2.Fill(ds, "Orders");
            DataTable tableOrders = ds.Tables["Orders"];

            foreach(DataRow row in tableOrders.Rows)
            {
                Console.WriteLine($"{row["OrderId"]}, {row["CustomerId"]}, {row["OrderDate"]}");
            }
        }

        // Connected Architecture of ADO.NET to work with DBs
        static void Reader()
        {
            //string connectionString = "Server=.;Initial Catalog=ECommerce;userid=sa;password=1234";
            string connectionString = "Server=.;Initial Catalog=ECommerce;Integrated Security=SSPI";

            // Create a connection.
            SqlConnection conn = new SqlConnection(connectionString);
            // Define a query
            string query = "SELECT * FROM Customers";
            // Define a command to execute for the query on the connection.
            SqlCommand cmd = new SqlCommand(query, conn);
            // Open the connection.
            conn.Open();
            // Execute the command and store records in a reader.
            SqlDataReader reader = cmd.ExecuteReader();
            
            // Traverse through the records and print data.
            while(reader.Read())
            {
                Console.WriteLine($"{reader["CustomerId"]}, {reader["Firstname"]}, {reader["Lastname"]}");
                //Console.WriteLine($"{reader[0]}, {reader[1]}, {reader[2]}");
            }
            reader.Close();

            string insertQuery = "INSERT INTO Products (Name, Description) VALUES ('Skullcandy Headphone', 'Skullcandy Headphone - White')";
            SqlCommand cmd2 = new SqlCommand(insertQuery, conn);
            cmd2.ExecuteNonQuery();

            string updateQuery = "UPDATE Customers SET Activated = 0";
            SqlCommand cmd3 = new SqlCommand(updateQuery, conn);
            cmd3.ExecuteNonQuery();

            string qry = "SELECT Firstname FROM Customers WHERE CustomerId = 1";
            SqlCommand cmd4 = new SqlCommand(qry, conn);
            var val = (string)(cmd4.ExecuteScalar());
            Console.WriteLine($"{val}");

            // Close the connection.
            conn.Close();
         }
    }
}
