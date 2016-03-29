using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Collections.Specialized;

namespace KevinBot.Network
{
    class Functions
    {
        public void UploadValues(NameValueCollection c, string Url)
        {
            try
            {
                byte[] resp = new WebClient().UploadValues(Url, c);
            }
            catch 
            { }
        }
        public string ReadFileContents(string Url)
        {
            string output = null;
            try
            {
                HttpWebRequest hwreq = (HttpWebRequest)WebRequest.Create(Url);
                HttpWebResponse hwres = (HttpWebResponse)hwreq.GetResponse();
                Stream stream = hwres.GetResponseStream();
                StreamReader streamReader = new StreamReader(stream);
                output = streamReader.ReadToEnd();
            }
            catch 
            { }
            return output;
        }
    }
}
