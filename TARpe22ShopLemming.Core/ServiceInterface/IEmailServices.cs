using TARpe22ShopLemming.Core.Dto;

namespace TARpe22ShopLemming.Core.ServiceInterface
{
    public interface IEmailServices
    {
        void SendEmail(EmailDto dto);
    }
}