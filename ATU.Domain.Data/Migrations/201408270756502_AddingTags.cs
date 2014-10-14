namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 60),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagQuestions",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Question_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Question_Id })
                .ForeignKey("dbo.Tag", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Question", t => t.Question_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Question_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagQuestions", "Question_Id", "dbo.Question");
            DropForeignKey("dbo.TagQuestions", "Tag_Id", "dbo.Tag");
            DropIndex("dbo.TagQuestions", new[] { "Question_Id" });
            DropIndex("dbo.TagQuestions", new[] { "Tag_Id" });
            DropTable("dbo.TagQuestions");
            DropTable("dbo.Tag");
        }
    }
}
