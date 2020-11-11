using KingPimV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.ViewModels
{
    public class SubcategoriesViewModel
    {
        public List<Subcategory> AllSubCategories { get; set; }

        public List<Product> SubcategoryProducts { get; set; }
        public Subcategory SubCategory { get; set; }



        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public List<Product> Products { get; set; }
    }
}