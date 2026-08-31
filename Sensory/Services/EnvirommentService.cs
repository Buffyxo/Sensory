using Sensory.Models;

namespace Sensory.Services;

public class EnvironmentService : IEnvironmentService
{
    public EnvironmentReading GetLatestReading()
    {
        return new EnvironmentReading
        {
            Temperature = 24.5,
            Humidity = 61,
            Timestamp = DateTime.Now
        };
    }
}