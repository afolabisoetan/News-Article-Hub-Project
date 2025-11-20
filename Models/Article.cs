using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Article_Project.Models
{
    public class Article
    {
        [Key]
        public Guid ArticleId { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Url { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty ;

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.Now;

        [Required]
        public int BiasValue { get; set; } // 1 = Left, 3 = Center, 5 = Right

        // Relationships
        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }

        public Guid SourceId { get; set; }
        public Source Source { get; set; }

        public Article()
        {
           ArticleId = Guid.NewGuid();
        }
    }

}