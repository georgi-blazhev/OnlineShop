using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public bool IsOnSale { get; set; }
        public double PriceOnSale { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Order> Orders { get; set; }
        public int CategoryId { get; set; }
    }
}
