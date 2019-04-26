using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    [DataContract]
    public class ExecutorBindingModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ExecutorFIO { get; set; }
    }
}
