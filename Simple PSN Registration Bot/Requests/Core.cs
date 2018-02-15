using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Simple_PSN_Registration_Bot.Requests
{
    internal static class Core
    {
        private static HttpRequestMessage SetupRequest(HttpMethod method, string url, Dictionary<string, string> data = null, bool json = false, Dictionary<string, string> headers = null)
        {
            HttpRequestMessage request = new HttpRequestMessage();

            request.Method = method;

            if (method == HttpMethod.Get & data != null)
            {
                url = url + "?";
                foreach (var query in data.ToKeyValue())
                {
                    url = url + query.Key + "=" + query.Value + "&";
                }
                url = url.TrimEnd('&');
            }
            else if (data != null & json)
                request.Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            else if (data != null)
                request.Content = new FormUrlEncodedContent(data);

            if (headers != null)
            {
                foreach (var header in headers)
                    request.Headers.Add(header.Key, header.Value);
            }

            request.RequestUri = new Uri(url);

            return request;
        }
        private static HttpClient SetupClient(CookieContainer cookies = null)
        {
            HttpClientHandler handler = new HttpClientHandler();
            HttpClient client = new HttpClient(handler);

            handler.AllowAutoRedirect = true;
            handler.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            handler.UseCookies = true;

            if (cookies != null)
                handler.CookieContainer = cookies;
            else
                handler.CookieContainer = new CookieContainer();

            return client;
        }
        internal static async Task<HttpResponseMessage> SendGetRequest(string url, Dictionary<string, string> data = null, bool json = false, Dictionary<string, string> headers = null, CookieContainer cookies = null)
        {
            HttpRequestMessage request = SetupRequest(HttpMethod.Get, url, data, json, headers);
            HttpClient client = SetupClient(cookies);

            return await client.SendAsync(request);
        }
        internal static async Task<HttpResponseMessage> SendPostRequest(string url, Dictionary<string, string> data = null, bool json = false, Dictionary<string, string> headers = null, CookieContainer cookies = null)
        {
            HttpRequestMessage request = SetupRequest(HttpMethod.Post, url, data, json, headers);
            HttpClient client = SetupClient(cookies);

            return await client.SendAsync(request);
        }
        private static IDictionary<string, string> ToKeyValue(this object metaToken)
        {
            if (metaToken == null)
            {
                return null;
            }

            JToken token = metaToken as JToken;
            if (token == null)
            {
                return ToKeyValue(JObject.FromObject(metaToken));
            }

            if (token.HasValues)
            {
                var contentData = new Dictionary<string, string>();
                foreach (var child in token.Children().ToList())
                {
                    var childContent = child.ToKeyValue();
                    if (childContent != null)
                    {
                        contentData = contentData.Concat(childContent)
                                                 .ToDictionary(k => k.Key, v => v.Value);
                    }
                }

                return contentData;
            }

            var jValue = token as JValue;
            if (jValue?.Value == null)
            {
                return null;
            }

            var value = jValue?.Type == JTokenType.Date ?
                            jValue?.ToString("o", CultureInfo.InvariantCulture) :
                            jValue?.ToString(CultureInfo.InvariantCulture);

            return new Dictionary<string, string> { { token.Path, value } };
        }
    }
}
