namespace iwContactManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AValidators", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.AValidators", "ValueToValidate", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AValidators", "ValueToValidate", c => c.String());
            AlterColumn("dbo.AValidators", "Description", c => c.String());
        }
    }
}
