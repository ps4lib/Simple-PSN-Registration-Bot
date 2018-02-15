using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_PSN_Registration_Bot.Extensions
{
    internal static class Enums
    {
        internal enum captchaErrorResponse
        {
            ERROR_WRONG_USER_KEY = 1,
            ERROR_KEY_DOES_NOT_EXIST = 2,
            ERROR_ZERO_BALANCE = 3,
            ERROR_NO_SLOT_AVAILABLE = 4
        }
    }
}
