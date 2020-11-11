using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Models
{
    public class Category : BaseModel
    {
        public List<Subcategory> SubCategories { get; set; }

    }
}
