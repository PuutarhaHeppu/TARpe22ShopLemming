using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;
using TARpe22ShopLemming.ApplicationServices.Services;
using TARpe22ShopLemming.Models.RealEstate;

namespace TARpe22ShopLemming.Controllers
{
    public class RealEstatesController : Controller
    {
        private readonly RealEstatesServices _realEstatesServices;
        private readonly TARpe22ShopLemmingContext _context;
        public RealEstatesController(IRealEstatesServices realEstatesServices)
        {
            _realEstatesServices = realEstatesServices;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.RealEstates
                .OrderByDexcending(y => y.CreatedAt)
                .Select(x => new RealEstatesIndexViewModel
                {
                //{ return (Country + ", " + County ", " + City ", " Address); }
                    Id = x.Id,
                    Location = x.Country + ", " + County ", " + City ", " Address,
                    SquareMeters = x.SqaureMeters,
                    RoomCount = x.RoomCount,
                    Price = x.Price,
                    IsPropertySold = x.IsPropertySold,

                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            RealEstateCreateUpdateViewModel vm = new();
            return View("CreateUpdate", vm)
        }
        [HttpPost]
        public async Task<iActionResult> Create(RealEstateCreateUpdateViewModel vm)
        {
            var dto = new RealEstateDto()
            {
                Id = Guid.NewGuid(),
                Type = vm.Type,
                ListingDescription = vm.ListingDescription,
                Address = vm.Address,
                County = vm.County,
                Country = vm.Country,
                City = vm.City,
                PostalCode = vm.PostalCode,
                ContactPhone = vm.ContactPhone,
                ContactFax = vm.ContactFax,
                SquareMeters = vm.SquareMeters,
                Floor = vm.Floor,
                FloorCount = vm.FloorCount,
                Price = vm.Price,
                RoomCount = vm.RoomCount,
                BedroomCount = vm.BedroomCount,
                BathroomCount = vm.BathroomCount,
                WhenEstateListedAt = vm.WhenEstateListedAt,
                IsPropertySold = vm.IsPropertySold,
                DoesHaveSwimming Pool = vm.DoesHaveSwimming Pool,
                BuiltAt = vm.BuiltAt,
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now,
                Files = vm.Files,
                FilesToApiDtos = vm.FilesToApiViewModels
                .Select(x => new FileToApiDto
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    RealEstateId = x.RealEstateId,
                }).ToArray()
            };
            var result = await _realEstatesServices.Create(dto);
            if (result = null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction("Index", vm);
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var realEstate = await _realEstatesServices.GetAsync(id);
            if (realEstate == null)
            {
                return NotFound();
            }
            var vm = new RealEstateCreateUpdateViewModel();

        }
    }
}
