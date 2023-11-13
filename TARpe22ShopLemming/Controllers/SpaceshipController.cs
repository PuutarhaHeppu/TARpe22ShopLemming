using Microsoft.AspNetCore.Mvc;
using TARpe22ShopLemming.Core.ServiceInterface;
using TARpe22ShopLemming.Data;
using TARpe22ShopLemming.Models.Spaceship;

namespace TARpe22ShopLemming.Controllers
{
    public class SpaceshipController : Controller
    {
        private readonly TARpe22ShopLemmingContext _context;
        private readonly ISpaceshipsServices _spaceshipsServices;
        private readonly IFilesServices _filesServices;
        public SpaceshipController
            (
                TARpe22ShopLemmingContext context,
                ISpaceshipsServices spaceshipsServices,
                IFilesServices filesServices
            )
        { 
            _context = context; 
            _spaceshipsServices = spaceshipsServices;
            _filesServices = filesServices;
        }
    public IActionResult Index()
        {
            var result = _context.Spaceships
                .OrderByDescending(y => y.CreatedAt)
                .Select(x => new SpaceshipIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    PassengerCount = x.PassengerCount,
                    EnginePower = x.EnginePower
                });
            return View(result);
        }
    }
}
