using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CommandObjects.BookingsServiceWebAdapter
{
    public interface IGetBookingsOutcomeResponder
    {
        Task<ActionResult> Success(IEnumerable<Booking> bookings);
        Task<HttpStatusCodeResult> Error(string message);
    }
}