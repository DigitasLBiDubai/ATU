namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedQuestionCategory : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.QuestionCategory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.QuestionCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TextText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
