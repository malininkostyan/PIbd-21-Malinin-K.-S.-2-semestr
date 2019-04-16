using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class StorageViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название склада")]
        [DataMember]
        public string StorageName { get; set; }
        [DataMember]
        public List<StorageElementViewModel> StorageElements { get; set; }
    }

}
