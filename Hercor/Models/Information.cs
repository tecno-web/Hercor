using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hercor.Models
{
    public class Information
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Mision")]
        [AllowHtml]
        public string Mission { get; set; }
        [Display(Name = "Vision")]
        [AllowHtml]
        public string Vision { get; set; }
        [Display(Name = "Historia")]
        [AllowHtml]
        public string History { get; set; }
    }
}