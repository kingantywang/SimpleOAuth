using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.Models
{
    public class Token
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int WebsiteId { get; set; }
        /// <summary>
        /// User 的OpenId
        /// </summary>
        public long OpenId { get; set; }
        /// <summary>
        /// 临时Code 用于获取AccessToken
        /// </summary>
        public string TempCode { get; set; }
        /// <summary>
        /// 临时Code过期时间
        /// </summary>
        public DateTime TempCodeExpire { get; set; }
        /// <summary>
        /// 用于第三方网站刷新AccessToken 用
        /// </summary>
        public string RefreshCode { get; set; }
        /// <summary>
        /// Access Token 用于第三方网站配合OpenId 获取资源
        /// </summary>
        public string AccessToken { get; set; }
        /// <summary>
        /// Access Token 的生成时间用于服务端验证是否过去
        /// </summary>
        public DateTime Expire { get; set; }
        /// <summary>
        /// 权限 是否能获取用户资源
        /// </summary>
        public bool Scope { get; set; }
        /// <summary>
        /// 是否起效 只有当TempCode验证过后才起效
        /// </summary>
        public bool Effective { get; set; }
    }
}