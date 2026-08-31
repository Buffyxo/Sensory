namespace Sensory.Models;

public class Alert
{
    public int Id { get; set; }

    public string Message { get; set; } = string.Empty;

    public string Severity { get; set; } = "Information";

    public DateTime Timestamp { get; set; }

    public bool IsActive { get; set; } = true;
}