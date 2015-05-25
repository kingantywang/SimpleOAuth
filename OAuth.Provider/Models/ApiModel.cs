using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OAuth.Provider.Models
{
    public class ApiModel<T> where T : class
    {
        public bool Success { get; set; }
        public T Content { get; set; }
    }
}