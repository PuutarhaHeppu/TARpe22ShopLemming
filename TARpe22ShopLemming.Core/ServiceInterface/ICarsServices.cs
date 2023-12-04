using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARpe22ShopLemming.Core.Domain.CarDomain;
using TARpe22ShopLemming.Core.Dto.CarDtos;

namespace TARpe22ShopLemming.Core.ServiceInterface
{
    public interface ICarsServices
    {
        Task<Car> Create(CarDto dto);
        Task<Car> GetAsync(Guid id);
        Task<Car> Delete(Guid id);
        Task<Car> Update(CarDto dto);
    }
}
