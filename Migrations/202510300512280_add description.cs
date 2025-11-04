namespace News_Article_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Description");
        }
    }
}
