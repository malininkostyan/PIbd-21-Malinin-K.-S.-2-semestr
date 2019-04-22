using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class BookingBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public int BouquetId { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal Total { get; set; }
    }
}
