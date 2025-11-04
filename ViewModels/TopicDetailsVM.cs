using System.Collections.Generic;
using News_Article_Project.Models;

namespace News_Article_Project.ViewModels
{
    public class TopicDetailsVM
    {
        public string TopicName { get; set; }
        public string TopicDescription { get; set; }
        public List<Article> Articles { get; set; }
    }
}
