using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopLemming.Core.Dto;
using TARpe22ShopLemming.Core.ServiceInterface;
using TARpe22ShopLemming.Data;
using TARpe22ShopLemming.Models.Car;

namespace TARpe22ShopLemming.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarsServices _carsServices;
        private readonly TARpe22ShopLemmingContext _context;
        private readonly IFilesServices _filesServices;
        public CarsController(ICarsServices carsServices, TARpe22ShopLemmingContext context, IFilesServices filesServices)
        {
            _carsServices = carsServices;
            _context = context;
            _filesServices = filesServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var result = _context.Cars
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Mark = x.Mark,
                    Model = x.Model,
                    Year = x.Year,
                    HorsePower = x.HorsePower,
                    Name = x.Name,
                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = Guid.NewGuid(),
                Mark = vm.Mark,
                Model = vm.Model,
                Year = vm.Year,
                HorsePower = vm.HorsePower,
                Name = vm.Name,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                CarFileToApiDtos = vm.CarFileToApiViewModels
                .Select(x => new CarFileToApiDto
                {
                    Id = x.CarImageId,
                    CarExistingFilePath = x.CarFilePath,
                    CarId = x.CarId,
                }).ToArray()
            };
            var result = await _carsServices.Create(dto);
            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var Car = await _carsServices.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }
            var images = await _context.CarFileToApis
                .Where(x => x.CarId == id)
                .Select(y => new CarFileToApiViewModel
                {
                    CarFilePath = y.CarExistingFilePath,
                    CarImageId = y.Id
                }).ToArrayAsync();
            var vm = new CarCreateUpdateViewModel();
            vm.Id = Car.Id;
            vm.Mark = vm.Mark;
            vm.Model = vm.Model;
            vm.Year = vm.Year;
            vm.HorsePower = vm.HorsePower;
            vm.Name = vm.Name;
            vm.CreatedAt = Car.CreatedAt;
            vm.ModifiedAt = DateTime.Now;
            vm.CarFileToApiViewModels.AddRange(images);

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = (Guid)vm.Id,
                Mark = vm.Mark,
                Model = vm.Model,
                Year = vm.Year,
                HorsePower = vm.HorsePower,
                Name = vm.Name,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                CarFileToApiDtos = vm.CarFileToApiViewModels
                .Select(x => new CarFileToApiDto
                {
                    Id = x.CarImageId,
                    CarExistingFilePath = x.CarFilePath,
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
            var Car = await _carsServices.GetAsync(id);
            if (Car == null)
            {
                return NotFound();
            }
            var images = await _context.CarFileToApis
            .Where(x => x.CarId == id)
            .Select(y => new CarFileToApiViewModel
            {
                CarFilePath = y.CarExistingFilePath,
                CarImageId = y.Id
            }).ToArrayAsync();
            var vm = new CarDetailsViewModel(); //todo: details viewmodel
            vm.Id = Car.Id;
            vm.Mark = Car.Mark;
            vm.Model = Car.Model;
            vm.Year = Car.Year;
            vm.HorsePower = Car.HorsePower;
            vm.Name = Car.Name;
            vm.CreatedAt = Car.CreatedAt;
            vm.ModifiedAt = Car.ModifiedAt;
            vm.CarFileToApiViewModels.AddRange(images);

            return View(vm);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var Car = await _carsServices.GetAsync(id);

            if (Car == null)
            {
                return NotFound();
            }
            var images = await _context.CarFileToApis
            .Where(x => x.CarId == id)
            .Select(y => new CarFileToApiViewModel
            {
                CarFilePath = y.CarExistingFilePath,
                CarImageId = y.Id
            }).ToArrayAsync();
            var vm = new CarDeleteViewModel();
            vm.Id = Car.Id;
            vm.Mark = Car.Mark;
            vm.Model = Car.Model;
            vm.Year = Car.Year;
            vm.HorsePower = Car.HorsePower;
            vm.Name = Car.Name;
            vm.CreatedAt = Car.CreatedAt;
            vm.ModifiedAt = Car.ModifiedAt;
            vm.CarFileToApiViewModels.AddRange(images);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var Car = await _carsServices.Delete(id);
            if (Car != null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        //[HttpPost]
        //public async Task<IActionResult> RemoveImage(CarFileToApiViewModel vm)
        //{
        //    var dto = new CarFileToApiDto()
        //    {
        //        Id = vm.CarImageId
        //    };
        //    var image = await _filesServices.CarRemoveImageFromApi(dto);
        //    if (image == null)
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return RedirectToAction(nameof(Index));
        //}
    }
}