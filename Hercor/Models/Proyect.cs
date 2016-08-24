using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hercor.Models
{
    public class Proyect
    {
        [Key]
        public int ProyectId { get; set; }
        [Display(Name = "Titulo")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Descripcion")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Latitud")]
        [Required]
        public string Latitude { get; set; }
        [Display(Name = "Longitud")]
        [Required]
        public string Longitude { get; set; }
    }
}