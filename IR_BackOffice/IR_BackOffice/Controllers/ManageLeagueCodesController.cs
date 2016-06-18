using System;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using IR_BackOffice.Infrastructure;
using IR_BackOffice.Models;
using IR_BackOffice.Objects;
using IR_BackOffice_Data;
using LeagueCodes = IR_BackOffice_Data.LeagueCodes;

namespace IR_BackOffice.Controllers
{
    public class ManageLeagueCodesController : Controller
    {
        private readonly IBackOfficeDataSource _repository = new IR_Database();
        [Authorize]

        public ActionResult Index()
        {
            var leagueCodeItems = _repository.LeagueCodes;
            return View(leagueCodeItems);
        }

        [Authorize]
        public ActionResult Create()
        {
            var model = new CreateLeagueCodeViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(CreateLeagueCodeViewModel input)
        {
            if (ModelState.IsValid)
            {
                var leagueCode = new LeagueCodes
                                 {

                                     LeagueCode = input.LeagueCode,
                                     Name = input.Name,
                                 };

                var data = new IR_Database();

                data.LeagueCodes.Add(leagueCode);

                data.SaveChanges();

                return View("Index", data.LeagueCodes);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var n = _repository.LeagueCodes.Single(u => u.Id == id);

            var model = new EditLeagueCodeModel
            {
                Name = n.Name,
                LeagueCode = n.LeagueCode,
            };

            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(EditLeagueCodeModel input)
        {
            if (ModelState.IsValid)
            {
                var data = new IR_Database();
                var n = data.LeagueCodes.Single(u => u.Id == input.Id);

                n.Name = input.Name;
                n.LeagueCode = input.LeagueCode;

                data.SaveChanges();

                return View("Index", data.LeagueCodes);
            }

            return View(input);
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var data = new IR_Database();
            var n = data.LeagueCodes.Single(u => u.Id == id);

            return View(n);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var data = new IR_Database();
            var n = data.LeagueCodes.Single(u => u.Id == id);

            data.LeagueCodes.Remove(n);
            data.SaveChanges();

            return View("Index", data.LeagueCodes);
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            var data = new IR_Database();
            IR_BackOffice_Data.LeagueCodes n = data.LeagueCodes.Single(u => u.Id == id);

            return View(n);
        }
    }
}
