namespace preview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class John : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        IdentityID = c.Int(nullable: false),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.IdentityID)
                .ForeignKey("dbo.Students", t => t.IdentityID)
                .Index(t => t.IdentityID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.StudentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Identities", "IdentityID", "dbo.Students");
            DropIndex("dbo.Identities", new[] { "IdentityID" });
            DropTable("dbo.Students");
            DropTable("dbo.Identities");
        }
    }
}
