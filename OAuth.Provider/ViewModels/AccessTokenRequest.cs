using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.ViewModels
{
    public class AccessTokenRequest
    {
        public long OpenId { get; set; }
        public string Code { get; set; }
        public string ClientId { get; set; }
        public string ReturnUrl { get; set; }
    }
}