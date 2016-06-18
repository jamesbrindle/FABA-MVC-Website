using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IR_BackOffice.Infrastructure;
using IR_BackOffice.Models;
using IR_BackOffice_Data;
using TipsItem = IR_BackOffice_Data.TipsItem;


namespace IR_BackOffice.Controllers
{
    public class ManageTipsController : Controller
    {
        //
        // GET: /ManageFreeBets/

        private readonly IBackOfficeDataSource _repsoitory = new IR_Database();
        [Authorize]
        public ActionResult Index()
        {
            var tipsItem = _repsoitory.TipsItems;
            return View(tipsItem);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateTipsViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateTipsViewModel input)
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

                var tips = new TipsItem();

                if (image != null)
                {
                    byte[] toPutInDb = image.GetBytes();
                    tips.Image = toPutInDb;
                }

                tips.Title = input.Title;
                tips.Text = input.Text;
                tips.DateAdded = input.DateAdded;
                tips.IsLive = input.IsLive;

                var data = new IR_Database();
                data.TipsItems.Add(tips);
                data.SaveChanges();

                return View("Index", data.TipsItems);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            TipsItem n = _repsoitory.TipsItems.Single(u => u.Id == id);

            var model = new EditTipsViewModel
            {
                Id = n.Id,
                Title = n.Title,
                Text = n.Text,
                DateAdded = n.DateAdded,
                IsLive = n.IsLive
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditTipsViewModel input)
        {
            if (ModelState.IsValid)
            {
                var data = new IR_Database();
                TipsItem n = data.TipsItems.Single(u => u.Id == input.Id);

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
                n.DateAdded = input.DateAdded;
                n.IsLive = n.IsLive;
                data.SaveChanges();

                return View("Index", data.TipsItems);
            }
            return View(input);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var data = new IR_Database();
            TipsItem n = data.TipsItems.Single(u => u.Id == id);
            return View(n);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var data = new IR_Database();
            TipsItem n = data.TipsItems.Single(u => u.Id == id);
            data.TipsItems.Remove(n);
            data.SaveChanges();
            return View("Index", data.TipsItems);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var data = new IR_Database();
            TipsItem n = data.TipsItems.Single(u => u.Id == id);
            return View(n);
        }
    }
}
