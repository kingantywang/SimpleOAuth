using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OAuth.Provider.DAL
{
    public class OAuthDbContext : DbContext
    {
        public OAuthDbContext()
            : base("name=OAuthDbContext")
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<ThirdpartWebsite> Websites { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<User>(new UserMapping());
            modelBuilder.Configurations.Add<Token>(new TokenMapping());
            modelBuilder.Configurations.Add<ThirdpartWebsite>(new WebsiteMapping());
        }
    }
}