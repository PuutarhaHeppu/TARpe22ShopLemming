using TARpe22ShopLemming.Core.Dto.WeatherDtos;

namespace TARpe22ShopLemming.Core.ServiceInterface
{
    public interface IWeatherForecastsServices
    {
        Task<WeatherResultDto> WeatherDetail(WeatherResultDto dto);
    }
}