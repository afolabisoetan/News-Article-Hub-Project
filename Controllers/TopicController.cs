using News_Article_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News_Article_Project.ViewModels;
namespace News_Article_Project.Controllers
{
    public class TopicController : Controller
    {
        // GET: Topic
        public ActionResult Index ()
        {
            /** ApplicationDbContext dbContext = new ApplicationDbContext();
             // 1️⃣ Find the topic by ID
             var topic = dbContext.Topics.FirstOrDefault(t => t.TopicId == id);
             if (topic == null)
             {
                // return NotFound();
             }

             // 2️⃣ Count how many articles fall under each bias category for that topic
             var biasCounts = dbContext.Articles
                 .Where(a => a.TopicId == id)
                 .GroupBy(a => a.Source.Bias)
                 .ToDictionary(g => g.Key, g => g.Count());

             // 3️⃣ Package it into a ViewModel
             var vm = new TopicDetailsViewModel
             {
                 TopicName = topic.Name,
                 BiasCounts = biasCounts
             };
            **/
            var vm1 = new TopicDetailsViewModel
            {
                TopicName = "Seria",
                BiasCounts = new Dictionary<string, int> { { "Left: ", 7 }, { "Right: ", 8 } }
            };
            // 4️⃣ Send data to the Razor view
            return View(vm1);
        }

        public ActionResult Details(string topicName)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            if (string.IsNullOrEmpty(topicName))
                return RedirectToAction("DatabaseSummary", "Home");

            var topic = dbContext.Topics.FirstOrDefault(t => t.Name == topicName);
            if (topic == null)
                return HttpNotFound();

            var articles = dbContext.Articles
                .Include(a => a.Source)
                .Where(a => a.Topic.Name == topicName)
                .ToList();

            var vm = new TopicDetailsVM
            {
                TopicName = topic.Name,
                TopicDescription = topic.Description,
                Articles = articles
            };

            return View(vm);
        }
    

        public ActionResult Ukraine ()
        {
            return View();
        }

        public ActionResult Israel()
        {
            return View();
        }

        public ActionResult China()
        {
            return View();
        }
    }
}