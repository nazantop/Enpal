using AppointmentBooking.Models;
using AppointmentBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Repositories.Implementation;

public class SlotRepository(ApplicationDbContext context) : ISlotRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<Slot>> GetAllSlotsAsync(DateTime date)
    {
        return await _context.Set<Slot>()
            .Where(s => s.StartDate.Date == date.Date)
            .ToListAsync();
    }

}