namespace cms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ll : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.adminlogins",
                c => new
                    {
                        loginid = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 200),
                        password = c.String(nullable: false, maxLength: 200),
                        email = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.loginid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.adminlogins");
        }
    }
}
