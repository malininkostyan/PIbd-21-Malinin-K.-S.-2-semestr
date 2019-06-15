namespace AbstractFlowerShopServiceDAL.ViewModel
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFIO { get; set; }
        public int BouquetId { get; set; }
        public string BouquetName { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
        public string Status { get; set; }
        public string CreateDate{ get; set; }
        public string ImplementDate { get; set; }
    }
}
