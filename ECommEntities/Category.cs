using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommEntities
{
  public class Category : BaseEntity
    {
        public string ImageURL { get; set; }
        public List<Product> Products { get; set; } // one category has multiple products
        public bool isFeatured { get; set; }
    }
}
