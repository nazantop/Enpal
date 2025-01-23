namespace AppointmentBooking.Models;

public class SalesManager
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<string> Languages { get; set; }
    public List<string> Products { get; set; }
    public List<string> CustomerRatings { get; set; }
}