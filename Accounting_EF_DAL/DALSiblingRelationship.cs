using Accounting_EF_Base;
using EF_DTO;

namespace Accounting_EF_DAL
{
    public class DALSiblingRelationship : IDALSiblingRelationship
    {
        private readonly AccountingContext _ctx;

        public DALSiblingRelationship(AccountingContext ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        /// Create a new SiblingRelationship
        /// </summary>
        /// <param name="siblingRelationship">SiblingRelationship to be created</param>
        public void CreateRelationship(SiblingRelationship siblingRelationship)
        {
            _ctx.Siblings.Add(siblingRelationship);
            _ctx.SaveChanges();
        }


        /// <summary>
        /// Remove SiblingRelationship from database
        /// </summary>
        /// <param name="relationship">SiblingRelationship to be deleted</param>
        public void RemoveSiblingRelationship(SiblingRelationship relationship)
        {
            _ctx.Siblings.Remove(relationship);
            _ctx.SaveChanges();
        }
    }
}
