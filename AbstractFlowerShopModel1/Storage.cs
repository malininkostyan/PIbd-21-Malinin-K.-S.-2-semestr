using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractFlowerShopModel1
{
    public class Storage
    {
        public int Id { get; set; }

        [Required]
        public string StorageName { get; set; }
        public virtual List<StorageElement> StorageElements { get; set; }
    }
}
