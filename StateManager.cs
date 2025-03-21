using Newtonsoft.Json;
using ResourceGuardian;
using System.Diagnostics;
using System.ServiceProcess;

public class StateManager
{
    private string _filePath;

    public StateManager(string filePath) => _filePath = filePath;

    public void SaveState(List<Process> processes, List<ServiceController> services)
    {
        var state = new AppState
        {
            Processes = processes.Select(p => new ProcessModel { ProcessName = p.ProcessName, ExecutablePath = p.MainModule.FileName }).ToList(),
            Services = services.Select(s => new ServiceModel { ServiceName = s.ServiceName, DisplayName = s.DisplayName }).ToList()
        };
        File.WriteAllText(_filePath, JsonConvert.SerializeObject(state));
    }

    public (List<ProcessModel> Processes, List<ServiceModel> Services) LoadState()
    {
        var state = JsonConvert.DeserializeObject<AppState>(File.ReadAllText(_filePath));
        return (state.Processes, state.Services);
    }
}
