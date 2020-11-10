using Microsoft.AspNet.Identity;
using SMS.Services;
using SMS.ViewModels;
using System.Web.Mvc;

namespace SMS.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly CityServices _cityServices = new CityServices();

        // GET: City
        public ActionResult Index()
        {
            var cities = _cityServices.GetCities();
            return View("List", cities);
        }

        // GET : City/New
        public ActionResult New()
        {
            var cityViewModel = new CityViewModel();
            ViewBag.Title = _cityServices.CheckIsExistingCity(cityViewModel.Id);
            return View("CityForm", cityViewModel);
        }

        // POST : City/New
        [HttpPost]
        public ActionResult Create(CityViewModel cityViewModel)
        {
            var userId = User.Identity.GetUserId();
            _cityServices.Create(cityViewModel, userId);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}