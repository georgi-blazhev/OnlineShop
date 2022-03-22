using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Entities
{
    public class Order : BaseEntity
    {
        public OrderStatus Status { get; set; }
        public virtual Review? Review { get; set; }
        public int ReviewId { get; set; }
        public virtual User Customer { get; set; }
        public string CustomerId { get; set; }
        public virtual List<Product> OrderedProducts { get; set; }
    }

    public enum OrderStatus
    {
        Pending, Accepted, Rejected, OnItsWay, Delivered, Cancelled
    }
}
