using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ThirdWebSiteA.Models
{
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// 自身平台账户名
        /// </summary>
        public string Name { get; set; }
        public string Password { get; set; }
        public string Mark { get; set; }
        public string AccessToken { get; set; }
    }
}