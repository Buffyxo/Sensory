using Sensory.Models;

namespace Sensory.Services;

public interface IDeviceService
{
    IReadOnlyList<Device> GetDevices();

    Device? GetDeviceById(int id);

    bool ToggleDevice(int id);

    int GetTotalDeviceCount();

    int GetOnlineDeviceCount();

    IReadOnlyList<Alert> GetActiveAlerts();
}