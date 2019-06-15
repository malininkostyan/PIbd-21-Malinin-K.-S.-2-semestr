namespace AbstractFlowerShopServiceImplementDataBase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        BouquetId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ImplementDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bouquets", t => t.BouquetId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.BouquetId);
            
            CreateTable(
                "dbo.Bouquets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BouquetName = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFIO = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BouquetElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BouquetId = c.Int(nullable: false),
                        ElementId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Elements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ElementName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StorageElements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageId = c.Int(nullable: false),
                        ElementId = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Storages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StorageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "BouquetId", "dbo.Bouquets");
            DropIndex("dbo.Bookings", new[] { "BouquetId" });
            DropIndex("dbo.Bookings", new[] { "CustomerId" });
            DropTable("dbo.Storages");
            DropTable("dbo.StorageElements");
            DropTable("dbo.Elements");
            DropTable("dbo.BouquetElements");
            DropTable("dbo.Customers");
            DropTable("dbo.Bouquets");
            DropTable("dbo.Bookings");
        }
    }
}
