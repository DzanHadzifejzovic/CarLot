using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using MVCAssign1.Models;
using MVCAssign1.Repository;
using System;

namespace MVCAssign1.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;


        public CarController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<IActionResult> Index()
        {
 
            var list = await _carRepository.GetAll();
            return View(list);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var car = await _carRepository.GetCarById(id);
            return View(car);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Car car)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Nije dobar unos");
                return View("Add",car);

            }

            _carRepository.Add(car);
            return RedirectToAction("Index");
            
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var car = await _carRepository.GetCarById(id);
            if (car != null)
            {
                _carRepository.Delete(car);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult SetCulture(string culture,string sourceUrl)
        {
            Response.Cookies.Append
                (
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires=DateTimeOffset.UtcNow.AddYears(1)}
                );

            return Redirect(sourceUrl); 

        }
    }
}
