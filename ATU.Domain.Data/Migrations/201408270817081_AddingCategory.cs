namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Question", "Category_Id", c => c.Int());
            CreateIndex("dbo.Question", "Category_Id");
            AddForeignKey("dbo.Question", "Category_Id", "dbo.Category", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Question", "Category_Id", "dbo.Category");
            DropIndex("dbo.Question", new[] { "Category_Id" });
            DropColumn("dbo.Question", "Category_Id");
            DropTable("dbo.Category");
        }
    }
}
