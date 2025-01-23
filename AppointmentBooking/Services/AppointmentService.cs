using AppointmentBooking.Models;
using AppointmentBooking.IServices;
using AppointmentBooking.Repositories.Interfaces;

namespace AppointmentBooking.Services;

public class AppointmentService(ISalesManagerRepository salesManagerRepository, ISlotRepository slotRepository) : IAppointmentService
{
    private readonly ISalesManagerRepository _salesManagerRepository = salesManagerRepository;
    private readonly ISlotRepository _slotRepository = slotRepository;

    public async Task<List<AvailableSlotResponse>> GetAvailableSlotsAsync(QueryRequest request)
    {
        var utcRequestDate = DateTime.SpecifyKind(request.Date, DateTimeKind.Utc);

        var salesManagers = await _salesManagerRepository.GetSalesManagersAsync();

        var matchingManagers = salesManagers.Where(sm =>
            sm.Languages.Contains(request.Language) &&
            request.Products.Count != 0 &&
            request.Products.All(product => sm.Products.Contains(product)) &&
            sm.CustomerRatings.Contains(request.Rating)).ToList();

        if (matchingManagers.Count == 0) return new List<AvailableSlotResponse>();

        var allSlots = await _slotRepository.GetAllSlotsAsync(utcRequestDate);

        var filteredSlots = allSlots
            .Where(slot => matchingManagers.Any(sm => sm.Id == slot.SalesManagerId))
            .GroupBy(slot => slot.StartDate)
            .Select(group =>
            {
                var availableManagersForSlot = matchingManagers
                    .Where(sm => group.Any(slot =>
                        slot.SalesManagerId == sm.Id &&
                        !HasOverlap(slot, allSlots)))
                    .ToList();

                return new AvailableSlotResponse
                {
                    StartDateRaw = group.Key,
                    AvailableCount = availableManagersForSlot.Count
                };
            })
            .Where(response => response.AvailableCount > 0)
            .OrderBy(response => response.StartDate)
            .ToList();

        return filteredSlots;
    }

    private static bool HasOverlap(Slot slot, List<Slot> allSlots)
    {
        return allSlots.Any(other =>
            other.SalesManagerId == slot.SalesManagerId &&
            other.Booked &&
            !(slot.EndDate <= other.StartDate || slot.StartDate >= other.EndDate));
    }
}