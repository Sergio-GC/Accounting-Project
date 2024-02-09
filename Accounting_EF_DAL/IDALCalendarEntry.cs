using EF_DTO;

namespace Accounting_EF_DAL
{
    public interface IDALCalendarEntry
    {
        void AddEntry(CalendarEntry entry);
        List<CalendarEntry> GetEntries();
        CalendarEntry GetEntry(int id);
        void RemoveEntry(CalendarEntry entry);
        void UpdateEntry(CalendarEntry entry);
    }
}