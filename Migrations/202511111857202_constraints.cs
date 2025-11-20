namespace News_Article_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class constraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Url", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Sources", "Bias", c => c.String(nullable: false));
            AlterColumn("dbo.Sources", "Website", c => c.String(nullable: false));
            AlterColumn("dbo.Topics", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Topics", "Description", c => c.String());
            AlterColumn("dbo.Sources", "Website", c => c.String());
            AlterColumn("dbo.Sources", "Bias", c => c.String());
            AlterColumn("dbo.Articles", "Description", c => c.String());
            AlterColumn("dbo.Articles", "Url", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
        }
    }
}
