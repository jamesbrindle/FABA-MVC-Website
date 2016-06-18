using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using IR_BackOffice.Infrastructure;
using IR_BackOffice_Data;

namespace IR_BackOffice.Controllers
{
    public class LeagueCodesController : Controller
    {
        private readonly IBackOfficeDataSource _repository = new IR_Database();

        public async Task<ActionResult> Index()
        {
            var allNewsItems =
                await
                    Task.FromResult(_repository.LeagueCodes.OrderBy(u => u.LeagueCode));

            return View(allNewsItems);
        }

        public async Task<ActionResult> LeagueCodes(int id)
        {
            var detailedLeagueCodes = await Task.FromResult(_repository.LeagueCodes.Single(u => u.Id == id));
            return View(detailedLeagueCodes);
        }
    }
}
