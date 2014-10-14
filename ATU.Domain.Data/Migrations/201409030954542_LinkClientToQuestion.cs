namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkClientToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "Poster_Id", c => c.Int(nullable: true));
            CreateIndex("dbo.Question", "Poster_Id");
            AddForeignKey("dbo.Question", "Poster_Id", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "Poster_Id", "dbo.Clients");
            DropIndex("dbo.Question", new[] { "Poster_Id" });
            DropColumn("dbo.Question", "Poster_Id");
        }
    }
}
