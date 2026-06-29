using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Entities
{
    public class OrderItem:Base
    {



        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
