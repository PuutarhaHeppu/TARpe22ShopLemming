using TARpe22ShopLemming.Core.Dto;

namespace TARpe22ShopLemming.Models.Car
{
    public class CarImageViewModel
    {
        public Guid CarImageId { get; set; }
        public string CarFilePath { get; set; }
        public Guid CarId { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid ImageId { get; set; }
        public string Image { get; set; }
    }
}