using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hercor.Models
{
    public class CategoryProductPivot
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int IdCategoryProduct { get; set; }
        public CategoryProduct CategoryProduct { get; set; }
    }
}