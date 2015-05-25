using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.Models
{
    public class ThirdpartWebsite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 访问标识用于验证网站
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 返回地址Url 
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}