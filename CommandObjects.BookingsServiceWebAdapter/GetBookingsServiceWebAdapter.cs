using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using CommandObjects.BookingsServiceInterface;

namespace CommandObjects.BookingsServiceWebAdapter
{
    public class GetBookingsServiceWebAdapter : IGetBookingsServiceAdapter<ActionResult>
    {
        private readonly IBookingsService _bookingsService;

        public GetBookingsServiceWebAdapter(IBookingsService bookingsService)
        {
            _bookingsService = bookingsService;
        }

        public async Task<ActionResult>  Get(IGetBookingsOutcomeResponder responder)
        {
            try
            {
                var bookings = await _bookingsService.GetBookings();
                return await responder.Success(bookings.Select(b => new Booking()));
            }
            catch (Exception e)
            {
                return await responder.Error(e.Message);
            }
        }
    }
}