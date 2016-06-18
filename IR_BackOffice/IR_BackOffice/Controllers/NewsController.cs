using System;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using IR_BackOffice.Infrastructure;
using IR_BackOffice_Data;
using System.Linq;
using System.Web.Mvc;

namespace IR_BackOffice.Controllers
{
    public class NewsController : AsyncController
    {
        private readonly IBackOfficeDataSource _repository = new IR_Database();

        public async Task<ActionResult> Index()
        {
            var allNewsItems =
                await
                Task.FromResult(_repository.NewsItems.OrderByDescending(u => u.DateAdded));

            return View(allNewsItems);
        }

        public async Task<ActionResult> NewsItem(int id)
        {
            var detailedNewsItem = await Task.FromResult(_repository.NewsItems.Single(u => u.Id == id));
            return View(detailedNewsItem);
        }

        public async Task<FileContentResult> DisplayImageAsync(int id)
        {
            var img = await Task.FromResult(_repository.NewsItems.Single(u => u.Id == id).Image);

            if (img == null)
            {
                byte[] trackingGif = { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61, 0x01, 0x00, 0x01, 0x00, 0x81, 0x00, 0x00, 0xff, 0xff, 0xff, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x21, 0xff, 0x0b, 0x4e, 0x45, 0x54, 0x53, 0x43, 0x41, 0x50, 0x45, 0x32, 0x2e, 0x30, 0x03, 0x01, 0x01, 0x00, 0x00, 0x21, 0xf9, 0x04, 0x01, 0x00, 0x00, 0x00, 0x00, 0x2c, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x00, 0x08, 0x04, 0x00, 0x01, 0x04, 0x04, 0x00, 0x3b };
                img = trackingGif;
            }

            return File(img, "image/jpeg");
        }
    }
}
