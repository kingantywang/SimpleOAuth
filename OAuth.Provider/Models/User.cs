using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// 模拟用户资源
        /// </summary>
        public string Resoure { get; set; }
    }
}