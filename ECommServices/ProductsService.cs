using ECommDatabase;
using ECommEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommServices
{
    public class ProductsService
    {
        public Product GetProduct(int ID)
        {
            using (var context = new ECContext())
            {
                return context.Products.Find(ID);
            }
        }

        public List<Product> GetProducts()
        {
            using (var context = new ECContext())
            { 
                return context.Products.ToList();
            }
        }

        public void SaveProduct(Product product)
        {
            using(var context = new ECContext())
            {
                //Add category to Categories entity ( it's in memory right now). Call save method to actually save into the DB
                context.Products.Add(product);
                //Save changes to the Database
                context.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var context = new ECContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                //Save changes to the Database
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new ECContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var product = context.Products.Find(ID);
                
                context.Products.Remove(product);
                //Save changes to the Database
                context.SaveChanges();
            }
        }
    }
}
