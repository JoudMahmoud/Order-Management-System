using OrderManagementSystem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Entities
{
    public class Order:Base
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public Status Status { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public string CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        
        public virtual ICollection<OrderItem> Items { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}
