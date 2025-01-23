namespace AppointmentBooking.Models;

public class QueryRequest
{
    private DateTime _date;

    public DateTime Date
    {
        get => _date;
        set => _date = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    public List<string> Products { get; set; }
    public string Language { get; set; }
    public string Rating { get; set; }
}