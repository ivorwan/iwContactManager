namespace iwContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DupeListValidator", "DupeListId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DupeListValidator", "DupeListId", c => c.String());
        }
    }
}
