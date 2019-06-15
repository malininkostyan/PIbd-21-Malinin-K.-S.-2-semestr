using System.Collections.Generic;
using AbstractFlowerShopModel;
using AbstractFlowerShopModel1;

namespace AbstractFlowerShopServiceImplementList
{
    public class SingleDataList
    {
        private static SingleDataList exemplar;
        public List<Customer> Customers { get; set; }
        public List<Element> Elements { get; set; }
        public List<Booking> Bookings { get; set; }
        public List<Bouquet> Bouquets { get; set; }
        public List<BouquetElement> BouquetElements { get; set; }
        public List<Storage> Storages { get; set; }
        public List<StorageElement> StorageElements { get; set; }
        private SingleDataList()
        {
            Customers = new List<Customer>();
            Elements = new List<Element>();
            Bookings = new List<Booking>();
            Bouquets = new List<Bouquet>();
            BouquetElements = new List<BouquetElement>();
            Storages = new List<Storage>();
            StorageElements = new List<StorageElement>();
        }
        public static SingleDataList GetInstance()
        {
            if (exemplar == null)
            {
                exemplar = new SingleDataList();
            }
            return exemplar;
        }
    }
}
