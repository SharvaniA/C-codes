using System.Net;
using System.Net.Sockets;
using System.Text;

class Client
{

    static void Main(string[] args)
    {
       TcpClient socket = new TcpClient();
       socket.Connect("localhost", 6565);
       string message = "";

       while (true)
       {
            message = System.Console.ReadLine();
            Client.sendMessage(socket, message);
            Client.receiveMessage(socket);
        }
    }

    static void receiveMessage(TcpClient socket)
    {
        NetworkStream stream = socket.GetStream();
        byte[] data = new byte[256];
        System.Console.ReadLine();
        int bytes = stream.Read(data, 0, data.Length);
        string responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
        System.Console.WriteLine("Received: {0}", responseData);
    }
    static void sendMessage(TcpClient socket, string message)
    {

        NetworkStream stream = socket.GetStream();
        byte[] data = Encoding.ASCII.GetBytes(message);
        stream.Write(data, 0, data.Length);
    }
}








































// using System;
// using System.Net;
// using System.Net.Sockets;
// using System.Text;

// // Client app is the one sending messages to a Server/listener.
// // Both listener and client can send messages back and forth once a
// // communication is established.
// public class SocketClient
// {
//     public static void Main(string[] args)
//     {
//         try
//         {
//             TcpClient socket = new TcpClient();
//             socket.Connect("localhost", 8786);
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine(ex);
//         }
//     }
// }































// private void startFeed()
// {
//    // Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//    //IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("192.168.1.6"), 9999);
//    TcpClient socket = new TcpClient();
//    socket.Connect("192.168.1.6",9999);
//    while (true)
//    {
//        try 
//        {
//            NetworkStream stream = socket.GetStream();
//            byte[] bytes = new byte[socket.ReceiveBufferSize];
//                stream.Read(bytes, 0,bytes.Length) ;

//            //socket.Receive(bytes);
//            pictureEdit1.EditValue = bytes;
//        }
//        catch(Exception e)
//        {
//            Console.WriteLine(e);
//        }
//    }
// }








































// using System;
// using System.Net;
// using System.Net.Sockets;
// using System.Text;

// // Client app is the one sending messages to a Server/listener.
// // Both listener and client can send messages back and forth once a
// // communication is established.
// public class SocketClient
// {
//     public static int Main(String[] args)
//     {
//         StartClient();
//         return 0;
//     }

//     public static void StartClient()
//     {
//         byte[] bytes = new byte[1024];

//         try
//         {
//             // Connect to a Remote server
//             // Get Host IP Address that is used to establish a connection
//             // In this case, we get one IP address of localhost that is IP : 127.0.0.1
//             // If a host has multiple addresses, you will get a list of addresses
//             IPHostEntry host = Dns.GetHostEntry("192.168.0.104");
//             IPAddress ipAddress = host.AddressList[0];
//             IPEndPoint remoteEP = new IPEndPoint(ipAddress, 57667);

//             // Create a TCP/IP  socket.
//             Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

//             // Connect the socket to the remote endpoint. Catch any errors.
//             try
//             {
//                 // Connect to Remote EndPoint
//                 sender.Connect(remoteEP);

//                 Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());

//                 // Encode the data string into a byte array.
//                 byte[] msg = Encoding.ASCII.GetBytes("This is a test<EOF>");

//                 // Send the data through the socket.
//                 int bytesSent = sender.Send(msg);

//                 // Receive the response from the remote device.
//                 int bytesRec = sender.Receive(bytes);
//                 Console.WriteLine("Echoed test = {0}", Encoding.ASCII.GetString(bytes, 0, bytesRec));

//                 // Release the socket.
//                 sender.Shutdown(SocketShutdown.Both);
//                 sender.Close();
//             }
//             catch (ArgumentNullException ane)
//             {
//                 Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
//             }
//             catch (SocketException se)
//             {
//                 Console.WriteLine("SocketException : {0}", se.ToString());
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine("Unexpected exception : {0}", e.ToString());
//             }

//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.ToString());
//         }
//     }
// }