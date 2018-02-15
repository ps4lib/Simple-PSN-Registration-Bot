using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_PSN_Registration_Bot.Extensions
{
    public static class Utilities
    {
        public static string randomizedString(int length )
        {
            return new string(Enumerable.Repeat(Data.CHARS, length).Select(s => s[Data.Random.Next(s.Length)]).ToArray());
        }
    }
}
