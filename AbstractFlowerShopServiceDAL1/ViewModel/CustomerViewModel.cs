﻿using System.Collections.Generic;
using System.Runtime.Serialization;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    [DataContract]
    public class CustomerViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Mail { get; set; }
        [DataMember]
        public string CustomerFIO { get; set; }
        [DataMember]
        public List<InfoMessageViewModel> Messages { get; set; }
    }
}
