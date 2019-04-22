using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class BouquetElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int BouquetId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public string ElementName { get; set; }
        [DataMember]
        public int Amount { get; set; }
    }
}
