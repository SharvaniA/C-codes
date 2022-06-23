// SQLite Single Domain (Data Table) Experiment.

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SQLiteDemo
{
   class Program
   {

      public static void Main(String[] args)
      {
         try
         {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            while (true)
            {
               // String option;
               Console.WriteLine("Select one of the option below to proceed:\n1. Create Account.\n2. Display Customer details.\nEnter your option: ");
               int option = Convert.ToInt32(Console.ReadLine());
               switch (option)
               {
                  case 1:
                     InsertData(sqlite_conn);
                     break;
                  case 2:
                     ReadData(sqlite_conn);
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

      public static SQLiteConnection CreateConnection()
      {

         SQLiteConnection sqlite_conn;
         sqlite_conn = new SQLiteConnection("Data Source=bankDetailsFile.db;Version=3;New=True;Compress=True;");
         try
         {
            sqlite_conn.Open();
         }
         catch (Exception ex)
         {
            Console.WriteLine(ex);
         }
         return sqlite_conn;
      }

      public static void InsertData(SQLiteConnection conn)
      {
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         String accountNumber;
         String balance;
         String name;
         Console.WriteLine("Ener your Account Number: ");
         accountNumber = Console.ReadLine();

         Console.WriteLine("Ener your Name: ");
         name = Console.ReadLine();

         Console.WriteLine("Ener your Balance: ");
         balance = Console.ReadLine();

         sqlite_cmd.CommandText = "INSERT INTO bankDetails VALUES (" + accountNumber + ", '"+ name + "', " + balance + ", 1);";
         sqlite_cmd.ExecuteNonQuery();
      }

      public static void ReadData(SQLiteConnection conn)
      {
         DataTable CustomersTable = new DataTable();
         String sqlite_cmd = "SELECT * FROM bankDetails";
         SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlite_cmd, conn);
         
         adapter.Fill(CustomersTable);
         foreach (DataRow row in CustomersTable.Rows)
         {
            string accountNumber = row["accountNumber"].ToString();
            Console.WriteLine(accountNumber);
            string name = row["name"].ToString();
            Console.WriteLine(name);
            string balance = row["balance"].ToString();
            Console.WriteLine(balance + "\n");
            Console.ReadLine();
         }
         conn.Close();
      }
   }
}

// D:\training\C#>csc /reference:System.Data.SQLite.dll sqliteDataTable.cs
// D:\training\C#>sqliteDataTable











































// // SQLite Single Domain (Data Table).

// using System;
// using System.Collections.Generic;
// using System.Data.SQLite;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using System.Data;

// namespace SQLiteDemo
// {
//    class Program
//    {

//       public static void Main(String[] args)
//       {
//          try
//          {
//             SQLiteConnection sqlite_conn;
//             sqlite_conn = CreateConnection();
//             while (true)
//             {
//                // String option;
//                Console.WriteLine("Select one of the option below to proceed:\n1. Create Account.\n2. Display Customer details.\nEnter your option: ");
//                int option = Convert.ToInt32(Console.ReadLine());
//                switch (option)
//                {
//                   case 1:
//                      InsertData(sqlite_conn);
//                      break;
//                   case 2:
//                      ReadData(sqlite_conn);
//                      break;
//                   case 3:
//                      Environment.Exit(0);
//                      break;
//                }
//             }
//          }
//          catch (Exception ex)
//          {
//             Console.WriteLine(ex);
//          }
//       }

//       public static SQLiteConnection CreateConnection()
//       {

//          SQLiteConnection sqlite_conn;
//          sqlite_conn = new SQLiteConnection("Data Source=bankDetailsFile.db;Version=3;New=True;Compress=True;");
//          try
//          {
//             sqlite_conn.Open();
//          }
//          catch (Exception ex)
//          {
//             Console.WriteLine(ex);
//          }
//          return sqlite_conn;
//       }

//       public static void InsertData(SQLiteConnection conn)
//       {
//          SQLiteCommand sqlite_cmd;
//          sqlite_cmd = conn.CreateCommand();
//          String accountNumber;
//          String balance;
//          String name;
//          Console.WriteLine("Ener your Account Number: ");
//          accountNumber = Console.ReadLine();

//          Console.WriteLine("Ener your Name: ");
//          name = Console.ReadLine();

//          Console.WriteLine("Ener your Balance: ");
//          balance = Console.ReadLine();

//          sqlite_cmd.CommandText = "INSERT INTO bankDetails VALUES (" + accountNumber + ", '"+ name + "', " + balance + ", 1);";
//          sqlite_cmd.ExecuteNonQuery();
//       }

//       public static void ReadData(SQLiteConnection conn)
//       {
//          DataTable CustomersTable = new DataTable();
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

//       }
//    }
// }
// // D:\training\C#>csc /reference:System.Data.SQLite.dll sqliteDataTable.cs
// // D:\training\C#>sqliteDataTable