using TARpe22ShopLemming.Core.Dto;

namespace TARpe22ShopLemming.Models.Car
{
    public class CarDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public string Name { get; set; }
        public List<CarImageViewModel> CarImageViewModels { get; set; } = new List<CarImageViewModel>();
        public IEnumerable<FileToDatabaseDto> Image { get; set; } = new List<FileToDatabaseDto>();

        // db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}