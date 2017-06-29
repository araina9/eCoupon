using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using testXamarin.Common;
using testXamarin.Provider;
using Xamarin.Forms;

namespace testXamarin
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        
        public void OnLogin(object o, EventArgs e)
        {
            TokenProvider tokenProvider = new TokenProvider("https://ecoupon.bdms.co.th/eCouponApi/Token", txtUserName.Text, txtPassword.Text);
            var token1 = tokenProvider.GetToken();
            
            JObject information = JObject.Parse(token1);
            Token tt = information.ToObject<Token>();
            
            Token t = JsonConvert.DeserializeObject<Token>(token1);

            ApiProvider apiProvider = new ApiProvider("https://ecoupon.bdms.co.th/eCouponApi/api/couponsNew", t.token_type, t.access_token);
            txtToken.Text = apiProvider.CallApi();
        }
        
    }
}
