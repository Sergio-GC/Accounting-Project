using EF_DTO;

namespace Accounting_EF_DAL
{
    public interface IDALKid
    {
        void AddKid(Kid kid);
        List<Kid> GetKids();
        void RemoveKid(Kid kid);
        void UpdateKid(Kid kid);
    }
}