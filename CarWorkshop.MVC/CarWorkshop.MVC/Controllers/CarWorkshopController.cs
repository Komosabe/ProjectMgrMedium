using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWorkshopService _carWorkshopService;

        public CarWorkshopController(ICarWorkshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var workshops = await _carWorkshopService.GetAll();
            return View(workshops);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CarWorkshopDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _carWorkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Create));
        }
    }
}
