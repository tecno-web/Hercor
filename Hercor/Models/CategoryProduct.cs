using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hercor.Models
{
    public class CategoryProduct
    {
        [Key]
        public int IdCategoryProduct { get; set; }
        [Display(Name="Nombre")]
        public string Name { get; set; }
        [Display(Name ="Descripcion")]
        public string Description { get; set; }
        public string slug { get; set; }
        public List<CategoryProductPivot> Product { get; set; }
    }
}