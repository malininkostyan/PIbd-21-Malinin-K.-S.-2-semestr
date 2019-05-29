using System;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class InfoMessageViewModel
    {
        [DataMember]
        public string MessageId { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public DateTime DeliveryDate { get; set; }
        [DataMember]
        public string Subject { get; set; }
        [DataMember]
        public string Body { get; set; }
    }
}
