using Microsoft.AspNetCore.Mvc;
using Sensory.Models;
using Sensory.Services;

namespace Sensory.Controllers;

public class HomeController : Controller
{
    private readonly IDeviceService _deviceService;
    private readonly IEnvironmentService _environmentService;

    public HomeController(
        IDeviceService deviceService,
        IEnvironmentService environmentService)
    {
        _deviceService = deviceService;
        _environmentService = environmentService;
    }

    public IActionResult Index()
    {
        var viewModel = new DashboardViewModel
        {
            Devices = _deviceService.GetDevices(),
            Alerts = _deviceService.GetActiveAlerts(),
            Environment = _environmentService.GetLatestReading(),
            TotalDevices = _deviceService.GetTotalDeviceCount(),
            OnlineDevices = _deviceService.GetOnlineDeviceCount()
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}