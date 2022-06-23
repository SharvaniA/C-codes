// Temperature from weather API.

using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using nsTools;

namespace Examples.System.Net
{
    public class WebRequestGetExample
    {
        public static void Main ()
        {
        	Tools tools = new Tools();

        	tools.print("Enter City Name: ");
        	string city = tools.input();
            WebRequest request = WebRequest.Create ("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=e6b7427f8bf97526adf2869093c7509c&units=metric");
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
            Stream dataStream = response.GetResponseStream ();
            StreamReader reader = new StreamReader (dataStream);
            string responseFromServer = reader.ReadToEnd ();
            JObject json = JObject.Parse(responseFromServer);
            JObject main = JObject.Parse(json["main"].ToString());
            tools.print("Temperature of " + city + ": " + main["temp"].ToString());
        }
    }
}
// D:\training\C#>csc /reference:Newtonsoft.Json.dll;tools.dll weatherAPI.cs
// D:\training\C#>weatherAPI



























// // Temperature from weather API.

// using System;
// using System.IO;
// using System.Net;
// using Newtonsoft.Json.Linq;

// namespace Examples.System.Net
// {
//     public class WebRequestGetExample
//     {
//         public static void Main ()
//         {
//         	Console.WriteLine("Enter City Name: ");
//         	string city = Console.ReadLine();
//             WebRequest request = WebRequest.Create ("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=e6b7427f8bf97526adf2869093c7509c&units=metric");
//             request.Credentials = CredentialCache.DefaultCredentials;
//             HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
//             Stream dataStream = response.GetResponseStream ();
//             StreamReader reader = new StreamReader (dataStream);
//             string responseFromServer = reader.ReadToEnd ();
//             JObject json = JObject.Parse(responseFromServer);
//             JObject main = JObject.Parse(json["main"].ToString());
//             Console.WriteLine("Temperature of " + city + ": " + main["temp"].ToString());
//         }
//     }
// }

// D:\training\C#>csc /reference:Newtonsoft.Json.dll weatherAPI.cs
// D:\training\C#>weatherAPI









































// Complete Info of Weather API.

// using System;
// using System.IO;
// using System.Net;
// using System.Text;

// namespace Examples.System.Net
// {
//     public class WebRequestGetExample
//     {
//         public static void Main ()
//         {
//             // Create a request for the URL. 		
//             WebRequest request = WebRequest.Create ("
// https:
//api.openweathermap.org/data/2.5/weather?q=Warangal&appid=e6b7427f8bf97526adf2869093c7509c&units=metric");
//             // If required by the server, set the credentials.
//             request.Credentials = CredentialCache.DefaultCredentials;
//             // Get the response.
//             HttpWebResponse response = (HttpWebResponse)request.GetResponse ();
//             // Display the status.
//             Console.WriteLine (response.StatusDescription);
//             // Get the stream containing content returned by the server.
//             Stream dataStream = response.GetResponseStream ();
//             // Open the stream using a StreamReader for easy access.
//             StreamReader reader = new StreamReader (dataStream);
//             // Read the content.
//             string responseFromServer = reader.ReadToEnd ();
//             // Display the content.
//             Console.WriteLine (responseFromServer);
//             // Cleanup the streams and the response.
//             reader.Close ();
//             dataStream.Close ();
//             response.Close ();
//         }
//     }
// }

// csc weatherAPI.cs
// weatherAPI












































