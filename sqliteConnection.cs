using System.Data.SQLite;

namespace sqliteConnection
{
   public class Connection
   {
      public SQLiteConnection CreateConnection(string database)
      {

         SQLiteConnection sqlite_conn;
         sqlite_conn = new SQLiteConnection("Data Source=" + database + ";Version=3;New=True;Compress=True;");
         // try
         // {
         sqlite_conn.Open();
         // }
         // catch (Exception ex)
         // {
         //    System.Console.WriteLine(ex);
         // }
         return sqlite_conn;
      }
   }
}

// D:\training\C#>csc /r:System.Data.SQLite.dll /t:library /out:sqliteConn.dll sqliteConnection.cs

// bankDetailsFile.db