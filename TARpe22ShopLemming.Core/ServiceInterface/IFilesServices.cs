using TARpe22ShopLemming.Core.Domain;
using TARpe22ShopLemming.Core.Dto;

namespace TARpe22ShopLemming.Core.ServiceInterface
{
    public interface IFilesServices
    {
        void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
        Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos);
        void FilesToApi(RealEstateDto dto, RealEstate realEstate);
        void CarFilesToApi(CarDto dto, Car car);
        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos);
        Task<FileToApi> RemoveImageFromApi(FileToApiDto dto);
        Task CarRemoveImagesFromApi(CarFileToApiDto[] images);
        Task CarRemoveImageFromApi(CarFileToApiDto dto);
    }
}
