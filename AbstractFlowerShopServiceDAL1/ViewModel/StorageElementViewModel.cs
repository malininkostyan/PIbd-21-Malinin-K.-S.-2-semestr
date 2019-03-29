using System.ComponentModel;

namespace AbstractFlowerShopServiceDAL1.ViewModel
{
    public class StorageElementViewModel
    {
        public int Id { get; set; }
        public int StorageId { get; set; }
        public int ElementId { get; set; }
        [DisplayName("Название компонента")]
        public string ElementName { get; set; } 
        [DisplayName("Количество")]
        public int Amount { get; set; }
    }

}
