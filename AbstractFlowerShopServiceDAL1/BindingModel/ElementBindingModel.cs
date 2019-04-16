using System.Runtime.Serialization;
namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class ElementBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ElementName { get; set; }
    }
}
