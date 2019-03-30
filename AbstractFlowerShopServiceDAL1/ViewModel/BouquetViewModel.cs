using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    public class BouquetViewModel
    {
        public int Id { get; set; }
        public string BouquetName { get; set; }
        public decimal Cost { get; set; }
        public List<BouquetElementViewModel> BouquetElements { get; set; }
    }
}
