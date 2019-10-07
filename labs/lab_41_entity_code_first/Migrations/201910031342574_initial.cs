namespace lab_41_entity_code_first.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        BatchID = c.Int(nullable: false, identity: true),
                        OrangeID = c.Int(),
                        Quantity = c.Int(),
                        DispatchDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.BatchID)
                .ForeignKey("dbo.Orange", t => t.OrangeID)
                .Index(t => t.OrangeID);
            
            CreateTable(
                "dbo.Orange",
                c => new
                    {
                        OrangeID = c.Int(nullable: false, identity: true),
                        OrangeName = c.String(maxLength: 50),
                        DateHarvested = c.DateTime(storeType: "date"),
                        IsLuxuryGrade = c.Boolean(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.OrangeID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orange", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Batch", "OrangeID", "dbo.Orange");
            DropIndex("dbo.Orange", new[] { "CategoryID" });
            DropIndex("dbo.Batch", new[] { "OrangeID" });
            DropTable("dbo.Categories");
            DropTable("dbo.Orange");
            DropTable("dbo.Batch");
        }
    }
}
