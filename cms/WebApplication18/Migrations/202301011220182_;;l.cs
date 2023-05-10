namespace cms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class l : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pagecomments",
                c => new
                    {
                        commentid = c.Int(nullable: false, identity: true),
                        pageid = c.Int(nullable: false),
                        name = c.String(nullable: false, maxLength: 150),
                        email = c.String(nullable: false, maxLength: 150),
                        website = c.String(nullable: false, maxLength: 200),
                        comment = c.String(nullable: false, maxLength: 500),
                        createdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.commentid)
                .ForeignKey("dbo.pages", t => t.pageid, cascadeDelete: true)
                .Index(t => t.pageid);
            
            CreateTable(
                "dbo.pages",
                c => new
                    {
                        pageid = c.Int(nullable: false, identity: true),
                        groupid = c.Int(nullable: false),
                        title = c.String(nullable: false, maxLength: 250),
                        shortdescription = c.String(nullable: false, maxLength: 350),
                        text = c.String(nullable: false),
                        visit = c.Int(nullable: false),
                        imagename = c.String(),
                        showinslider = c.Boolean(nullable: false),
                        createdate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.pageid)
                .ForeignKey("dbo.pagegroups", t => t.groupid, cascadeDelete: true)
                .Index(t => t.groupid);
            
            CreateTable(
                "dbo.pagegroups",
                c => new
                    {
                        groupid = c.Int(nullable: false, identity: true),
                        grouptitle = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.groupid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pages", "groupid", "dbo.pagegroups");
            DropForeignKey("dbo.pagecomments", "pageid", "dbo.pages");
            DropIndex("dbo.pages", new[] { "groupid" });
            DropIndex("dbo.pagecomments", new[] { "pageid" });
            DropTable("dbo.pagegroups");
            DropTable("dbo.pages");
            DropTable("dbo.pagecomments");
        }
    }
}
