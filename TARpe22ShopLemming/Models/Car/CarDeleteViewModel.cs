namespace TARpe22ShopLemming.Models.Car
{
    public class CarDeleteViewModel
    {
        public Guid Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public string Name { get; set; }
        public List<CarImageViewModel> CarImageViewModels { get; set; } = new List<CarImageViewModel>();

        // db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}