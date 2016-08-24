using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hercor.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime Create { get; set; }
        public DateTime Update { get; set; }

        public List<ArticleCategory> Categorys { get; set; }
    }
}