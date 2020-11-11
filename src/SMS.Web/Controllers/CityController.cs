using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

        //GET : City
        public ActionResult Load()
        {
            var cities = _cityServices.GetCities();
            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var jsonData = JsonConvert.SerializeObject(cities, jsonSerializerSettings);
            return Content(jsonData, "application/json");
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
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _cityServices.Create(cityViewModel, userId);

                return RedirectToAction("Index");
            }

            return View("CityForm", cityViewModel);
        }

        // GET : City/Edit/{id}
        public ActionResult Edit(int id)
        {
            var city = _cityServices.GetCityById(id);
            if (city != null)
            {
                var viewModel = new CityViewModel
                {
                    Id = city.Id,
                    Name = city.Name
                };
                ViewBag.Title = _cityServices.CheckIsExistingCity(id);

                return View("CityForm", viewModel);
            }

            return HttpNotFound("Sorry, looks like invalid city id");
        }

        // POST : City/Edit
        [HttpPost]
        public ActionResult Edit(CityViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                _cityServices.Update(viewModel, userId);

                return RedirectToAction("Index");
            }

            return View("CityForm", viewModel);
        }

        // DELETE : City/Delete/{id}
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _cityServices.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}