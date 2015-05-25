using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OAuth.Provider.DAL
{
    public class WebsiteMapping : EntityTypeConfiguration<ThirdpartWebsite>
    {
        public WebsiteMapping()
        {
            this.ToTable("Websites");
            this.HasKey(w => w.Id);
        }
    }
}