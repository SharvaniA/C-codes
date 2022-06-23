using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqliteCruds
{
   public class Cruds
   {
      public void InsertData(SQLiteConnection conn, String tableName)
      {
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         String accountNumber;
         String balance;
         String name;
         System.Console.WriteLine("Ener your Account Number: ");
         accountNumber = System.Console.ReadLine();

         System.Console.WriteLine("Ener your Name: ");
         name = System.Console.ReadLine();

         System.Console.WriteLine("Ener your Balance: ");
         balance = System.Console.ReadLine();

         sqlite_cmd.CommandText = "INSERT INTO " + tableName + " VALUES (" + accountNumber + ", '"+ name + "', " + balance + ", 1);";
         sqlite_cmd.ExecuteNonQuery();
      }
// bankDetails
      public void ReadData(SQLiteConnection conn, String tableName)
      {
         SQLiteDataReader sqlite_datareader;
         SQLiteCommand sqlite_cmd;
         sqlite_cmd = conn.CreateCommand();
         sqlite_cmd.CommandText = "SELECT * FROM " + tableName + ";";

         sqlite_datareader = sqlite_cmd.ExecuteReader();
         while (sqlite_datareader.Read())
         {
            string accountNumber = sqlite_datareader.GetValue(0).ToString();
            System.Console.WriteLine(accountNumber);
            string name = sqlite_datareader.GetValue(1).ToString();
            System.Console.WriteLine(name);
            string balance = sqlite_datareader.GetValue(2).ToString();
            System.Console.WriteLine(balance + "\n");
         }
      }
   }
}

// D:\training\C#>csc /r:System.Data.SQLite.dll /t:library sqliteCRUDS.cs