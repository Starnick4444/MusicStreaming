using CodeArtEng.Tcp;
using System.Runtime.CompilerServices;

namespace MusicStreamingClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (true)
            {
                TcpClient client = new TcpClient();
                client.HostName = "127.0.0.1";
                client.Port = 10001;
                client.ConnectionStatusChanged += Client_ConnectionStatusChanged;
                client.DataReceived += Client_DataReceived;
                client.Connect();
                client.WriteLine("asd");
                Thread.Sleep(1000);
                client.Write(new byte[10] { 0, 1, 2, 3, 4, 5, 6, 6, 5, 1 });
            }
            else
            {
                TcpAppClient client = new TcpAppClient();
                client.HostName = "127.0.0.1";
                client.Port = 10002;
                client.ConnectionStatusChanged += Client_ConnectionStatusChanged1;
                client.DataReceived += Client_DataReceived;
                client.CommandSend += Client_CommandSend;
                client.ResponseReceived += Client_ResponseReceived;
                client.Connect();
                client.ReadTimeout = -1;
                Thread.Sleep(1000);
                List<string> commands = client.Commands;
                foreach (string command in commands) Console.WriteLine("Commands: {0}",command);
                ExecCommand(client, commands);
            }

            //stop it from exiting
            Console.ReadLine();
        }

        private static void Client_ResponseReceived(object? sender, TcpAppClientEventArgs e)
        {
            Console.WriteLine("Response recieved: {0}",e.Message);
        }

        private static void Client_CommandSend(object? sender, TcpAppClientEventArgs e)
        {
            Console.WriteLine("Sent command: {0}",e.Message);
        }

        private static void ExecCommand(TcpAppClient client, List<string> commands)
        {
            client.ExecuteCommand("CustomFunction", 2000);
        }

        private static void Client_ConnectionStatusChanged1(object? sender, EventArgs e)
        {
            if (((TcpAppClient)sender).Connected) Console.WriteLine("TCPAPP Connected to server!");
            else Console.WriteLine("TCPAPP Disconnected from server!");
        }

        private static void Client_DataReceived(object? sender, TcpDataReceivedEventArgs e)
        {
            Console.WriteLine("Recieved data: {0}",e.GetString());
        }

        private static void Client_ConnectionStatusChanged(object? sender, EventArgs e)
        {
            if (((TcpClient)sender).Connected) Console.WriteLine("Connected to server!");
            else Console.WriteLine("Disconnected from server!");
        }
    }
}