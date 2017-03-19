namespace Stories.DataModels.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "Deleted", c => c.Boolean(nullable: false, defaultValue:false));
            AddColumn("dbo.Users", "Deleted", c => c.Boolean(nullable: false, defaultValue: false));
            AddColumn("dbo.Stories", "Deleted", c => c.Boolean(nullable: false, defaultValue: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "Deleted");
            DropColumn("dbo.Users", "Deleted");
            DropColumn("dbo.Groups", "Deleted");
        }
    }
}
