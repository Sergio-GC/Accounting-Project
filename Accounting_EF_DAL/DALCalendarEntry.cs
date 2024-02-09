using Accounting_EF_Base;
using EF_DTO;

namespace Accounting_EF_DAL
{
    public class DALCalendarEntry
    {
        private readonly AccountingContext _ctx;

        public DALCalendarEntry(AccountingContext ctx)
        {
            _ctx = ctx;
        }


        /// <summary>
        /// Get all the CalendarEntry from the database
        /// </summary>
        /// <returns>List of CalendarEntry</returns>
        public List<CalendarEntry> GetEntries()
        {
            return _ctx.CalendarEntries.ToList();
        }


        /// <summary>
        /// Get a Calendar Entry
        /// </summary>
        /// <param name="id">Id of the CalendarEntry to be retrieved</param>
        /// <returns>CalendarEntry</returns>
        public CalendarEntry GetEntry(int id)
        {
            return _ctx.CalendarEntries.Single(ce =>  ce.Id == id);
        }


        /// <summary>
        /// Create a new CalendarEntry
        /// </summary>
        /// <param name="entry">CalendarEntry to be added to the database</param>
        public void AddEntry(CalendarEntry entry)
        {
            _ctx.CalendarEntries.Add(entry);
            _ctx.SaveChanges();
        }


        /// <summary>
        /// Update a CalendarEntry using the data from the provided entry.
        /// This method fetches the old entry from the databse to then replace it by the provided Entry.
        /// 
        /// Throws and exception if there are several entries with the same id in the database
        /// </summary>
        /// <param name="entry"></param>
        public void UpdateEntry(CalendarEntry entry)
        {
            CalendarEntry OldEntry = _ctx.CalendarEntries.Single(ce => ce.Id == entry.Id);
            OldEntry = entry;

            _ctx.SaveChanges();
        }


        /// <summary>
        /// Delete a calendar entry
        /// </summary>
        /// <param name="entry">CalendarEntry to be deleted</param>
        public void RemoveEntry(CalendarEntry entry)
        {
            _ctx.CalendarEntries.Remove(entry);
            _ctx.SaveChanges();
        }
    }
}
