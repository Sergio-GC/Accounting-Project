using EF_DTO;
using Accounting_EF_Base;

namespace Accounting_EF_DAL
{
    public class DALKid
    {
        private readonly AccountingContext _ctx;

        public DALKid(AccountingContext ctx)
        {
            _ctx = ctx;
        }

        /// <summary>
        /// Get all the kids from the database
        /// </summary>
        /// <returns>List with Kid objects</returns>
        public List<Kid> GetKids()
        {
            return _ctx.Kids.ToList();
        }

        /// <summary>
        /// Add a new Kid object to the database.
        /// If the kid has any sibling, it adds the sibling relationships too.
        /// </summary>
        /// <param name="kid">Kid object</param>
        public void AddKid(Kid kid)
        {
            _ctx.Kids.Add(kid);
            _ctx.SaveChanges();
        }

        /// <summary>
        /// Update the provided Kid.
        /// This method fetches the Kid object from the database based on the Id of the Kid object provided, then updates it.
        /// 
        /// Throws an exception if there are several entries with the same Id.
        /// </summary>
        /// <param name="kid">Kid object to replace the old one</param>
        public void UpdateKid(Kid kid)
        {
            Kid OldKid = _ctx.Kids.Single(k => k.Id == kid.Id);
            OldKid = kid;

            _ctx.SaveChanges();
        }

        /// <summary>
        ///  Remove the provided Kid object from the database.
        /// </summary>
        /// <param name="kid">Kid to be removed from the database</param>
        public void RemoveKid(Kid kid)
        {
            _ctx.Kids.Remove(kid);
            _ctx.SaveChanges();
        }
    }
}