namespace News_Article_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pginit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "DateAdded", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "LockoutEndDateUtc", c => c.DateTime());
            AlterColumn("dbo.Articles", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
