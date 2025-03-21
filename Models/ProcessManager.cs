using Newtonsoft.Json;
using System.Diagnostics;

public class ProcessManager
{
    private const string STATE_FILE = "stopped_processes.json";

    public List<ProcessModel> GetProcesses()
    {
        return Process.GetProcesses()
            .Select(p =>
            {
                try
                {
                    return new ProcessModel
                    {
                        ProcessName = p.ProcessName,
                        ExecutablePath = p.MainModule?.FileName ?? string.Empty
                    };
                }
                catch { return null; } // Handle access-denied  
            })
            .Where(p => p != null)
            .ToList()!;
    }

    public void StopProcesses(List<ProcessModel> processes)
    {
        foreach (var proc in processes)
        {
            foreach (var p in Process.GetProcessesByName(proc.ProcessName))
            {
                p.CloseMainWindow();
                p.Kill(); // Force termination  
            }
        }
    }

    public void SaveStoppedProcesses(List<ProcessModel> processes)
    {
        File.WriteAllText(STATE_FILE, JsonConvert.SerializeObject(processes));
    }

    public void RestoreProcesses()
    {
        if (!File.Exists(STATE_FILE)) return;
        var processes = JsonConvert.DeserializeObject<List<ProcessModel>>(File.ReadAllText(STATE_FILE));
        foreach (var proc in processes)
        {
            if (!string.IsNullOrEmpty(proc.ExecutablePath))
                Process.Start(proc.ExecutablePath);
        }
    }
}
