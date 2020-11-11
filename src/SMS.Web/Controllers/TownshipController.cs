using Microsoft.AspNet.Identity;
using SMS.Services;
using SMS.ViewModels;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class TownshipController : Controller
    {
        private readonly CityServices _cityServcies = new CityServices();
        private readonly TownshipServices _townshipServices = new TownshipServices();

        // GET: Township
        public ActionResult Index()
        {
            var townships = _townshipServices.GetAll();
            return View("List", townships);
        }

        // GET : Township/New
        public ActionResult New()
        {
            var viewModel = new TownshipViewModel
            {
                Cities = _cityServcies.GetAll()
            };

            return View("TownshipForm", viewModel);
        }

        // POST : Township/Create
        [HttpPost]
        public ActionResult Create(TownshipViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _townshipServices.Create(viewModel, userId);

                return RedirectToAction(nameof(Index));
            }
            ViewBag.Title = _townshipServices.GenerateViewBagTitle(viewModel.Id);

            return View("TownshipForm", viewModel);
        }

        // GET : Township/Edit/{id}
        public ActionResult Edit(int id)
        {
            var township = _townshipServices.GetById(id);
            if (township != null)
            {
                var viewModel = new TownshipViewModel
                {
                    Id = township.Id,
                    Name = township.Name,
                    CityId = township.CityId,
                    CityName = township.CityName,
                    Cities = _cityServcies.GetAll()
                };
                ViewBag.Title = _townshipServices.GenerateViewBagTitle(id);

                return View("TownshipForm", viewModel);
            }

            return HttpNotFound("Sorry, looks like invalid township Id.");
        }

        // POST : Township/Edit
        [HttpPost]
        public ActionResult Update(TownshipViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _townshipServices.Update(viewModel, userId);
            }

            return View("TownshipForm", viewModel);
        }

        // DELETE : Township/Delete/{id}
        public ActionResult Delete(int id)
        {
            var township = _townshipServices.GetById(id);
            if (township != null)
            {
                _townshipServices.Delete(id);
                return RedirectToAction(nameof(Index));
            }

            return HttpNotFound("Sorry, no township exists with this Id.");
        }
    }
}