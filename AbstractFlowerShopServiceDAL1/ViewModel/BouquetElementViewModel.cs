namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    public class BouquetElementViewModel
    {
        public int Id { get; set; }
        public int BouquetId { get; set; }
        public int ElementId { get; set; }
        public string ElementName { get; set; }
        public int Amount { get; set; }
    }
}
