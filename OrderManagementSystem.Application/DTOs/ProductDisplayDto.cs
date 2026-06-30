using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Application.DTOs
{
    public class ProductDisplayDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

    }
}
