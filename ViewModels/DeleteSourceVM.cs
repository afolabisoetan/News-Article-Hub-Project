using News_Article_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Article_Project.ViewModels
{
    public class DeleteSourceVM
    {
        public Guid id;

        public string message {  get; set; } = string.Empty;

        public List<Source> sources { get; set;} = new List<Source>();
    }
}