namespace Transience.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TestMemories",
                c => new
                    {
                        Test_Id = c.Int(nullable: false),
                        Memory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_Id, t.Memory_Id })
                .ForeignKey("dbo.Tests", t => t.Test_Id, cascadeDelete: true)
                .ForeignKey("dbo.Memories", t => t.Memory_Id, cascadeDelete: true)
                .Index(t => t.Test_Id)
                .Index(t => t.Memory_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestMemories", "Memory_Id", "dbo.Memories");
            DropForeignKey("dbo.TestMemories", "Test_Id", "dbo.Tests");
            DropIndex("dbo.TestMemories", new[] { "Memory_Id" });
            DropIndex("dbo.TestMemories", new[] { "Test_Id" });
            DropTable("dbo.TestMemories");
            DropTable("dbo.Tests");
        }
    }
}
