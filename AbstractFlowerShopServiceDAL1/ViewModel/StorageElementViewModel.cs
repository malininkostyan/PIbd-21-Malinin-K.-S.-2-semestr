using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class StorageElementViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int StorageId { get; set; }
        [DataMember]
        public int ElementId { get; set; }
        [DataMember]
        [DisplayName("Название компонента")]
        public string ElementName { get; set; }
        [DataMember]
        [DisplayName("Количество")]
        public int Amount { get; set; }
    }

}
