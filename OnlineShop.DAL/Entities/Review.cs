using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Entities
{
    public class Review : BaseEntity
    {
        public string? Description { get; set; }
        public int ProductQualityRating { get; set; }
        public int RetailerCustomerServiceRating { get; set; }
        public int DeliveryTimeRating { get; set; }
        public int DeliveryServiceRating { get; set; }
        public virtual User Author { get; set; }
        public string AuthorId { get; set; }
        public virtual Order Order { get; set; }
        public int OrderId { get; set; }
    }
}
