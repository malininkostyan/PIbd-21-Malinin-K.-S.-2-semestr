using System.Collections.Generic;
using System.ComponentModel;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    public class StorageViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название склада")]
        public string StorageName { get; set; }
        public List<StorageElementViewModel> StorageElements { get; set; }
    }
}
