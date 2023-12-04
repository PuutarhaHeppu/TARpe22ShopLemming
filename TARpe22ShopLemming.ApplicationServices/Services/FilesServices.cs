using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TARpe22ShopLemming.Core.Domain;
<<<<<<< Updated upstream
=======
using TARpe22ShopLemming.Core.Domain.CarDomain;
using TARpe22ShopLemming.Core.Dto;
using TARpe22ShopLemming.Core.Dto.CarDtos;
using TARpe22ShopLemming.Core.ServiceInterface;
>>>>>>> Stashed changes
using TARpe22ShopLemming.Data;

namespace TARpe22ShopLemming.ApplicationServices.Services
{
    public class FilesServices : IFilesServices
    {
        private readonly TARpe22ShopLemmingContext _context;
        private readonly IHostingEnvironment _webHost;
        public FilesServices
            (
                TARpe22ShopLemmingContext context,
                IHostingEnvironment webHost
            )
        {
            _context = context;
            _webHost = webHost;
        }
        public void UploadFilesToDatabase(SpaceshipDto dto, Spaceship domain)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    using (var target = new MemoryStream())
                    {
                        FileToDatabase files = new FileToDatabase()
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
                            SpaceshipId = domain.Id,
                        };

                        photo.CopyTo(target);
                        files.ImageData = target.ToArray();

                        _context.FilesToDatabase.Add(files);
                    }
                }
            }
        }
        public async Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto)
        {
            var image = await _context.FilesToDatabase
                .Where(x => x.Id == dto.Id)
                .FirstOrDefaultAsync();
            _context.FilesToDatabase.Remove(image);
            await _context.SaveChangesAsync();
            return image;
        }
        public async Task<List<FileToDatabase>> RemoveImagesFromDatabase(FileToDatabaseDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var image = await _context.FilesToDatabase
                    .Where(x => x.Id == dto.Id)
                    .FirstOrDefaultAsync();
                _context.FilesToDatabase.Remove(image);
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public void FilesToApi(RealEstateDto dto, RealEstate realEstate)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.WebRootPath + "\\multipleFileUpload\\");
                }
                foreach (var image in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.WebRootPath, "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = filePath,
                            RealEstateId = realEstate.Id,
                        };
                        _context.FilesToApi.AddAsync(path);
                    }
                }
            }
        }
<<<<<<< Updated upstream
=======
        public async Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDto[] dtos)
        {
            foreach (var dto in dtos)
            {
                var imageId = await _context.FileToApis
                    .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
                var filePath = _webHost.WebRootPath + "\\multipleFileUpload\\" + imageId.ExistingFilePath;
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                _context.FileToApis.Remove(imageId);
                await _context.SaveChangesAsync();
            }
            return null;
        }
        public async Task<FileToApi> RemoveImageFromApi(FileToApiDto dto)
        {
            var imageId = await _context.FileToApis
                .FirstOrDefaultAsync(x => x.ExistingFilePath == dto.ExistingFilePath);
            var filePath = _webHost.WebRootPath + "\\multipleFileUpload\\" + imageId.ExistingFilePath;
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            _context.FileToApis.Remove(imageId);
            await _context.SaveChangesAsync();
            return null;
        }
        public void CarFilesToApi(CarDto dto, Car car)
        {
            string uniqueFileName = null;
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.WebRootPath + "\\multipleFileUpload\\"))
                {
                    Directory.CreateDirectory(_webHost.WebRootPath + "\\multipleFileUpload\\");
                }
                foreach (var image in dto.Files)
                {
                    string uploadsFolder = Path.Combine(_webHost.WebRootPath, "multipleFileUpload");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        image.CopyTo(fileStream);
                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            CarExistingFilePath = uniqueFileName,
                            CarId = car.Id
                        };
                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
>>>>>>> Stashed changes
    }
}