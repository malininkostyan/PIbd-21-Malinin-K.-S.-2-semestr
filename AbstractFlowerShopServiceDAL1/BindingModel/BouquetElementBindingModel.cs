namespace AbstractFlowerShopServiceDAL.BindingModel
{
    public class BouquetElementBindingModel
    {
        public int Id { get; set; }
        public int BouquetId { get; set; }
        public int ElementId { get; set; }
        public int Amount { get; set; }
    }
}
