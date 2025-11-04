using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Article_Project.Models
{
    public class Topic
    {
        public Guid TopicId { get; set; }


        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<Article> Articles { get; set; } = new List<Article> ();

        public Topic()
        {
           TopicId = Guid.NewGuid();
        }
    }

}