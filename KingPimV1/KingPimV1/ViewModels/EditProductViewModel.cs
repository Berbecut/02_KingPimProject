using KingPimV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int SubCategoryId { get; set; }
        public Subcategory SubCategory { get; set; }
    }
}
