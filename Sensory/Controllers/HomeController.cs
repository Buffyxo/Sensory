using Microsoft.AspNetCore.Mvc;
using Sensory.Models;
using Sensory.Services;

namespace Sensory.Controllers;

public class HomeController : Controller
{
    private readonly IDeviceService _deviceService;
    private readonly IEnvironmentService _environmentService;

    private readonly IConfiguration _configuration;

    public HomeController(
        IDeviceService deviceService,
        IEnvironmentService environmentService,
        IConfiguration configuration)
    {
        _deviceService = deviceService;
        _environmentService = environmentService;
        _configuration = configuration;
    }

    public IActionResult Index()
    {
        var viewModel = new DashboardViewModel
        {
            Devices = _deviceService.GetDevices(),
            Alerts = _deviceService.GetActiveAlerts(),
            Environment = _environmentService.GetLatestReading(),
            TotalDevices = _deviceService.GetTotalDeviceCount(),
            OnlineDevices = _deviceService.GetOnlineDeviceCount(),
            EnvironmentName = _configuration["AppSettings:Environment"] ?? "Unknown"
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}