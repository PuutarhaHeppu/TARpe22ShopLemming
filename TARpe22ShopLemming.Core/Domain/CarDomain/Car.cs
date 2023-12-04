using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopLemming.Core.Domain.CarDomain
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int HorsePower { get; set; }
        public string Name { get; set; }
        public IEnumerable<CarFileToApi> CarFilesToApi { get; set; } = new List<CarFileToApi>();

        // db only
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
