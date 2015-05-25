using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.ApiModels
{
    /// <summary>
    /// 一般请求类
    /// </summary>
    public class CommonRequest
    {
        public long OpenId { get; set; }
        public string AccessToken { get; set; }
        public string ClientId { get; set; }
    }
}