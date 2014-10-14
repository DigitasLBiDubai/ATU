namespace ATU.Domain.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFaqProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Question", "Faq", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Question", "Faq");
        }
    }
}