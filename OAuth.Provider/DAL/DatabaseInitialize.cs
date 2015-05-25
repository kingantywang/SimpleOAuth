using OAuth.Provider.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OAuth.Provider.DAL
{
    public class DatabaseInitialize : CreateDatabaseIfNotExists<OAuthDbContext>
    {
        protected override void Seed(OAuthDbContext context)
        {
            context.Database.CreateIfNotExists();
            context.Users.Add(new User { Name = "xiongkailing", Password = "123456", Resoure = "Fake Resource" });
            context.SaveChanges();
        }
    }
}