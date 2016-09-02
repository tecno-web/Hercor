using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hercor.Models
{
    public enum Page
    {
        Hercor = 0,
        Ricort = 1,
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "Titulo")]
        public string Title { get; set; }
        [Display(Name = "Descripcion Corta")]
        public string Description { get; set; }
        [Display(Name = "Contenido")]
        [AllowHtml]
        public string Content { get; set; }
        public string Slug { get; set; }
        public string Image { get; set; }
        [Display(Name = "Pagina")]
        public Page Page { get; set; }
        [Display(Name = "Habilitado")]
        public bool Eliminate { get; set; }
        public List<CategoryProductPivot> CategoryProduct { get; set; }
    }
    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 3; //3 MB
            string[] AllowedFileExtensions = new string[] { ".jpg", ".gif", ".png", ".pdf" };

            var file = value as HttpPostedFileBase;

            if (file == null)
                return false;
            else if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (MaxContentLength / 1024).ToString() + "MB";
                return false;
            }
            else
                return true;
        }
    }
}