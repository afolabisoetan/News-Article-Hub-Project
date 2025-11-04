using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Article_Project.ViewModels
{
    public class TopicDetailsViewModel
    {
        public string TopicName { get; set; }
        public Dictionary<string, int> BiasCounts { get; set; } = new Dictionary<string, int>();
        // e.g. { "Left": 6, "Center": 4, "Right": 3 }
    }

}