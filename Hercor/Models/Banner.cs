using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hercor.Models
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }
        [Display(Name ="Titulo")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Descripcion")]
        public string Description { get; set; }
        [Display(Name = "Imagen")]
        public string Image { get; set; }
        [Display(Name = "Habilitado")]
        public bool Eliminate { get; set; }
    }
}
