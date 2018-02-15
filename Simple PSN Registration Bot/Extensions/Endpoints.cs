using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_PSN_Registration_Bot.Extensions
{
    internal static class Endpoints
    {
        internal static string ACCOUNT_CREATION_URL = "https://account.sonyentertainmentnetwork.com/liquid/reg/account/create-account.action";
        internal static string ONLINE_ID_REGISTRATION_URL = "https://account.sonyentertainmentnetwork.com/liquid/cam/account/profile/edit-profile-online-id.action";
        internal static string PASSWORD_VALIDATION_URL = "https://account.sonyentertainmentnetwork.com/reg/account/validate-password.action";
        internal static string CAPTCHA_INPUT_URL = "http://2captcha.com/in.php";
        internal static string CAPTCHA_RESULT_URL = $"http://2captcha.com/res.php?key={Data.CAPTCHA_API_KEY}&action=get&id=";
    }
}
