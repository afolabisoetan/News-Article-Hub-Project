namespace News_Article_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class biasvalue : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "BiasValue", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "BiasValue");
        }
    }
}
