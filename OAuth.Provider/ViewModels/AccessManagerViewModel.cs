using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.ViewModels
{
    public class AccessManagerViewModel
    {
        public int WebsiteId { get; set; }
        /// <summary>
        /// 是否允许访问用户资料
        /// </summary>
        public bool AccessAccount { get; set; }
        /// <summary>
        /// 是否允许访问其他用户资源
        /// </summary>
        public bool AccessResource { get; set; }
    }
}