using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using CommandObjects.BookingsServiceWebAdapter;

namespace CommandObjects.Web.Controllers
{
    public class BookingsController : Controller, IGetBookingsOutcomeResponder
    {
        private readonly IGetBookingsServiceAdapter<ActionResult> _adapter;

        public BookingsController(IGetBookingsServiceAdapter<ActionResult> adapter)
        {
            _adapter = adapter;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            return await _adapter.Get(this);
        }

        public Task<ActionResult> Success(IEnumerable<Booking> bookings)
        {
            return Task.FromResult(View(bookings) as ActionResult);
        }

        public Task<HttpStatusCodeResult> Error(string message)
        {
            return Task.FromResult(new HttpStatusCodeResult(HttpStatusCode.InternalServerError, message));
;        }
    }
}