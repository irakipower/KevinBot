using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using KevinBot.Properties;

namespace KevinBot.Network
{
    class Status
    {
        Settings S = new Settings();
        Functions Func = new Functions();
        Config Cfg = new Config();
        public void Online()
        {
            NameValueCollection C = new NameValueCollection();
            C.Add("id", S.id);
            C.Add("status", "1");
            Func.UploadValues(C, Cfg.SetStatus);
        }

        public void Offline()
        {
            NameValueCollection C = new NameValueCollection();
            C.Add("id", S.id);
            C.Add("status", "0");
            Func.UploadValues(C, Cfg.SetStatus);
        }
    }
}
