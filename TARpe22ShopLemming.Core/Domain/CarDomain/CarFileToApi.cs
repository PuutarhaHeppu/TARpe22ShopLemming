using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARpe22ShopLemming.Core.Domain.CarDomain
{
    public class CarFileToApi
    {
        public Guid Id { get; set; }
        public string CarExistingFilePath { get; set; }
        public Guid? CarId { get; set; }
    }
}
