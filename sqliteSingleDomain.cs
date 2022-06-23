// SQLite Single Domain (Data Reader).

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo
{
   class Program
   {

      public static void Main(String[] args)
      {
         try
         {
            SQLiteConnection sqlite_conn;
            Connection connect = new Connection();  
            sqlite_conn = connect.CreateConnection();

            Cruds cruds = new Cruds();

            while (true)
            {
               // String option;
               Console.WriteLine("Select one of the option below to proceed:\n1. Create Account.\n2. Display Customer details.\nEnter your option: ");
               int option = Convert.ToInt32(Console.ReadLine());
               switch (option)
               {
                  case 1:
                     cruds.InsertData(sqlite_conn);
                     break;
                  case 2:
                     cruds.ReadData(sqlite_conn);
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
   }

   class Connection
   {
      public SQLiteConnection CreateConnection()
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
   }

   class Cruds
   {
      public void InsertData(SQLiteConnection conn)
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

      public void ReadData(SQLiteConnection conn)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "SELECT * FROM bankDetails";

         sqlite_datareader = sqlite_cmd.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            string accountNumber = sqlite_datareader.GetValue(0).ToString();
            Console.WriteLine(accountNumber);
            string name = sqlite_datareader.GetValue(1).ToString();
            Console.WriteLine(name);
            string balance = sqlite_datareader.GetValue(2).ToString();
            Console.WriteLine(balance + "\n");
         }
      }
   }
}

// csc /reference:System.Data.SQLite.dll sqliteSingleDomin.cs
// sqliteSingleDomin




























































// // SQLite Single Domain (Data Reader).

// using System;
// using System.Collections.Generic;
// using System.Data.SQLite;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

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
//          SQLiteDataReader sqlite_datareader;
//          SQLiteCommand sqlite_cmd;
//          sqlite_cmd = conn.CreateCommand();
//          sqlite_cmd.CommandText = "SELECT * FROM bankDetails";

//          sqlite_datareader = sqlite_cmd.ExecuteReader();
//          while (sqlite_datareader.Read())
//          {
//             string accountNumber = sqlite_datareader.GetValue(0).ToString();
//             Console.WriteLine(accountNumber);
//             string name = sqlite_datareader.GetValue(1).ToString();
//             Console.WriteLine(name);
//             string balance = sqlite_datareader.GetValue(2).ToString();
//             Console.WriteLine(balance + "\n");
//          }
//       }
//    }
// }

// // csc /reference:System.Data.SQLite.dll sqliteSingleDomin.cs
// // sqliteSingleDomin