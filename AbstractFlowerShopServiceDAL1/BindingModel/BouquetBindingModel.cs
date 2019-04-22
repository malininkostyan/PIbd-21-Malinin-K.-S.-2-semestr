using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class BouquetBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string BouquetName { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public List<BouquetElementBindingModel> BouquetElements { get; set; }
    }
}
