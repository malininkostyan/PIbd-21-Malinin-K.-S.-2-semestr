using System;

namespace AbstractFlowerShopModel1
{
    public class InfoMessage
    {
        public int Id { get; set; }
        public string MessageId { get; set; }
        public string FromMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int? CustomerId { get; set; }
        public virtual Customer Customers { get; set; }
    }
}
