using ChatServer.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class Program
    {
        static TcpListener _listener;
        static void main(string[] args)
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7777);
            _listener.Start();
            //var client = _listener.AcceptTcpClient();
            //Console.WriteLine("Client is connected");
            var client = new Client(_listener.AcceptTcpClient());
        }
    }
}