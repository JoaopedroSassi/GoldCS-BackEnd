using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldCS.Domain.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; } = true; 
        public DateTime InclusionDate { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
