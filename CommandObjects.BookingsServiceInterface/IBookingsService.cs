using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommandObjects.BookingsServiceInterface
{
    public interface IBookingsService
    {
        Task<IEnumerable<Booking>> GetBookings();
        Task<bool> CreateBooking(Booking booking);
    }

    public class BookingsService : IBookingsService
    {
        public Task<IEnumerable<Booking>> GetBookings()
        {
            return Task.FromResult(new[]
            {
                new Booking(),
                new Booking(),
                new Booking(),
                new Booking()
            }.AsEnumerable());
        }

        public Task<bool> CreateBooking(Booking booking)
        {
            throw new System.NotImplementedException();
        }
    }
}