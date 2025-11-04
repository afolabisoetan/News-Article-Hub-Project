using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Article_Project.ViewModels
{
    public class SourceVM
    {
        public string Name { get; set; } = string.Empty;
        public string Bias { get; set; } = "Center"; // Left, Right, Center, etc.
        public string Website { get; set; } = string.Empty;

        public string message { get; set; } 
    }
}