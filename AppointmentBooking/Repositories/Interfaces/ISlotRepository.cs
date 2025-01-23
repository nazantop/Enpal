using AppointmentBooking.Models;

namespace AppointmentBooking.Repositories.Interfaces;
public interface ISlotRepository
{
    Task<List<Slot>> GetAllSlotsAsync(DateTime date);
}