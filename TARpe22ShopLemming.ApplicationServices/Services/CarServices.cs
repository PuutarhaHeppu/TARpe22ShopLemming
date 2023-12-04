using Microsoft.EntityFrameworkCore;
using TARpe22ShopLemming.Core.Domain.CarDomain;
using TARpe22ShopLemming.Core.Dto.CarDtos;
using TARpe22ShopLemming.Core.ServiceInterface;
using TARpe22ShopLemming.Data;

namespace TARpe22ShopLemming.ApplicationServices.Services
{
    public class CarsServices : ICarsServices
    {
        private readonly TARpe22ShopLemmingContext _context;
        private readonly IFilesServices _filesServices;
        public CarsServices
            (
            TARpe22ShopLemmingContext context,
            IFilesServices filesServices
            )
        {
            _context = context;
            _filesServices = filesServices;
        }
        public async Task<Car> GetAsync(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }
        public async Task<Car> Create(CarDto dto)
        {
            Car car = new();

            var CarProps = typeof(Car).GetProperties();
            var CarDtoProps = typeof(CarDto).GetProperties();
            for (int i = 0; i < CarProps.Length; i++)
            {
                var CarProp = CarProps[i];
                for (int j = 0; j < CarDtoProps.Length; j++)
                {
                    var CarDtoProp = CarDtoProps[j];
                    if (CarProp.Name == CarDtoProp.Name)
                    {
                        CarProp.SetValue(car, CarDtoProp.GetValue(dto));
                    }
                }
            }
            car.CreatedAt = DateTime.Now;
            car.ModifiedAt = DateTime.Now;
            _filesServices.CarFilesToApi(dto, car);

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Car> Delete(Guid id)
        {
            var CarId = await _context.Cars
                .Include(x => x.CarFilesToApi)
                .FirstOrDefaultAsync(x => x.Id == id);
            var images = await _context.FileToApis
                .Where(x => x.CarId == id)
                .Select(y => new CarFileToApiDto
                {
                    Id = y.Id,
                    CarId = y.CarId,
                    CarExistingFilePath = y.CarExistingFilePath
                }).ToArrayAsync();
            await _filesServices.RemoveImagesFromApi(images);
            _context.Cars.Remove(CarId);
            await _context.SaveChangesAsync();
            return CarId;
        }

        public async Task<Car> Update(CarDto dto)
        {
            Car Car = new Car();

            Car.Id = dto.Id;
            Car.Year = dto.Year;
            Car.ModifiedAt = dto.ModifiedAt;
            Car.CreatedAt = dto.CreatedAt;
            Car.Mark = dto.Mark;
            Car.Model = dto.Model;
            Car.Name = dto.Name;
            Car.HorsePower = dto.HorsePower;
            _context.Cars.Update(Car);
            await _context.SaveChangesAsync();
            return Car;
        }
    }
}