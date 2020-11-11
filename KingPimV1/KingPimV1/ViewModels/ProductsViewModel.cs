using KingPimV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.ViewModels
{
    public class ProductsViewModel
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int SubcategoryId { get; set; }
        public Subcategory SubCategory { get; set; }
    }
}
