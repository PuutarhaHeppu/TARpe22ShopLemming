using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopLemming.Core.Dto.CarDtos
{
    public class CarDto
    {
        public Guid Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public string Name { get; set; }
        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDto> CarFileToApiDtos { get; set; } = new List<FileToApiDto>();

        // db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
