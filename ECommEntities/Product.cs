using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommEntities
{
   public class Product : BaseEntity
    {
        public Category Category { get; set; } // each product belongs to a category
        public decimal Price { get; set; }
    }
}
