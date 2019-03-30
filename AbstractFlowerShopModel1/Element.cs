using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbstractFlowerShopModel1
{
    public class Element
    {
        public int Id { get; set; }

        [Required]
        public string ElementName { get; set; }

        public virtual List<BouquetElement> BouquetElements { get; set; }

        public virtual List<StorageElement> StorageElements { get; set; }
    }
}
