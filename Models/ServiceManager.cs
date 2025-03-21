using Newtonsoft.Json;
using System.ServiceProcess;

public class ServiceManager
{
    private const string STATE_FILE = "stopped_services.json";

    public List<ServiceModel> GetServices()
    {
        return ServiceController.GetServices()
            .Select(s => new ServiceModel
            {
                ServiceName = s.ServiceName,
                DisplayName = s.DisplayName
            })
            .ToList();
    }

    public void StopServices(List<ServiceModel> services)
    {
        foreach (var service in services)
        {
            var sc = new ServiceController(service.ServiceName);
            if (sc.Status == ServiceControllerStatus.Running)
            {
                sc.Stop();
                sc.WaitForStatus(ServiceControllerStatus.Stopped);
            }
        }
    }

    public void StopService(ServiceModel service)
    {
        var sc = new ServiceController(service.ServiceName);
        if (sc.Status == ServiceControllerStatus.Running)
        {
            sc.Stop();
            sc.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromSeconds(30));
        }
    }

    public void RestartServices(List<ServiceModel> services)
    {
        foreach (var service in services)
        {
            var sc = new ServiceController(service.ServiceName);
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
        }
    }

    public void SaveStoppedServices(List<ServiceModel> services)
    {
        File.WriteAllText(STATE_FILE, JsonConvert.SerializeObject(services));
    }

    public void RestoreServices()
    {
        if (!File.Exists(STATE_FILE)) return;
        var services = JsonConvert.DeserializeObject<List<ServiceModel>>(File.ReadAllText(STATE_FILE));
        foreach (var service in services)
        {
            var sc = new ServiceController(service.ServiceName);
            if (sc.Status == ServiceControllerStatus.Stopped)
            {
                sc.Start();
                sc.WaitForStatus(ServiceControllerStatus.Running);
            }
        }
    }
}
