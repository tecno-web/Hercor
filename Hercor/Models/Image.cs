using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hercor.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        [Display(Name = "Imagen")]
        [Required]
        public string ImageProduct { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}