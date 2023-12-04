using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopLemming.Core.Domain;
using TARpe22ShopLemming.Core.Domain.CarDomain;
using TARpe22ShopLemming.Core.Dto;
using TARpe22ShopLemming.Core.Dto.CarDtos;

namespace TARpe22ShopLemming.Core.ServiceInterface
{
    public interface ISpaceshipServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
<<<<<<< Updated upstream:TARpe22ShopLemming.Core/ServiceInterface/ISpaceshipServices.cs
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto dtos);

=======
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
        void CarFilesToApi(CarDto dto, Car car);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task<List<CarFileToApi>> RemoveImagesFromApi(CarFileToApiDto[] dtos);
        Task<CarFileToApi> RemoveImageFromApi(CarFileToApiDto dto);
>>>>>>> Stashed changes:TARpe22ShopLemming.Core/ServiceInterface/IFilesServices.cs
    }
}
