using KingPimV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.ViewModels
{
    public class CategoriesViewModel
    {
        public Category Category { get; set; }
        public List<Category> AllCategories { get; set; }
    }
}
