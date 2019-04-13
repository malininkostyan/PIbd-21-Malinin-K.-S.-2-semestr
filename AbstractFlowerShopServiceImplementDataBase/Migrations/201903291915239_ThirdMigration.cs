namespace AbstractFlowerShopServiceImplementDataBase.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BouquetElements", "BouquetId", "dbo.Bouquets");
            DropIndex("dbo.BouquetElements", new[] { "BouquetId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.BouquetElements", "BouquetId");
            AddForeignKey("dbo.BouquetElements", "BouquetId", "dbo.Bouquets", "Id", cascadeDelete: true);
        }
    }
}
