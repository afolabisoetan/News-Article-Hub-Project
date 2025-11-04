using System.Collections.Generic;
using News_Article_Project.Models;

namespace News_Article_Project.ViewModels
{
    public class DatabaseSummaryVM
    {
        public List<Topic> Topics { get; set; }
        public List<Source> Sources { get; set; }
        public List<Article> Articles { get; set; }
    }
}
