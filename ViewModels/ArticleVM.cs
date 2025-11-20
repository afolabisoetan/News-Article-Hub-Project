using News_Article_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Article_Project.ViewModels
{
    public class ArticleVM
    {
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public string TopicName { get; set; } = string.Empty;

        public string SourceName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int BiasValue { get; set; } // 1 = Left, 3 = Center, 5 = Right

        public List<Topic> Topics { get; set; }
        public List<Source> Sources { get; set; }

        public string message {  get; set; } = string.Empty;
    }
}