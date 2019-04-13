using System;
using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    public class LoadStoragesViewModel
    {
        public string StorageName { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<Tuple<string, int>> Elements { get; set; }
    }

}
