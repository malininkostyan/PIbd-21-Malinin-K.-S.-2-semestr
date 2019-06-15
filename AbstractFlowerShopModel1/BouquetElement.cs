namespace AbstractFlowerShopModel1
{
    public class BouquetElement
    {
        public int Id { get; set; }
        public int BouquetId { get; set; }
        public int ElementId { get; set; }
        public int Amount { get; set; }
        public virtual Element Element { get; set; }
    }
}
