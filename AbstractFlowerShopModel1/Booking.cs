using System;

namespace AbstractFlowerShopModel1
{
    public class Booking
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BouquetId { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
        public BookingStatus Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ImplementDate { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Bouquet Bouquet { get; set; }
    }
}
