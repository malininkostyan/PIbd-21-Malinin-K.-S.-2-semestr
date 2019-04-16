using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class ElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
