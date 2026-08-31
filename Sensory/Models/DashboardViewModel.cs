namespace Sensory.Models;

public class DashboardViewModel
{
    public IReadOnlyList<Device> Devices { get; set; } = [];

    public IReadOnlyList<Alert> Alerts { get; set; } = [];

    public EnvironmentReading Environment { get; set; } = new();

    public int TotalDevices { get; set; }

    public int OnlineDevices { get; set; }

    public int AlertCount => Alerts.Count;

    public string EnvironmentName { get; set; } = string.Empty;
}