using AppointmentBooking.Models;

namespace AppointmentBooking.Repositories.Interfaces
{
   public interface ISalesManagerRepository
    {
        Task<List<SalesManager>> GetSalesManagersAsync();
    }
}