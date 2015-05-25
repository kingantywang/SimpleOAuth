using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace OAuth.Provider.Models
{
    public class UserSessionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        internal static UserSessionModel GetCurrentUser()
        {
            var userData = HttpContext.Current.Request.Cookies.Get("AccountInfo");
            if (userData == null)
                return null;
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<UserSessionModel>(userData.Value);
        }
        internal static int GetUserId()
        {
            if (GetCurrentUser() == null)
                return 0;
            return GetCurrentUser().Id;
        }
    }
}