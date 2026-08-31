using Sensory.Models;

namespace Sensory.Services;

public interface IEnvironmentService
{
    EnvironmentReading GetLatestReading();
}