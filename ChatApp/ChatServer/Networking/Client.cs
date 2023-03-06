﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer.Networking
{
     class Client
    {
        public string Username { get; set; }
        public Guid UID { get; set; }
        public TcpClient _ClientSocket { get; set; }
        public Client(TcpClient clientSocket)
        {
            _ClientSocket= clientSocket;
            UID = Guid.NewGuid();
            Console.WriteLine($"{DateTime.Now}: Client has conencted user name : "+ $"{Username}" +"");
        }
    }
}
