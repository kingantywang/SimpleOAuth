using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.ViewModels
{
    public class AccessTokenResponse
    {
        public long OpenId { get; set; }
        public string RefreshCode { get; set; }
        public string AccessToken { get; set; }
        public DateTime Expire { get; set; }
    }
}