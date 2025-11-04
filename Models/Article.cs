using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Article_Project.Models
{
    public class Article
    {
        public Guid ArticleId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty ;
        public DateTime DateAdded { get; set; } = DateTime.Now;

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