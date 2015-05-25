namespace OAuth.Provider.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accesstable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tokens", "Effective", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tokens", "Effective");
        }
    }
}
