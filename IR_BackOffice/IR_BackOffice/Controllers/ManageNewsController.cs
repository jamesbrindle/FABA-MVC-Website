using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IR_BackOffice.Infrastructure;
using IR_BackOffice.Models;
using IR_BackOffice_Data;
using NewsItem = IR_BackOffice_Data.NewsItem;

namespace IR_BackOffice.Controllers
{
    public class ManageNewsController : Controller
    {
        private readonly IBackOfficeDataSource _repository = new IR_Database();

        [Authorize]
        public ActionResult Index()
        {
            var newsItems = _repository.NewsItems;
            return View(newsItems);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateNewsViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateNewsViewModel input)
        {
            if (ModelState.IsValid)
            {
                WebImage image = null;

                try
                {
                    image = WebImage.GetImageFromRequest();
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Error uploading image: " + e.Message);
                }

                var news = new NewsItem();

                if (image != null)
                {
                    byte[] toPutInDb = image.GetBytes();
                    news.Image = toPutInDb;
                }

                news.Title = input.Title;
                news.ShortText = input.ShortText;
                news.Text = input.Text;
                news.IsLive = input.IsLive;
                news.DateAdded = input.DateAdded;

                var data = new IR_Database();

                data.NewsItems.Add(news);
                data.SaveChanges();

                return View("Index", data.NewsItems);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            NewsItem n = _repository.NewsItems.Single(u => u.Id == id);
            var model = new EditNewsViewModel
            {

                Title = n.Title,
                ShortText = n.ShortText,
                Text = n.Text,
                DateAdded = n.DateAdded,
                IsLive = n.IsLive,
                Id = n.Id
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditNewsViewModel input)
        {
            if (ModelState.IsValid)
            {
                var data = new IR_Database();
                NewsItem n = data.NewsItems.Single(u => u.Id == input.Id);

                WebImage image = null;

                try
                {
                    image = WebImage.GetImageFromRequest();
                }
                catch (Exception e)
                {
                    Console.Out.WriteLine("Error uploading image: " + e.Message);
                }

                if (image != null)
                {
                    byte[] toPutInDb = image.GetBytes();
                    n.Image = toPutInDb;
                }

                n.Title = input.Title;
                n.Text = input.Text;
                n.ShortText = input.ShortText;
                n.DateAdded = input.DateAdded;
                n.IsLive = input.IsLive;

                data.SaveChanges();

                return View("Index", data.NewsItems);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var data = new IR_Database();
            NewsItem n = data.NewsItems.Single(u => u.Id == id);

            return View(n);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var data = new IR_Database();
            NewsItem n = data.NewsItems.Single(u => u.Id == id);

            data.NewsItems.Remove(n);
            data.SaveChanges();

            return View("Index", data.NewsItems);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var data = new IR_Database();
            NewsItem n = data.NewsItems.Single(u => u.Id == id);

            return View(n);
        }
    }
}
