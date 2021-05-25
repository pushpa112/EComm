using ECommEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommWeb.ViewModels
{
    public class HomeViewModels
    {
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
    }
}