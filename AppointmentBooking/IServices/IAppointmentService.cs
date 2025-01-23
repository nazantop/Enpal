using AppointmentBooking.Models;

namespace AppointmentBooking.IServices;
public interface IAppointmentService
{
    Task<List<AvailableSlotResponse>> GetAvailableSlotsAsync(QueryRequest request);
}