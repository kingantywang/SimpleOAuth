using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.ViewModels
{
    public class AccessTempTokenRequest
    {
        /// <summary>
        /// 第三方网站的Client Id
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 用于接受临时Code的地址
        /// </summary>
        public string ReturnUrl { get; set; }
        /// <summary>
        /// 必须为Code
        /// </summary>
        public string ResponseType { get; set; }
    }
}