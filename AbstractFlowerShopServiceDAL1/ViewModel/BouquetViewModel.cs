using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class BouquetViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BouquetName { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public List<BouquetElementViewModel> BouquetElements { get; set; }
    }
}
