using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Models
{
    public class Subcategory : BaseModel
    {
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Products { get; set; }
    }
}


