using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Domain.Entities
{
    public class Invoice:Base
    {
        public decimal TotalAmount {  get; set; }
        public DateTime? InvoiceDate { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
