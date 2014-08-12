namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTextText : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.QuestionCategory", "TextText", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.QuestionCategory", "TextText");
        }
    }
}
