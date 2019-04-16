using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class StorageBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string StorageName { get; set; }
    }
}
