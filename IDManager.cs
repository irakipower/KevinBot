using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KevinBot.Properties;

namespace KevinBot.App
{
    public class IDManager
    {
        Settings S = new Settings();
        public string GetRandomID(int length)
        {
            StringBuilder StrBuilder = new StringBuilder();
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random Rnd = new Random();
            for (int i = 0; i <= length; i++)
            {
                int nbr = Rnd.Next(0, Chars.Length);
                StrBuilder.Append(Chars.Substring(nbr, 1));
            }
            byte[] buff = Encoding.ASCII.GetBytes(StrBuilder.ToString());
            return Convert.ToBase64String(buff);
        }
        public void GenerateID(int length)
        {
            if ((!S.id.Contains(Environment.UserName)))
            {
                string id = Environment.UserName + "@" + GetRandomID(length);
                S.id = id;
                S.Save();
            }
        }
    }
}