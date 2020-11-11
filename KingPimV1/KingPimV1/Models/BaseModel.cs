using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KingPimV1.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Du måste ange ett namn")]
        public string Name { get; set; }
        public bool Published { get; set; }
    }
}
