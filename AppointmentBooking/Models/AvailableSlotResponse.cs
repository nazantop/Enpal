using System.Text.Json.Serialization;

namespace AppointmentBooking.Models;
public class AvailableSlotResponse
{
    [JsonPropertyName("available_count")]
    public int AvailableCount { get; set; }
    
    [JsonPropertyName("start_date")]
    public string StartDate => StartDateRaw.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffZ");

    [JsonIgnore]
    public DateTime StartDateRaw { get; set; }
}