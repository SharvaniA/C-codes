// MySQL Single Domin.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQLiteDemo
{
   class Program
   {
      public static void Main(String[] args)
      {
         string host = "165.22.14.77";
         string database = "dbSharvani";
         string username = "sharvani";
         string password = "pwdsharvani";

         String sql_conn;
         try
         {
            sql_conn = "SERVER=" + host + ";DATABASE=" + database + ";UID=" + username + ";PASSWORD=" + password + ";";
            MySqlConnection connection = new MySqlConnection(sql_conn);
            connection.Open();
            while (true)
            {
               Console.WriteLine("Select one of the option below to proceed:\n1. Create Account.\n2. Display Customer details.\nEnter your option: ");
               int option = Convert.ToInt32(Console.ReadLine());
               switch (option)
               {
                  case 1:
                     InsertData(connection);
                     break;
                  case 2:
                     ReadData(connection);
                     break;
                  case 3:
                     Environment.Exit(0);
                     break;
               }
            }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }
      public static void InsertData(MySqlConnection conn)
      {
         MySqlCommand mysql_cmd;
         mysql_cmd = conn.CreateCommand();
         String accountNumber;
         String balance;
         String name;
         Console.WriteLine("Ener your Account Number: ");
         accountNumber = Console.ReadLine();

         Console.WriteLine("Ener your Name: ");
         name = Console.ReadLine();

         Console.WriteLine("Ener your Balance: ");
         balance = Console.ReadLine();

         mysql_cmd.CommandText = "INSERT INTO bankCustomerDetails VALUES (" + accountNumber + ", '"+ name + "', " + balance + ", 1);";
         mysql_cmd.ExecuteNonQuery();
      }
      public static void ReadData(MySqlConnection conn)
      {
         try
         {
            // MySqlDataReader mysql_datareader;
            // MySqlCommand mysql_cmd;
            // mysql_cmd = conn.CreateCommand();
            // mysql_cmd.CommandText = "SELECT * FROM bankCustomerDetails";

            // mysql_datareader = mysql_cmd.ExecuteReader();
            // while (mysql_datareader.Read())
            // {
            //    string accountNumber = mysql_datareader["accountNumber"].ToString();
            //    Console.WriteLine(accountNumber);
            //    string name = mysql_datareader["name"].ToString();
            //    Console.WriteLine(name);
            //    string balance = mysql_datareader["balance"].ToString();
            //    Console.WriteLine(balance + "\n");
            // }

            DataTable CustomersTable = new DataTable();
//          String sqlite_cmd = "SELECT * FROM bankDetails";
//          SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlite_cmd, conn);
         
//          adapter.Fill(CustomersTable);
//          foreach (DataRow row in CustomersTable.Rows)
//          {
//             string accountNumber = row["accountNumber"].ToString();
//             Console.WriteLine(accountNumber);
//             string name = row["name"].ToString();
//             Console.WriteLine(name);
//             string balance = row["balance"].ToString();
//             Console.WriteLine(balance + "\n");
//          }
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
      }
   }
}

D:\training\C#>csc /reference:MySql.Data.dll sqlSingleDomin.cs
D:\training\C#>sqlSingleDomin