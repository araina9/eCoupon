using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace testXamarin.Provider
{
    class TokenProvider
    {
        string url;
        string userName;
        string password;

        public TokenProvider(string pUrl, string pUserName, string pPassword)
        {
            url = pUrl;
            userName = pUserName;
            password = pPassword;
        }

        public string GetToken()
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", userName ),
                        new KeyValuePair<string, string> ( "Password", password )
                    };
            var content = new FormUrlEncodedContent(pairs);

            //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //System.Net.ServicePointManager.ServerCertificateValidationCallback =
            //    new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });
            //System.Net.ServicePointManager.ServerCertificateValidationCallback += (se, cert, chain, sslerror) => { return true; };
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public string GetTokenFormat()
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", userName ),
                        new KeyValuePair<string, string> ( "Password", password )
                    };
            var content = new FormUrlEncodedContent(pairs);

            //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            //System.Net.ServicePointManager.ServerCertificateValidationCallback =
            //    new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; });

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, content).Result;
                return JsonProvider.FormatJson(response.Content.ReadAsStringAsync().Result);
            }
        }
    }
}
