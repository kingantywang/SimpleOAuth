namespace OAuth.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTokenInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Websites", "Name", c => c.String());
            AddColumn("dbo.Tokens", "TempCode", c => c.String());
            AddColumn("dbo.Tokens", "TempCodeExpire", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tokens", "RefreshCode", c => c.String());
            AddColumn("dbo.Tokens", "Expire", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tokens", "OpenId", c => c.Long(nullable: false));
            DropColumn("dbo.Tokens", "CreateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tokens", "CreateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Tokens", "OpenId", c => c.String(nullable: false));
            DropColumn("dbo.Tokens", "Expire");
            DropColumn("dbo.Tokens", "RefreshCode");
            DropColumn("dbo.Tokens", "TempCodeExpire");
            DropColumn("dbo.Tokens", "TempCode");
            DropColumn("dbo.Websites", "Name");
        }
    }
}
