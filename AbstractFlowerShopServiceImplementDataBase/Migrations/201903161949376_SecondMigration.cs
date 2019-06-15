namespace AbstractFlowerShopServiceImplementDataBase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bouquets", "BouquetName", c => c.String(nullable: false));
            AlterColumn("dbo.Elements", "ElementName", c => c.String(nullable: false));
            AlterColumn("dbo.Storages", "StorageName", c => c.String(nullable: false));
            CreateIndex("dbo.BouquetElements", "BouquetId");
            CreateIndex("dbo.BouquetElements", "ElementId");
            CreateIndex("dbo.StorageElements", "StorageId");
            CreateIndex("dbo.StorageElements", "ElementId");
            AddForeignKey("dbo.BouquetElements", "BouquetId", "dbo.Bouquets", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BouquetElements", "ElementId", "dbo.Elements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StorageElements", "ElementId", "dbo.Elements", "Id", cascadeDelete: true);
            AddForeignKey("dbo.StorageElements", "StorageId", "dbo.Storages", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StorageElements", "StorageId", "dbo.Storages");
            DropForeignKey("dbo.StorageElements", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.BouquetElements", "ElementId", "dbo.Elements");
            DropForeignKey("dbo.BouquetElements", "BouquetId", "dbo.Bouquets");
            DropIndex("dbo.StorageElements", new[] { "ElementId" });
            DropIndex("dbo.StorageElements", new[] { "StorageId" });
            DropIndex("dbo.BouquetElements", new[] { "ElementId" });
            DropIndex("dbo.BouquetElements", new[] { "BouquetId" });
            AlterColumn("dbo.Storages", "StorageName", c => c.String());
            AlterColumn("dbo.Elements", "ElementName", c => c.String());
            AlterColumn("dbo.Bouquets", "BouquetName", c => c.String());
        }
    }
}
