using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommEntities
{
   public class Product : BaseEntity
    {
        public decimal Price { get; set; }

        //virtual keyword: category object always attach with the product object

        //entity framework won't create the new column, it will rename the ID to CategoryID
       // public int CategoryID { get; set; }
        public virtual Category Category { get; set; } // each product belongs to a category
        
    }
}
