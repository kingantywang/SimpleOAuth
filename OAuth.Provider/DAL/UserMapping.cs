using OAuth.Provider.Models;
using System.Data.Entity.ModelConfiguration;

namespace OAuth.Provider.DAL
{
    public class UserMapping:EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            this.ToTable("Users");
            this.HasKey(u => u.Id);
            this.Property(u => u.Name).IsRequired().HasMaxLength(18);
            this.Property(u => u.Password).IsRequired();
        }
    }
}