using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Simple_PSN_Registration_Bot.Requests
{
    internal static class Sony
    {
        internal static async Task<bool> checkIPBan()
        {
            var response = await Core.SendGetRequest(Extensions.Endpoints.ACCOUNT_CREATION_URL);
            if (response.StatusCode.ToString() == "429")
                return true;
            return false;
        }
        internal static async Task<Tuple<bool, string>> validatePassword(string email, string password, CookieContainer cookies)
        {
            Extensions.Data Data = new Extensions.Data();

            Data.PASSWORD_VALIDATION_DATA["loginName"] = email;
            Data.PASSWORD_VALIDATION_DATA["password"] = password;

            var response = await Core.SendPostRequest(Extensions.Endpoints.PASSWORD_VALIDATION_URL, Data.PASSWORD_VALIDATION_DATA, false, null, cookies);
            string responseString = await response.Content.ReadAsStringAsync();
            var deserializedResponse = JsonConvert.DeserializeObject<Extensions.passwordValidationResponse>(await response.Content.ReadAsStringAsync());
            if (deserializedResponse.valid)
                return Tuple.Create(true, "");
            if (!string.IsNullOrEmpty(deserializedResponse.message))
                return Tuple.Create(false, deserializedResponse.message);
            if (string.IsNullOrEmpty(deserializedResponse.fieldErrors.password[0]))
                return Tuple.Create(false, deserializedResponse.fieldErrors.password[0]);
            else return Tuple.Create(false, "Unknown error occurred.");
        }
        internal static async Task<Tuple<bool, string>> createAccount(string email, string[] dob, string password, string captchaToken, CookieContainer cookies)
        {
            Extensions.Data Data = new Extensions.Data();

            Data.ACCOUNT_CREATION_DATA["account.loginName"] = email;
            Data.ACCOUNT_CREATION_DATA["account.mob"] = dob[0];
            Data.ACCOUNT_CREATION_DATA["account.dob"] = dob[1];
            Data.ACCOUNT_CREATION_DATA["account.yob"] = dob[2];
            Data.ACCOUNT_CREATION_DATA["account.password"] = password;
            Data.ACCOUNT_CREATION_DATA["confirmPassword"] = password;
            Data.ACCOUNT_CREATION_DATA["g-recaptcha-response"] = captchaToken;
            Data.ACCOUNT_CREATION_DATA["struts.token"] = await retrieveStrutsToken(Extensions.Endpoints.ACCOUNT_CREATION_URL, cookies);

            var response = await Core.SendPostRequest(Extensions.Endpoints.ACCOUNT_CREATION_URL, Data.ACCOUNT_CREATION_DATA, false, null, cookies);
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.RequestMessage.RequestUri.AbsoluteUri == "https://account.sonyentertainmentnetwork.com/security/unverified-user!input.action?service-entity=np&m=account.created")
                return Tuple.Create(true, "");
            else if (responseString.Contains("errorFields[\"account.loginName\"] = true;"))
                return Tuple.Create(false, "The email your provided was eithe invalid or in use.");
            else if (responseString.Contains("Please verify that you are not a robot."))
                return Tuple.Create(false, "The captcha token was invalid.");
            else if (response.StatusCode.ToString() == "429")
                return Tuple.Create(false, "429");
            else
                return Tuple.Create(false, "Unknown");
        }
        private static async Task<string> retrieveStrutsToken(string strutsUrl, CookieContainer cookies)
        {
            var response = await Core.SendGetRequest(strutsUrl, null, false, null, cookies);

            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(await response.Content.ReadAsStringAsync());
            return htmlDocument.DocumentNode.SelectSingleNode("//input[@name='struts.token']").Attributes["Value"].Value;
        }
        internal static async Task<bool> registerOnlineId()
        {
            var response = await Core.SendGetRequest(Extensions.Endpoints.ACCOUNT_CREATION_URL);
            if (response.StatusCode.ToString() == "429")
                return true;
            return false;
        }
    }
}
