using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopLemming.Core.Dto;
using TARpe22ShopLemming.Core.ServiceInterface;
using TARpe22ShopLemming.Data;
using TARpe22ShopLemming.Models.Car;
using TARpe22ShopLemming.Models.Spaceship;

namespace TARpe22ShopLemming.Controllers
{
    public class CarsController : Controller
    {
        private readonly TARpe22ShopLemmingContext _context;
        private readonly ICarsServices _carsServices;
        private readonly IFilesServices _filesServices;
        public CarsController
            (
                TARpe22ShopLemmingContext context,
                ICarsServices carsServices,
                IFilesServices filesServices
            )
        {
            _context = context;
            _carsServices = carsServices;
            _filesServices = filesServices;
        }
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Mark = x.Mark,
                    Model = x.Model,
                    Year = x.Year,
                    HorsePower = x.HorsePower,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();
            return View("CreateUpdate", car);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                HorsePower = vm.HorsePower,
                Year = vm.Year,
                Model = vm.Model,
                Mark = vm.Mark,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image.gif;base64,{0}", Convert.ToBase64String(y.ImageData))

                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.HorsePower = car.HorsePower;
            vm.Year = car.Year;
            vm.Model = car.Model;
            vm.Mark = car.Mark;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                Image = vm.Image.Select(x => new FileToDatabaseDto
                {
                    Id = x.ImageId,
                    ImageData = x.ImageData,
                    ImageTitle = x.ImageTitle,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Update(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {

            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData))
                }).ToArrayAsync();
            var vm = new CarDetailsViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.HorsePower = car.HorsePower;
            vm.Year = car.Year;
            vm.Mark = car.Mark;
            vm.Model = car.Model;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {

            var car = await _carsServices.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            var photos = await _context.FilesToDatabase
                .Where(x => x.CarId == id)
                .Select(y => new CarImageViewModel
                {
                    CarId = y.Id,
                    ImageId = y.Id,
                    ImageData = y.ImageData,
                    ImageTitle = y.ImageTitle,
                    Image = string.Format("data:image/gif;base64,{0}", Convert.ToBase64String(y.ImageData)),
                }).ToArrayAsync();

            var vm = new CarDeleteViewModel();

            vm.Id = car.Id;
            vm.Name = car.Name;
            vm.HorsePower = car.HorsePower;
            vm.Year = car.Year;
            vm.Mark = car.Mark;
            vm.Model = car.Model;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carsServices.Delete(id);
            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage(Models.Car.CarImageViewModel file)
        {
            var dto = new FileToDatabaseDto()
            {
                Id = file.ImageId
            };
            var image = await _filesServices.RemoveImage(dto);
            if (image == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}