using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace OAuth.Provider.DAL
{
    public class TokenMapping : EntityTypeConfiguration<Token>
    {
        public TokenMapping()
        {
            this.ToTable("Tokens");
            this.HasKey(t => t.Id);
            this.Property(t => t.UserId).IsRequired();
            this.Property(t => t.WebsiteId).IsRequired();
            this.Property(t => t.OpenId).IsRequired();
            this.Property(t => t.AccessToken).IsRequired();
        }
    }
}