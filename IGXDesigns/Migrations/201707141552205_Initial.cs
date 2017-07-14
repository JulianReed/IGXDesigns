namespace IGXDesigns.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Designer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "Designer");
        }
    }
}
