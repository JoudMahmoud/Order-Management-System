using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Entities
{
    public class Customer:User
    {
        public virtual ICollection<Order> Orders { get; set; }
    }
}
