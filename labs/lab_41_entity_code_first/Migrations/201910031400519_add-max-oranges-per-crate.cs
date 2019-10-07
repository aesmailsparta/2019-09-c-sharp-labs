namespace lab_41_entity_code_first.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmaxorangespercrate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orange", "MaxOrangesPerCrate", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orange", "MaxOrangesPerCrate");
        }
    }
}
