using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class BookingViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public int BouquetId { get; set; }
        [DataMember]
        public string BouquetName { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public string Status { get; set; }
        [DataMember]
        public string CreateDate{ get; set; }
        [DataMember]
        public string ImplementDate { get; set; }
    }
}
