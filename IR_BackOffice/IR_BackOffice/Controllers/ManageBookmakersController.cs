using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IR_BackOffice.Infrastructure;
using IR_BackOffice.Models;
using IR_BackOffice_Data;
using BookmakerItem = IR_BackOffice_Data.BookmakerItem;

namespace IR_BackOffice.Controllers
{
    public class ManageBookmakersController : Controller
    {
        private readonly IBackOfficeDataSource _repository = new IR_Database();
        [Authorize]

        public ActionResult Index()
        {
            var bookmakerItems = _repository.BookmakerItems;
            return View(bookmakerItems);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateBookmakerViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateBookmakerViewModel input)
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

                var bookmaker = new BookmakerItem();

                if (image != null)
                {
                    byte[] toPutInDb = image.GetBytes();
                    bookmaker.Image = toPutInDb;
                }

                bookmaker.Title = input.Title;
                bookmaker.Url = input.Url;
                bookmaker.Text = input.Text;
                bookmaker.DateAdded = input.DateAdded;
                bookmaker.IsLive = input.IsLive;

                var data = new IR_Database();
                data.BookmakerItems.Add(bookmaker);
                data.SaveChanges();

                return View("Index", data.BookmakerItems);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            BookmakerItem n = _repository.BookmakerItems.Single(u => u.Id == id);
            var model = new EditBookmakerViewModel
            {
                Title = n.Title,
                Url = n.Url,
                Text = n.Text,
                DateAdded = n.DateAdded,
                IsLive = n.IsLive,
                Id = n.Id
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditBookmakerViewModel input)
        {
            if (ModelState.IsValid)
            {
                var data = new IR_Database();
                BookmakerItem n = data.BookmakerItems.Single(u => u.Id == input.Id);

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
                n.Url = input.Url;
                n.Text = input.Text;
                n.DateAdded = input.DateAdded;
                n.IsLive = input.IsLive;

                data.SaveChanges();

                return View("Index", data.BookmakerItems);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var data = new IR_Database();
            BookmakerItem n = data.BookmakerItems.Single(u => u.Id == id);

            return View(n);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var data = new IR_Database();
            BookmakerItem n = data.BookmakerItems.Single(u => u.Id == id);

            data.BookmakerItems.Remove(n);
            data.SaveChanges();

            return View("Index", data.BookmakerItems);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var data = new IR_Database();
            BookmakerItem n = data.BookmakerItems.Single(u => u.Id == id);

            return View(n);
        }
    }
}
