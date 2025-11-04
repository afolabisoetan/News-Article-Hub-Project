using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Article_Project.Models
{
    public class Source
    {
        [Key]
        public Guid SourceId { get; set; }

        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public string Bias { get; set; } = "Center"; // Left, Right, Center, etc.
        public string Website { get; set; } = string.Empty;

        public List<Article> Articles { get; set; } = new List<Article>();

        public Source()
        {
            SourceId = Guid.NewGuid();
        }
    }

}