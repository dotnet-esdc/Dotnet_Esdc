namespace Lesson8_InventorySystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EquipmentDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        Name = c.String(),
                        PropertyType = c.Int(nullable: false),
                        DoubleVal = c.Double(),
                        StringVal = c.String(),
                        DateTimeVal = c.DateTime(),
                        BoolVal = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryFacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EquipmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .Index(t => t.EquipmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryFacts", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.EquipmentDetails", "EquipmentId", "dbo.Equipments");
            DropIndex("dbo.InventoryFacts", new[] { "EquipmentId" });
            DropIndex("dbo.EquipmentDetails", new[] { "EquipmentId" });
            DropTable("dbo.InventoryFacts");
            DropTable("dbo.Equipments");
            DropTable("dbo.EquipmentDetails");
        }
    }
}
