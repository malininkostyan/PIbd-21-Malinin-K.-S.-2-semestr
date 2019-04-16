using System;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class LogBindingModel
    {
        [DataMember]
        public string FileName { get; set; }
        [DataMember]
        public DateTime? DateFrom { get; set; }
        [DataMember]
        public DateTime? DateTo { get; set; }
    }
}
