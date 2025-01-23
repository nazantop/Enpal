using AppointmentBooking.Models;
using AppointmentBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Repositories.Implementation;

public class SalesManagerRepository(ApplicationDbContext context) : ISalesManagerRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<List<SalesManager>> GetSalesManagersAsync()
    {
        return await _context.Set<SalesManager>().ToListAsync();
    }
}