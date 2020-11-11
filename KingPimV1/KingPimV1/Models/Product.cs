using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Models
{
    public class Product : BaseModel
    {
        public IdentityUser ModifiedBy { get; set; }

        //[Required(ErrorMessage = "Du måste ange ett artikelnummer")]
        public string ArticleNumber { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime CampaignStartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime CampaignEndDate { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }

        public bool Discontinued { get; set; }

        public int DiscountPercentage { get; set; }
        public int StockBalance { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Depth { get; set; }
        public decimal Weight { get; set; }
        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }
    }
}
