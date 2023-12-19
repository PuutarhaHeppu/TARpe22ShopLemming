using TARpe22ShopLemming.Core.Dto;
using TARpe22ShopLemming.Models.RealEstate;

namespace TARpe22ShopLemming.Models.Car
{
    public class CarCreateUpdateViewModel
    {
        public Guid Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public string Name { get; set; }
        public List<CarImageViewModel> CarImageViewModels { get; set; } = new List<CarImageViewModel>();
        public List<IFormFile> Files { get; set; } //List of files to be added
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        // db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}