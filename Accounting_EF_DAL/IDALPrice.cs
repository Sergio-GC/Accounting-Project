using EF_DTO;

namespace Accounting_EF_DAL
{
    public interface IDALPrice
    {
        void AddPrice(Price price);
        List<Price> GetPrices();
        void RemovePrice(Price price);
        void UpdatePrice(Price price);
    }
}