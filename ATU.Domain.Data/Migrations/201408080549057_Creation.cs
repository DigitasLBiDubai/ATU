namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Creation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Verified = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        Question_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Question", t => t.Question_Id)
                .Index(t => t.Question_Id);
            
            CreateTable(
                "dbo.Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Request",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 200),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(nullable: false, maxLength: 40),
                        Url = c.String(nullable: false, maxLength: 80),
                        Email = c.String(nullable: false, maxLength: 100),
                        RequestType = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedUtc = c.DateTime(nullable: false),
                        LastModifiedUtc = c.DateTime(nullable: false),
                        From_UserId = c.Int(),
                        To_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.From_UserId)
                .ForeignKey("dbo.User", t => t.To_UserId)
                .Index(t => t.From_UserId)
                .Index(t => t.To_UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserProfile_Id = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.UserProfile", t => t.UserProfile_Id)
                .Index(t => t.UserProfile_Id);
            
            CreateTable(
                "dbo.UserProfile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 100),
                        PhoneNumber = c.String(maxLength: 40),
                        DateCreatedUtc = c.DateTime(nullable: false),
                        LastModifiedUtc = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Request", "To_UserId", "dbo.User");
            DropForeignKey("dbo.Request", "From_UserId", "dbo.User");
            DropForeignKey("dbo.User", "UserProfile_Id", "dbo.UserProfile");
            DropForeignKey("dbo.Answer", "Question_Id", "dbo.Question");
            DropIndex("dbo.User", new[] { "UserProfile_Id" });
            DropIndex("dbo.Request", new[] { "To_UserId" });
            DropIndex("dbo.Request", new[] { "From_UserId" });
            DropIndex("dbo.Answer", new[] { "Question_Id" });
            DropTable("dbo.UserProfile");
            DropTable("dbo.User");
            DropTable("dbo.Request");
            DropTable("dbo.Question");
            DropTable("dbo.Answer");
        }
    }
}
