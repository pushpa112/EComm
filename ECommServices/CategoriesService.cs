using ECommDatabase;
using ECommEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommServices
{
    public class CategoriesService
    {
        public Category GetCategory(int ID)
        {
            using (var context = new ECContext())
            {
                return context.Categories.Find(ID);
            }
        }

        public List<Category> GetCategories()
        {
            using (var context = new ECContext())
            { 
                return context.Categories.ToList();
            }
        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new ECContext())
            {
                return context.Categories.Where(x => x.isFeatured && x.ImageURL != null).ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using(var context = new ECContext())
            {
                //Add category to Categories entity ( it's in memory right now). Call save method to actually save into the DB
                context.Categories.Add(category);
                //Save changes to the Database
                context.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var context = new ECContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                //Save changes to the Database
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new ECContext())
            {
                //context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.Categories.Find(ID);
                
                context.Categories.Remove(category);
                //Save changes to the Database
                context.SaveChanges();
            }
        }
    }
}
