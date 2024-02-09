using EF_DTO;

namespace EF_BLL
{
    public interface IPriceManager
    {
        void AddPrice(Price price);
        List<Price> GetCurrentPrices();
        List<Price> GetPrices();
        void RemovePrice(Price price);
        void UpdatePrice(Price price);
    }
}