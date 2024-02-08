using Accounting_EF_Base;
using Accounting_EF_Base.Entities;

namespace Accounting_EF_DAL
{
    public class PriceManager
    {
        private readonly AccountingContext _ctx;

        public PriceManager(AccountingContext ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        /// Get all the prices from the database
        /// </summary>
        /// <returns>List of Price</returns>
        public List<Price> GetPrices()
        {
            return _ctx.Prices.ToList();
        }


        /// <summary>
        /// Create a new Price and save it in the database
        /// </summary>
        /// <param name="price">Price to be created</param>
        public void AddPrice(Price price)
        {
            _ctx.Prices.Add(price);
            _ctx.SaveChanges();
        }


        /// <summary>
        /// Update the provided Price.
        /// This method fetches the old price and replaces it by the new one.
        /// 
        /// Throws an exception if there are several prices with the same price id in the database.
        /// </summary>
        /// <param name="price">Price with the new properties</param>
        public void UpdatePrice(Price price)
        {
            Price OldPrice = _ctx.Prices.Single(p => p.Id == price.Id);
            OldPrice = price;

            _ctx.SaveChanges();
        }


        /// <summary>
        /// Delete the provided Price
        /// </summary>
        /// <param name="price">Price to be deleted</param>
        public void RemovePrice(Price price)
        {
            _ctx.Prices.Remove(price);
            _ctx.SaveChanges();
        }
    }
}
