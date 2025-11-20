using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Article_Project.ViewModels
{
    public class TopicArticleVM
    {
        public Dictionary<string, List<ArticleBiasVM>> TopicArticles { get; set; }


        public TopicArticleVM()
        {
            TopicArticles = new Dictionary<string, List<ArticleBiasVM>>();
        }
    }
}