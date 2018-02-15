using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_PSN_Registration_Bot
{
    public partial class Main : Form
    {
        //2Captcha API Key goes here ignore other API key Strings for now
        const string captchaApiKey = "";
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        const string accountCreationUrl = "https://account.sonyentertainmentnetwork.com/liquid/reg/account/create-account.action";
        const string registerOnlineIdUrl = "https://account.sonyentertainmentnetwork.com/liquid/cam/account/profile/edit-profile-online-id.action";
        const string passwordValidationUrl = "https://account.sonyentertainmentnetwork.com/reg/account/validate-password.action";
        const string captchaApiInputUrl = "http://2captcha.com/in.php";
        string captchaApiResultUrl = $"http://2captcha.com/res.php?key={captchaApiKey}&action=get&id=";
        Random random = new Random();
        CookieContainer psnCookies;
        Dictionary<string, string> accountCreationData = new Dictionary<string, string>()
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
        Dictionary<string, string> onlineIdRegistrationData = new Dictionary<string, string>()
        {
            { "struts.token.name", "struts.token" },
            { "struts.token", null },
            { "handle", null }
        };
        Dictionary<string, string> passwordValidationData = new Dictionary<string, string>()
        {
            { "struts.enableJSONValidation", "true" },
            { "loginName", null },
            { "password", null }
        };
        Dictionary<string, string> captchaApiData = new Dictionary<string, string>()
        {
            { "key", captchaApiKey },
            { "method", "userrecaptcha" },
            { "googlekey", "6Lfitx4UAAAAAIdhzC0bAF3A_EFIz6FurIr-L7Nl" },
            { "pageurl", "https://account.sonyentertainmentnetwork.com/liquid/reg/account/create-account.action" }
        };
        public Main()
        {
            InitializeComponent();
        }
        private void consoleLog(string log = "")
        {
            if (log == ".clear")
            {
                consoleOutputTextBox.Text = "";
                return;
            }

            consoleOutputTextBox.AppendText($"{log}\n");
        }
        private void logIPBan()
        {
            toolStripLabel.Text = "Status: Idle";
            consoleLog(".clear");
            consoleLog("Error: Sony has blocked the current IP due to too many requests");
            consoleLog("Wait 15 minutes before trying again");
            psnCreateAccountButton.Enabled = true;
            registerOnlineIdButton.Enabled = false;
            return;
        }
        private async void psnCreateAccountButton_Click(object sender, EventArgs e)
        {
            try
            {
                registerOnlineIdButton.Enabled = false;
                psnCookies = new CookieContainer();
                psnCreateAccountButton.Enabled = false;

                string psnPassword = psnPasswordTextBox.Text;
                string psnEmail = psnEmailTextBox.Text;
                string psnDOB = psnDOBTextBox.Text;
                string captchaToken = "";
                if (string.IsNullOrEmpty(captchaApiKey))
                    captchaToken = Interaction.InputBox("The 2Captcha API Key string is empty, please enter your a manually obtained captcha token.", "User Provided Captcha Token", null);
                string[] splitDOB = psnDOB.Split('/');

                #region Randomization for empty fields
                if (string.IsNullOrEmpty(psnPassword))
                    psnPassword = Extensions.Utilities.randomizedString(8);
                if (string.IsNullOrEmpty(psnDOB.Replace("/", "").Replace(" ", "")))
                {
                    splitDOB[0] = Extensions.Data.Random.Next(1, 12).ToString();
                    splitDOB[1] = Extensions.Data.Random.Next(1, 31).ToString();
                    splitDOB[2] = Extensions.Data.Random.Next(1899, 1999).ToString();
                    psnDOB = splitDOB[0] + "/" + splitDOB[1] + "/" + splitDOB[2];
                }
                if (string.IsNullOrEmpty(psnEmail) || !psnEmail.Contains("@") || !psnEmail.Contains("."))
                {
                    toolStripLabel.Text = "Status: Idle";
                    consoleLog(".clear");
                    consoleLog("Error: You must enter a valid email you can access");
                    consoleLog("You need to verify the account to create an Online ID");
                    psnCreateAccountButton.Enabled = true;
                    return;
                }
                #endregion

                toolStripLabel.Text = "Status: Verifying details provided";

                #region Verifying required fields data
                if (Convert.ToInt32(splitDOB[0]) > 12 || Convert.ToInt32(splitDOB[0]) < 1)
                {
                    toolStripLabel.Text = "Status: Idle";
                    consoleLog(".clear");
                    consoleLog("Error: The month parameter of date of birth is invalid");
                    psnCreateAccountButton.Enabled = true;
                    return;
                }
                if (Convert.ToInt32(splitDOB[1]) > 31 || Convert.ToInt32(splitDOB[1]) < 1)
                {
                    toolStripLabel.Text = "Status: Idle";
                    consoleLog(".clear");
                    consoleLog("Error: The day parameter of date of birth is invalid");
                    psnCreateAccountButton.Enabled = true;
                    return;
                }
                if (Convert.ToInt32(splitDOB[2]) > 1999 || Convert.ToInt32(splitDOB[2]) < 1900)
                {
                    toolStripLabel.Text = "Status: Idle";
                    consoleLog(".clear");
                    consoleLog("Error: The year parameter of date of birth is invalid");
                    consoleLog("If you set it above 1999 please set it at or below");
                    consoleLog("So the account will be aged 18+");
                    psnCreateAccountButton.Enabled = true;
                    return;
                }
                #endregion

                if (await Requests.Sony.checkIPBan())
                {
                    logIPBan();
                    return;
                }

                var passwordValidation = await Requests.Sony.validatePassword(psnEmail, psnPassword, psnCookies);
                if (!passwordValidation.Item1)
                {
                    toolStripLabel.Text = "Status: Idle";
                    consoleLog(".clear");
                    consoleLog($"Error: {passwordValidation.Item2}");
                    psnCreateAccountButton.Enabled = true;
                    return;
                }

                consoleLog(".clear");
                consoleLog($"Starting account creation process");
                consoleLog();
                consoleLog($"Account password: {psnPassword}");
                consoleLog($"Account email: {psnEmail}");
                consoleLog($"Account date of birth: {psnDOB}");
                consoleLog($"Account country: United States");
                consoleLog($"Account state: California");
                consoleLog($"Account language: English");
                consoleLog();

                if (!string.IsNullOrEmpty(captchaToken))
                    consoleLog($"Captcha token Provided by user");
                else
                {
                    HttpClientHandler handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
                    HttpClient client = new HttpClient(handler);
                    toolStripLabel.Text = "Status: Retrieving captcha token from 2Captcha";
                    Stopwatch watch = Stopwatch.StartNew();
                    consoleLog($"Retrieving captcha token from 2Captcha");
                    using (HttpRequestMessage captchTokenInputRequest = new HttpRequestMessage() { Method = HttpMethod.Post, RequestUri = new Uri(captchaApiInputUrl), Content = new FormUrlEncodedContent(captchaApiData) })
                    {
                        HttpResponseMessage Response = await client.SendAsync(captchTokenInputRequest);
                        string responseData = await Response.Content.ReadAsStringAsync();
                        var splitData = responseData.Split('|');

                        if (splitData[0] == "ERROR_WRONG_USER_KEY")
                        {
                            toolStripLabel.Text = "Status: Idle";
                            watch.Stop();
                            consoleLog(".clear");
                            consoleLog("Error: Invalid 2Captcha api key provided");
                            psnCreateAccountButton.Enabled = true;
                            return;
                        }

                        if (splitData[0] == "ERROR_KEY_DOES_NOT_EXIST")
                        {
                            toolStripLabel.Text = "Status: Idle";
                            watch.Stop();
                            consoleLog(".clear");
                            consoleLog("Error: Invalid 2Captcha api key provided");
                            psnCreateAccountButton.Enabled = true;
                            return;
                        }

                        if (splitData[0] == "ERROR_ZERO_BALANCE")
                        {
                            toolStripLabel.Text = "Status: Idle";
                            watch.Stop();
                            consoleLog(".clear");
                            consoleLog("Error: Your 2Captcha account has no balance left");
                            psnCreateAccountButton.Enabled = true;
                            return;
                        }

                        if (splitData[0] == "ERROR_NO_SLOT_AVAILABLE")
                        {
                            toolStripLabel.Text = "Status: Idle";
                            watch.Stop();
                            consoleLog(".clear");
                            consoleLog("Error: You already have too many captchas queued up awaiting completion");
                            psnCreateAccountButton.Enabled = true;
                            return;
                        }

                        captchaApiResultUrl = captchaApiResultUrl + splitData[1];

                        while (true)
                        {
                            using (HttpRequestMessage captchaTokenResultRequest = new HttpRequestMessage() { Method = HttpMethod.Get, RequestUri = new Uri(captchaApiResultUrl) })
                            {
                                Response = await client.SendAsync(captchaTokenResultRequest);
                                responseData = await Response.Content.ReadAsStringAsync();
                                splitData = responseData.Split('|');

                                if (splitData[0] == "ERROR_KEY_DOES_NOT_EXIST")
                                {
                                    toolStripLabel.Text = "Status: Idle";
                                    watch.Stop();
                                    consoleLog(".clear");
                                    consoleLog("Error: Invalid 2Captcha api key provided");
                                    psnCreateAccountButton.Enabled = true;
                                    return;
                                }

                                if (splitData[0] == "ERROR_CAPTCHA_UNSOLVABLE")
                                {
                                    toolStripLabel.Text = "Status: Idle";
                                    watch.Stop();
                                    consoleLog(".clear");
                                    consoleLog("Error: The captcha could not be solved");
                                    psnCreateAccountButton.Enabled = true;
                                    return;
                                }

                                if (splitData[0] == "ERROR_WRONG_CAPTCHA_ID")
                                {
                                    toolStripLabel.Text = "Status: Idle";
                                    watch.Stop();
                                    consoleLog(".clear");
                                    consoleLog("Error: The captcha id provided is wrong");
                                    psnCreateAccountButton.Enabled = true;
                                    return;
                                }

                                if (splitData[0] == "CAPTCHA_NOT_READY") { }

                                if (splitData[0] == "OK")
                                {
                                    watch.Stop();
                                    consoleLog($"Captcha token retrieved in {watch.ElapsedMilliseconds / 1000}s");
                                    captchaToken = splitData[1];
                                    break;
                                }

                                await Task.Delay(2000);
                            }
                        }
                    }
                }

                consoleLog();
                consoleLog($"Attempting to register account");
                consoleLog();
                toolStripLabel.Text = "Status: Attempting to register account";

                if (await Requests.Sony.checkIPBan())
                {
                    logIPBan();
                    return;
                }

                var accountCreationResponse = await Requests.Sony.createAccount(psnEmail, splitDOB, psnPassword, captchaToken, psnCookies);

                toolStripLabel.Text = "Status: Idle";

                if (accountCreationResponse.Item1)
                {
                    consoleLog("Account successfully created");
                    consoleLog("Email verification is required.");
                    consoleLog("Once the email is verified click the 'Register Online ID' button");
                    psnCreateAccountButton.Enabled = true;
                    registerOnlineIdButton.Enabled = true;
                }
                else
                {
                    if(accountCreationResponse.Item2 == "429")
                    {
                        logIPBan();
                        return;
                    }

                    consoleLog("Account creation failed");
                    consoleLog($"Reason: {accountCreationResponse.Item2}");
                    psnCreateAccountButton.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                toolStripLabel.Text = "Status: Idle";
                consoleLog(".clear");
                consoleLog($"A program error occured: {ex.Message}");
                psnCreateAccountButton.Enabled = true;
            }
        }
        private async void registerOnlineIdButton_Click(object sender, EventArgs e)
        {
            try
            {
                consoleLog();
                toolStripLabel.Text = "Status: Attempting to register Online ID";

                psnCreateAccountButton.Enabled = false;
                registerOnlineIdButton.Enabled = false;

                string psnUsername = psnUsernameTextBox.Text;
                if (string.IsNullOrEmpty(psnUsername))
                    psnUsername = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

                onlineIdRegistrationData["handle"] = psnUsername;

                consoleLog("Starting Online ID Registration Process");
                consoleLog();
                consoleLog($"Online ID to Register: {psnUsername}");
                consoleLog();

                HttpClientHandler handler = new HttpClientHandler() { CookieContainer = psnCookies, UseCookies = true, AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate };
                HttpClient client = new HttpClient(handler);

                using (HttpRequestMessage sonyEmailVerifyRequest = new HttpRequestMessage() { Method = HttpMethod.Get, RequestUri = new Uri("https://account.sonyentertainmentnetwork.com/liquid/security/unverified-user.action") })
                {
                    HttpResponseMessage Response = await client.SendAsync(sonyEmailVerifyRequest);
                    string r = await Response.Content.ReadAsStringAsync();
                    if (Response.StatusCode.ToString() == "429")
                    {
                        toolStripLabel.Text = "Status: Idle";
                        consoleLog("Error: Sony has blocked the current IP due to too many requests");
                        consoleLog("Wait 15 minutes before trying again");
                        psnCreateAccountButton.Enabled = true;
                        registerOnlineIdButton.Enabled = false;
                        return;
                    }
                    if (Response.RequestMessage.RequestUri.AbsoluteUri == "https://account.sonyentertainmentnetwork.com/liquid/home/index!display.action")
                    {
                        using (HttpRequestMessage sonyStrutsTokenRequest = new HttpRequestMessage() { Method = HttpMethod.Get, RequestUri = new Uri("https://account.sonyentertainmentnetwork.com/liquid/cam/account/profile/profile-details.action") })
                        {
                            Response = await client.SendAsync(sonyStrutsTokenRequest);
                            HtmlAgilityPack.HtmlDocument htmlDocument = new HtmlAgilityPack.HtmlDocument();
                            htmlDocument.LoadHtml(await Response.Content.ReadAsStringAsync());
                            onlineIdRegistrationData["struts.token"] = htmlDocument.DocumentNode.SelectSingleNode("//input[@name='struts.token']").Attributes["Value"].Value;
                        }
                    }
                    else
                    {
                        toolStripLabel.Text = "Status: Idle";
                        consoleLog("Error: could not validate account");
                        consoleLog("You have to continue manually");
                        psnCreateAccountButton.Enabled = true;
                        registerOnlineIdButton.Enabled = false;
                        return;
                    }
                }

                using (HttpRequestMessage sonyAccountCreationRequest = new HttpRequestMessage() { Method = HttpMethod.Post, RequestUri = new Uri(registerOnlineIdUrl), Content = new FormUrlEncodedContent(onlineIdRegistrationData) })
                {
                    HttpResponseMessage Response = await client.SendAsync(sonyAccountCreationRequest);
                    string responseText = await Response.Content.ReadAsStringAsync();
                    if (Response.StatusCode.ToString() == "429")
                    {
                        toolStripLabel.Text = "Status: Idle";
                        consoleLog("Error: Sony has blocked the current IP due to too many requests");
                        consoleLog("Wait 15 minutes before trying again");
                        psnCreateAccountButton.Enabled = true;
                        registerOnlineIdButton.Enabled = false;
                        return;
                    }
                    toolStripLabel.Text = "Status: Idle";

                    if (responseText.Contains($"<label id=\"onlineID\">{psnUsername}</label>"))
                    {
                        toolStripLabel.Text = "Status: Idle";
                        consoleLog("Online ID Successfully Registered");
                        psnCreateAccountButton.Enabled = true;
                        registerOnlineIdButton.Enabled = false;
                        psnCookies = new CookieContainer();
                        return;
                    }
                    else if (responseText.Contains("This Online ID is already taken."))
                    {
                        toolStripLabel.Text = "Status: Idle";
                        consoleLog("Online ID Registration failed");
                        consoleLog("Reason: The online ID is already in use please try a different ID");
                        psnCreateAccountButton.Enabled = false;
                        registerOnlineIdButton.Enabled = true;
                        return;
                    }
                    else
                    {
                        toolStripLabel.Text = "Status: Idle";
                        consoleLog("Online ID Registration failed");
                        consoleLog("Reason: Unknown");
                        psnCreateAccountButton.Enabled = true;
                        registerOnlineIdButton.Enabled = false;
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripLabel.Text = "Status: Idle";
                consoleLog(".clear");
                consoleLog($"A program error occured: {ex.Message}");
                psnCreateAccountButton.Enabled = true;
                registerOnlineIdButton.Enabled = false;
            }
        }
        private void recaptchaScriptLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://greasyfork.org/en/scripts/38215-recaptcha");
        }
        private void psnCaptchaLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://account.sonyentertainmentnetwork.com/liquid/reg/account/create-account!input.action");
        }
        public class passwordValidationResponse
        {
            public bool valid { get; set; } = false;
            public FieldErrors fieldErrors { get; set; }
        }
        public class FieldErrors
        {
            public List<string> password { get; set; }
        }
    }
}
