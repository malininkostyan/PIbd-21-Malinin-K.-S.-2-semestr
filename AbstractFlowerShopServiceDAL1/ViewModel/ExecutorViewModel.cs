using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class ExecutorViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string ExecutorFIO { get; set; }
    }
}
