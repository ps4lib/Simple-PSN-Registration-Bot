using System;
using System.Collections.Generic;

namespace Simple_PSN_Registration_Bot.Extensions
{
    internal class Data
    {
        internal const string CAPTCHA_API_KEY = "";
        internal const string CHARS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        internal static Random Random = new Random();
        internal Dictionary<string, string> ACCOUNT_CREATION_DATA = new Dictionary<string, string>()
        {
            { "struts.token.name", "struts.token" },
            { "struts.token", null },
            { "account.loginName", null },
            { "account.mob", null },
            { "account.dob", null },
            { "account.yob", null },
            { "account.country", "US" },
            { "account.address.province", "CA" },
            { "account.language", "en" },
            { "account.password", null },
            { "confirmPassword", null },
            { "captchaType", "recaptcha" },
            { "g-recaptcha-response", null },
            { "__checkbox_optins['NP-SCEI-DIRECT']", null },
            { "__checkbox_optins['NP-SCEI-3RDPARTY']", null },
            { "embeddedEula", "false" }
        };
        internal Dictionary<string, string> ONLINE_ID_REGISTRATION_DATA = new Dictionary<string, string>()
        {
            { "struts.token.name", "struts.token" },
            { "struts.token", null },
            { "handle", null }
        };
        internal Dictionary<string, string> PASSWORD_VALIDATION_DATA = new Dictionary<string, string>()
        {
            { "struts.enableJSONValidation", "true" },
            { "loginName", null },
            { "password", null }
        };
        internal Dictionary<string, string> CAPTCHA_DATA = new Dictionary<string, string>()
        {
            { "key", CAPTCHA_API_KEY },
            { "method", "userrecaptcha" },
            { "googlekey", "6Lfitx4UAAAAAIdhzC0bAF3A_EFIz6FurIr-L7Nl" },
            { "pageurl", "https://account.sonyentertainmentnetwork.com/liquid/reg/account/create-account.action" }
        };
    }
    public class passwordValidationResponse
    {
        public bool valid { get; set; } = false;
        public string message { get; set; }
        public FieldErrors fieldErrors { get; set; }
    }
    public class FieldErrors
    {
        public List<string> password { get; set; }
    }
}
