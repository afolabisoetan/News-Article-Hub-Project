using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Article_Project.Models
{
    public class Topic
    {
        [Key]
        public Guid TopicId { get; set; }


        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public List<Article> Articles { get; set; } = new List<Article> ();

        public Topic()
        {
           TopicId = Guid.NewGuid();
        }
    }

}