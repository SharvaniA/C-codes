using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using sqliteConnection;
using sqliteCruds;


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
            sqlite_conn = connect.CreateConnection("bankDetailsFile.db");

            Cruds cruds = new Cruds();

            while (true)
            {
               // String option;
               Console.WriteLine("Select one of the option below to proceed:\n1. Create Account.\n2. Display Customer details.\nEnter your option: ");
               int option = Convert.ToInt32(Console.ReadLine());
               switch (option)
               {
                  case 1:
		            cruds.InsertData(sqlite_conn, "bankDetails");
                     // cruds.InsertData(sqlite_conn);
                     break;
                  case 2:
		            cruds.ReadData(sqlite_conn, "bankDetails");
                     // cruds.ReadData(sqlite_conn);
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
}

// D:\training\C#>csc /reference:System.Data.SQLite.dll;sqliteConn.dll;sqliteCRUDS.dll testSqlite.cs
// D:\training\C#>testSqlite