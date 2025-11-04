using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using News_Article_Project.Models;
using News_Article_Project.ViewModels;

namespace News_Article_Project.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult DeleteTopic ()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            DeleteTopicVM d = new DeleteTopicVM();
            d.topics = dbContext.Topics.ToList();
            return View(d);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTopic (Guid? id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            DeleteTopicVM nulled = new DeleteTopicVM();
            if (id == null)
            {
                nulled.topics = dbContext.Topics.ToList();
                return View(nulled);
            }

            
            Topic deleted = dbContext.Topics.FirstOrDefault(x => x.TopicId == id);
            DeleteTopicVM dVM = new DeleteTopicVM();
            if(deleted == null)
            {
                DeleteTopicVM d = new DeleteTopicVM();
                d.topics = dbContext.Topics.ToList();
                d.message = "No Topic Found";
                return View(d);

            }

            for(int i =0; i<deleted.Articles.Count(); i++)
            {
                dbContext.Articles.Remove(deleted.Articles[i]);
            }

            dbContext.Topics.Remove(deleted);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                dVM.message = "An error occured. Try again later";
                return View(dVM);
            }

            return RedirectToAction("Welcome", "Home");
        }

        public ActionResult DeleteSource()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            DeleteSourceVM d = new DeleteSourceVM();
            d.sources = dbContext.Sources.ToList();
            return View(d);
        }
        [Authorize]
        [HttpPost]
        public ActionResult DeleteSource(Guid? id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            DeleteSourceVM nulled = new DeleteSourceVM();
            if (id == null)
            {
                nulled.sources = dbContext.Sources.ToList();
                return View(nulled);
            }
  
            Source deleted = dbContext.Sources.FirstOrDefault(x => x.SourceId == id);
            DeleteSourceVM dVM = new DeleteSourceVM();
            if (deleted == null)
            {
                DeleteSourceVM d = new DeleteSourceVM();
                d.sources = dbContext.Sources.ToList();
                d.message = "No Source Found";
                return View(d);

            }

            for (int i = 0; i < deleted.Articles.Count(); i++)
            {
                dbContext.Articles.Remove(deleted.Articles[i]);
            }

            dbContext.Sources.Remove(deleted);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                dVM.message = "An error occured. Try again later";
                return View(dVM);
            }

            return RedirectToAction("Welcome", "Home");
        }


        [Authorize]
        public ActionResult DeleteArticle ()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();  
            DeleteArticleVM d = new DeleteArticleVM();
            d.articles = dbContext.Articles.ToList();
            return View(d);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteArticle (Guid? id)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            DeleteArticleVM nulled = new DeleteArticleVM();
            if (id == null)
            {
                nulled.articles = dbContext.Articles.ToList();
                return View(nulled);
            }
            DeleteArticleVM d = new DeleteArticleVM();
            Article deleted = dbContext.Articles.FirstOrDefault(x => x.ArticleId == id);
            if (deleted == null)
            {
                
                d.message = "No Article Found";
                d.articles = dbContext.Articles.ToList();
                return View(d);
            }
            dbContext.Articles.Remove(deleted);
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                d.message = "An error occured. Try again later";
                return View(d);
            }

            return RedirectToAction("Welcome", "Home");
        }
        public ActionResult Welcome ()
        {
            return View();
        }
        public PartialViewResult LoginPartial()
        {
            using (var db = new ApplicationDbContext())
            {
                var topics = db.Topics
                               .Select(t => t.Name)
                               .ToList();
                return PartialView("_LoginPartial", topics);
            }
        }
        [Authorize]
        public ActionResult Article()
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            ArticleVM vm = new ArticleVM();
            vm.Topics = dbContext.Topics.ToList();
            vm.Sources = dbContext.Sources.ToList();
            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Article (ArticleVM article)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext();
            if (article.Title ==null)
            {
                article.message = "Article must have a title";
                article.Topics = dbContext.Topics.ToList();
                article.Sources = dbContext.Sources.ToList();
                return View(article);
            }

            if (article.Url == null)
            {
                article.message = "Article must have a URL";
                article.Topics = dbContext.Topics.ToList();
                article.Sources = dbContext.Sources.ToList();
                return View(article);
            }

            if (article.Description == null)
            {
                article.message = "Article must have a description";
                article.Topics = dbContext.Topics.ToList();
                article.Sources = dbContext.Sources.ToList();
                return View(article);

            }

            
            var topic = dbContext.Topics.FirstOrDefault(t => t.Name == article.TopicName);
            var source = dbContext.Sources.FirstOrDefault(s => s.Name == article.SourceName);

            if (topic == null || source == null)
            {
                article.message = "Invalid topic or source selected.";
                article.Topics = dbContext.Topics.ToList();
                article.Sources = dbContext.Sources.ToList();
                return View(article);
            }

            Article newArticle = new Article();
            newArticle.Title = article.Title;
            newArticle.Url = article.Url;
            newArticle.Topic = topic;
            newArticle.Source = source;
            newArticle.Description = article.Description;
            dbContext.Articles.Add(newArticle);

            try
            {
                dbContext.SaveChanges();
                
            }
            catch (Exception ex) {
                article.message = "An error occured. Please try again later";
                return View(article);
            }
            return RedirectToAction("Welcome", "Home");

        }


        [Authorize]
        public ActionResult Source()
        {
            return View(new SourceVM());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Source(SourceVM source)
        {
            if (source.Name == null)
            {
                source.message = "Name cannot be blank";
                return View(source);
            }

            if (source.Bias == null)
            {
                source.message = "Bias cannot be blank";
                return View(source);

            }

            if (source.Website == null)
            {
                source.message = "Web link cannot be blank";
                return View(source);
            }
            ApplicationDbContext dbContext = new ApplicationDbContext();
            Source ValidatedSource = new Source();
            ValidatedSource.Name = source.Name;
            ValidatedSource.Website = source.Website;
            ValidatedSource.Bias = source.Bias;
            dbContext.Sources.Add(ValidatedSource);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                source.message = "An error occured. Please try again later";
                return View(source);
            }

            return Redirect("/Home/Welcome");
        }

        [Authorize]
        public ActionResult Topic()
        {
            return View(new TopicVM ());
        }

        [Authorize]
        [HttpPost]
        public ActionResult Topic(TopicVM topic)
        {
            if(topic.Description == null)
            {
                topic.message = "Topic description cannot be empty";
                return View(topic);
            }

            if(topic.Name == null)
            {
                topic.message = "Topic name cannot be empty";
                return View(topic);
            }

            ApplicationDbContext dbContext = new ApplicationDbContext();
            Topic newTopic = new Topic();
            newTopic.Description = topic.Description;   
            newTopic.Name = topic.Name;
            dbContext.Topics.Add(newTopic);

            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                topic.message = "An error occured. Please try again later";
                return View(topic);
            }

            return Redirect("/Home/Welcome");

        }

        [Authorize]
        public ActionResult DatabaseSummary()
        {
            using (var db = new ApplicationDbContext())
            {
                var vm = new DatabaseSummaryVM
                {
                    Topics = db.Topics.ToList(),
                    Sources = db.Sources.ToList(),
                    Articles = db.Articles
                        .Include("Topic")
                        .Include("Source")
                        .ToList()
                };
                return View(vm);
            }
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}