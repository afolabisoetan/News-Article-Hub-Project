namespace News_Article_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uniqueness : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Sources", "Name", c => c.String(maxLength: 200));
            AlterColumn("dbo.Topics", "Name", c => c.String(maxLength: 200));
            CreateIndex("dbo.Sources", "Name", unique: true);
            CreateIndex("dbo.Topics", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Topics", new[] { "Name" });
            DropIndex("dbo.Sources", new[] { "Name" });
            AlterColumn("dbo.Topics", "Name", c => c.String());
            AlterColumn("dbo.Sources", "Name", c => c.String());
        }
    }
}
