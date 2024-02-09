using Accounting_EF_DAL;
using EF_DTO;

namespace EF_BLL
{
    public class PriceManager
    {
        private readonly IDALPrice _PriceManager;

        public PriceManager(IDALPrice priceManager)
        {
            _PriceManager = priceManager;
        }


        /// <summary>
        /// Create a new Price
        /// </summary>
        /// <param name="price">Price to be added to the database</param>
        public void AddPrice(Price price)
        {
            _PriceManager.AddPrice(price);
        }


        /// <summary>
        /// Get all the prices from the database, even those that are discontinued
        /// </summary>
        /// <returns>List of Price</returns>
        public List<Price> GetPrices()
        {
            return _PriceManager.GetPrices();
        }


        /// <summary>
        /// Get the currently active prices based on the start and end dates.
        /// </summary>
        /// <returns>List of Price</returns>
        public List<Price> GetCurrentPrices()
        {
            List<Price> prices = GetPrices();
           return prices.Where(p => (p.EndDate == null || p.EndDate > DateTime.Now) && p.StartDate <= DateTime.Now).ToList();
        }


        /// <summary>
        /// Update a Price
        /// </summary>
        /// <param name="price">Price object to be updated</param>
        public void UpdatePrice(Price price)
        {
            _PriceManager.UpdatePrice(price);
        }



        /// <summary>
        /// Remove a Price from the database
        /// </summary>
        /// <param name="price">Price to be removed</param>
        public void RemovePrice(Price price)
        {
            _PriceManager.RemovePrice(price);
        }
    }
}
