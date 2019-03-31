using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AbstractFlowerShopModel1
{
    public class Bouquet
    {
        public int Id { get; set; }

        [Required]
        public string BouquetName { get; set; }
        
        [Required]
        public decimal Cost { get; set; }
        public virtual List<Booking> Bookings { get; set; }

    }
}
