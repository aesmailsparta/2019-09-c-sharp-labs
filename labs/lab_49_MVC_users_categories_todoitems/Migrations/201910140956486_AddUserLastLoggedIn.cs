namespace lab_49_MVC_users_categories_todoitems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLastLoggedIn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ToDoItems",
                c => new
                    {
                        ToDoItemID = c.Int(nullable: false, identity: true),
                        Item = c.String(maxLength: 50, unicode: false),
                        DateDue = c.DateTime(storeType: "date"),
                        Done = c.Boolean(),
                        UserID = c.Int(),
                        CategoryID = c.Int(),
                    })
                .PrimaryKey(t => t.ToDoItemID)
                .ForeignKey("dbo.Categories", t => t.CategoryID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        Username = c.String(maxLength: 50, unicode: false),
                        LastLoggedIn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ToDoItems", "UserID", "dbo.Users");
            DropForeignKey("dbo.ToDoItems", "CategoryID", "dbo.Categories");
            DropIndex("dbo.ToDoItems", new[] { "CategoryID" });
            DropIndex("dbo.ToDoItems", new[] { "UserID" });
            DropTable("dbo.Users");
            DropTable("dbo.ToDoItems");
            DropTable("dbo.Categories");
        }
    }
}
