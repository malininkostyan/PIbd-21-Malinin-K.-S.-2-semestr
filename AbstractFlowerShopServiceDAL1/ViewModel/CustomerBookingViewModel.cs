using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class CustomerBookingViewModel
    {
        [DataMember]
        public string CustomerName { get; set; }
        [DataMember]
        public string CreateDate { get; set; }
        [DataMember]
        public string BouquetName { get; set; }
        [DataMember]
        public int Amount { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
