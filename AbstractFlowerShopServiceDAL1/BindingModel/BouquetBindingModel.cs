using System.Collections.Generic;

namespace AbstractFlowerShopServiceDAL1.BindingModel
{
    public class BouquetBindingModel
    {
        public int Id { get; set; }
        public string BouquetName { get; set; }
        public decimal Cost { get; set; }
        public List<BouquetElementBindingModel> BouquetElements { get; set; }
    }
}
