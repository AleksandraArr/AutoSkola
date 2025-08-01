﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        private Socket socket;
        private List<ClientHandler> handlers = new List<ClientHandler>();

        public Server()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), int.Parse(ConfigurationManager.AppSettings["port"]));

            socket.Bind(endPoint);
            socket.Listen(5);

            Thread thread = new Thread(AcceptClient);
            thread.Start();

        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    Socket klijentskiSoket = socket.Accept();
                    ClientHandler handler = new ClientHandler(klijentskiSoket, this);
                    handlers.Add(handler);
                    Thread klijentskaNit = new Thread(handler.HandleRequest);
                    klijentskaNit.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Stop()
        {
            List<ClientHandler> copy = new List<ClientHandler>(handlers); 
            foreach (ClientHandler handler in copy)
            {
                handler.CloseSocket();
            }
            handlers.Clear();
            socket.Close();
        }
        private object _lock = new object();

        internal void RemoveClient(ClientHandler clientHandler)
        {
            lock (_lock)
            {
                handlers.Remove(clientHandler);
            }
        }


    }
}
