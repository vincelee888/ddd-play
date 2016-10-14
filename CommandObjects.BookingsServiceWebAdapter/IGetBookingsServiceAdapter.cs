using System.Threading.Tasks;

namespace CommandObjects.BookingsServiceWebAdapter
{
    public interface IGetBookingsServiceAdapter<T> where T : class
    {
        Task<T> Get(IGetBookingsOutcomeResponder responder);
    }
}