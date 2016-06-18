using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.Xml;
using dnCustom45;
using IR_BackOffice.Infrastructure;
using IR_BackOffice.Models;
using System.Threading.Tasks;
using IR_BackOffice_Data;
using PagedList;

namespace IR_BackOffice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBackOfficeDataSource _repository = new IR_Database();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult News(int? page)
        {
            int pageNumber = (page ?? 1);
            var newsItems = _repository.NewsItems.Where(u => u.IsLive).OrderByDescending(u => u.DateAdded).ToPagedList(pageNumber, 5);

            return View("News", newsItems);
        }

        public async Task<ActionResult> NewsItem(int id)
        {
            var detailedNewsItem = await Task.FromResult(_repository.NewsItems.Single(u => u.Id == id));
            return View(detailedNewsItem);
        }

        public ActionResult LiveScores()
        {
            return View();
        }

        public ActionResult Tips(int? page)
        {
            int pageNumber = (page ?? 1);
            var tipsItems = _repository.TipsItems.Where(u => u.IsLive).OrderByDescending(u => u.DateAdded).ToPagedList(pageNumber, 12);

            return View("Tips", tipsItems);
        }

        public async Task<ActionResult> TipsItem(int id)
        {
            var detailedTipsItem = await Task.FromResult(_repository.TipsItems.Single(u => u.Id == id));
            return View(detailedTipsItem);
        }

        public ActionResult FreeBets(int? page)
        {
            int pageNumber = (page ?? 1);
            var freeBetItems = _repository.BookmakerItems.Where(u => u.IsLive).OrderByDescending(u => u.DateAdded).ToPagedList(pageNumber, 6);

            return View("FreeBets", freeBetItems);
        }

        public ActionResult TermsAndConditions()
        {
            return View();
        }

        public ActionResult Sitemap()
        {
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(EnquiryModel collection)
        {
            //Add send mail. collection[0]

            if (ModelState.IsValid)
            {
                var body = "Name: " + collection.ContactName + "<br /> Company: " +
                           collection.TelephoneNumber +
                           "<br /> Email: " + collection.EmailAddress + "<br /> Enquiry: <br /><br />" + collection.Enquiry;
                var mail = new IRMail(collection.EmailAddress, true, body, "Web Enquiry");

                mail.AddToo("info@thefootybible.co.uk");

                if (collection.SendToSelf)
                {
                    mail.AddCC(collection.EmailAddress);
                }
                mail.SendMail();

                return RedirectToAction("ThankYou");
            }

            return View(collection);
        }

        public ActionResult ThankYou()
        {
            return View();
        }
    }
}
