using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//  Step 1
using System.Data.SqlClient;
using System.Configuration;

namespace ADODemos
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = "y";
            while (choice == "y")
            {
                int ch= Menu();

                switch(ch)
                {
                    case 1 : GetEmployees(); break;
                    case 2:
                        {
                            Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter Manager Name");
                            string managername = Console.ReadLine();
                            InsertRecord(name, managername); break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter Id");
                            int id = Byte.Parse(Console.ReadLine());
                            
                             DeleteEmployee(id);break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Id");
                            int id = Byte.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Manager Name");
                            string managername = Console.ReadLine();
                            EditEmployee(id, managername); break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter Id");
                            int id = Byte.Parse(Console.ReadLine());
                            SearchDepartment(id);
                            break;
                        }
                }
                //Console.WriteLine("Enter Id");
                //int id = Byte.Parse(Console.ReadLine());
               
              
                Console.WriteLine("Do you want to repeat");
                choice = Console.ReadLine();
            }
 
        }

        private static int Menu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. List of Departments");
            Console.WriteLine("2. Insert Department Record");
            Console.WriteLine("3. Delete Department");
            Console.WriteLine("4. Edit Department");
            Console.WriteLine("5. Search Department");
            Console.WriteLine("Enter Choice");
            int ch = Byte.Parse(Console.ReadLine());
            return ch;
        }

        private static string getConnectionString()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Myconnection"].ToString();
            return connectionString;
        }
        private static SqlConnection GetConnection()
        {
           //string connectionString = "data source=LAPTOP-53S2KQS8;initial catalog=practicedb;integrated security=true";
            SqlConnection connection = new SqlConnection(getConnectionString());
            return connection;


        }
        private static void GetEmployees()
        {

            // Step 2
             using (SqlConnection connection = GetConnection() )
            {
                // Step 3
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Select * from department";
                    command.Connection = connection;

                    //SqlCommand com = new SqlCommand("Select * from Employee", connection);

                    // Step 4:
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(reader["id"].ToString() + " " + reader["name"] + " " + reader["managername"]);
                        }
                    }
                    reader.Close();
                    connection.Close();
                }
            }
        }
        static void InsertRecord(string name, string managername)
        {
            SqlConnection connection = GetConnection();
            SqlCommand command = new SqlCommand("Insert into Department (name,managername) values(@name, @managername)", connection);
            //command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@managername", managername);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            command.Dispose();
            connection.Dispose();



        }
        static void SearchDepartment(int id)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Select * From Department where id=@id";
                    command.Parameters.AddWithValue("@id", id);
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();

                        Console.WriteLine(reader["id"].ToString() + " " + reader["name"] + " " + reader["managername"]);

                    }
                    reader.Close();
                    connection.Close();
                }
            }

        }
                static void DeleteEmployee(int id)
        {
           using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "Delete from department where id=@id";
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }


        static void EditEmployee(int id, string managername)
        {
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "update department set managername=@managername where id=@id";
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@managername", managername);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}