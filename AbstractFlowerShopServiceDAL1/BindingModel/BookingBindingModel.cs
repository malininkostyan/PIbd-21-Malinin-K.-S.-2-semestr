namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    public class BookingBindingModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BouquetId { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}
