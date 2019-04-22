using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class StorageElementBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        public int Amount { get; set; }
    }
}
