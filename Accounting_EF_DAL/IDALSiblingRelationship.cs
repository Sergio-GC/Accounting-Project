using EF_DTO;

namespace Accounting_EF_DAL
{
    public interface IDALSiblingRelationship
    {
        void CreateRelationship(SiblingRelationship siblingRelationship);
        void RemoveSiblingRelationship(SiblingRelationship relationship);
    }
}