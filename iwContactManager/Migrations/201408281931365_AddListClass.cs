namespace iwContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        ListName = c.String(),
                        ListDescription = c.String(),
                    })
                .PrimaryKey(t => t.ListId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lists");
        }
    }
}
