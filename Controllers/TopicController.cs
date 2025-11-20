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
        public ActionResult Index()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                // Load Topics and their related Articles + Sources
                var topics = dbContext.Topics
                    .Include(t => t.Articles.Select(a => a.Source))
                    .ToList();

                // Create dictionary: TopicName -> List of ArticleBiasVMs
                var topicArticles = topics.ToDictionary(
                    t => t.Name,
                    t => t.Articles
                            .Select(a => new ArticleBiasVM
                            {
                                ArticleId = a.ArticleId,
                                Title = a.Title,
                                BiasValue = a.BiasValue,
                                SourceName = a.Source != null ? a.Source.Name : "Unknown"
                            })
                            .ToList()
                );

                var vm = new TopicArticleVM
                {
                    TopicArticles = topicArticles
                };

                return View(vm);
            }
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