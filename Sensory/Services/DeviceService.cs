using Sensory.Models;

namespace Sensory.Services;

public class DeviceService : IDeviceService
{
    private readonly List<Device> _devices;
    private readonly List<Alert> _alerts;

    public DeviceService()
    {
        _devices =
        [
            new LightBulb
            {
                Id = 1,
                Name = "Living Room Light",
                Room = "Living Room",
                IsOnline = true,
                IsOn = true,
                Brightness = 80
            },
            new LightBulb
            {
                Id = 2,
                Name = "Bedroom Light",
                Room = "Bedroom",
                IsOnline = true,
                IsOn = false,
                Brightness = 60
            },
            new SmartPlug
            {
                Id = 3,
                Name = "Coffee Machine",
                Room = "Kitchen",
                IsOnline = true,
                IsOn = true
            },
            new Sensor
            {
                Id = 4,
                Name = "Living Room Sensor",
                Room = "Living Room",
                IsOnline = true,
                Temperature = 24.5,
                Humidity = 61
            },
            new SecurityCamera
            {
                Id = 5,
                Name = "Front Door Camera",
                Room = "Entrance",
                IsOnline = false,
                IsRecording = false
            }
        ];

        _alerts =
        [
            new Alert
            {
                Id = 1,
                Message = "Front Door Camera is offline",
                Severity = "Warning",
                Timestamp = DateTime.Now.AddMinutes(-5),
                IsActive = true
            }
        ];
    }

    public IReadOnlyList<Device> GetDevices()
    {
        return _devices;
    }

    public Device? GetDeviceById(int id)
    {
        return _devices.FirstOrDefault(device => device.Id == id);
    }

    public bool ToggleDevice(int id)
    {
        Device? device = GetDeviceById(id);

        if (device is LightBulb lightBulb)
        {
            lightBulb.IsOn = !lightBulb.IsOn;
            return true;
        }

        if (device is SmartPlug smartPlug)
        {
            smartPlug.IsOn = !smartPlug.IsOn;
            return true;
        }

        return false;
    }

    public int GetTotalDeviceCount()
    {
        return _devices.Count;
    }

    public int GetOnlineDeviceCount()
    {
        return _devices.Count(device => device.IsOnline);
    }

    public IReadOnlyList<Alert> GetActiveAlerts()
    {
        return _alerts.Where(alert => alert.IsActive).ToList();
    }
}