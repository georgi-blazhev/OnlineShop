using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.Entities
{
    public class User : IdentityUser
    {
        public virtual List<Order>? Orders { get; set; }
        public virtual List<Product>? Favorites { get; set; }
        public virtual List<Review>? Reviews { get; set; }
    }
}
