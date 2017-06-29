using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using testXamarin.Common;

namespace testXamarin.Provider
{
    class ApiProvider
    {
        string url;
        string token_type;
        string access_token;

        public ApiProvider(string pUrl, string pToken_type, string pAccess_token)
        {
            this.url = pUrl;
            this.token_type = pToken_type;
            this.access_token = pAccess_token;
        }

        public string CallApi()
        {
            //ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
 
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(access_token))
                {
                    // Conver Token Object(json) to Class [{"access_token":"xxx", "token_type":"yyy", "expires_in":zzz}]
                    //var t = JsonConvert.DeserializeObject<Token>(token);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", token_type + " " + access_token);
                }
                var response = client.GetAsync(url).Result;
                return JsonProvider.FormatJson(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
