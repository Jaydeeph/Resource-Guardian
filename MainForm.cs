using Newtonsoft.Json;
using System.Diagnostics;


namespace ResourceGuardian
{
    public partial class MainForm : Form
    {
        private ProcessManager _processManager;
        private ServiceManager _serviceManager;
        private List<ProcessModel> _stoppableProcesses;
        private List<ServiceModel> _stoppableServices;
        private Dictionary<string, DateTime> _terminationAttempts = new Dictionary<string, DateTime>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                _processManager = new ProcessManager();
                _serviceManager = new ServiceManager();
                LoadProcesses();
                LoadServices();
                LoadSelections();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveCurrentState();
        }

        private void LoadProcesses()
        {
            ProcessesListView.Columns.Clear();
            ProcessesListView.Items.Clear();
            ProcessesListView.Columns.Add("Process Name", 200);
            ProcessesListView.Columns.Add("Executable Path", 400);

            _stoppableProcesses = _processManager.GetProcesses().ToList();
            foreach (var process in _stoppableProcesses)
            {
                var item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.ExecutablePath);
                item.Tag = process;
                ProcessesListView.Items.Add(item);
            }
        }

        private void LoadServices()
        {
            ServicesListView.Columns.Clear();
            ServicesListView.Items.Clear();
            ServicesListView.Columns.Add("Service Name", 200);
            ServicesListView.Columns.Add("Display Name", 400);

            _stoppableServices = _serviceManager.GetServices().ToList();
            foreach (var service in _stoppableServices)
            {
                var item = new ListViewItem(service.ServiceName);
                item.SubItems.Add(service.DisplayName);
                item.Tag = service;
                ServicesListView.Items.Add(item);
            }
        }

        public void LoadSelections()
        {
            if (!File.Exists("termination_selections.json")) return;

            var selections = JsonConvert.DeserializeObject<TerminationSelections>(File.ReadAllText("termination_selections.json"));
            foreach (ListViewItem item in ProcessesListView.Items)
            {
                if (selections.Processes.Contains(item.Text, StringComparer.OrdinalIgnoreCase))
                    item.Checked = true;
            }
            foreach (ListViewItem item in ServicesListView.Items)
            {
                if (selections.Services.Contains(item.Text, StringComparer.OrdinalIgnoreCase))
                    item.Checked = true;
            }
        }

        private async void StopProcessesAndServicesButton_Click(object sender, MouseEventArgs e)
        {
            try
            {
                var selectedProcesses = ProcessesListView.CheckedItems
                    .Cast<ListViewItem>()
                    .Select(item => item.Tag as ProcessModel)
                    .Where(p => p != null)
                    .ToList();

                var selectedServices = ServicesListView.CheckedItems
                    .Cast<ListViewItem>()
                    .Select(item => item.Tag as ServiceModel)
                    .Where(s => s != null)
                    .ToList();

                if (selectedProcesses.Count == 0 && selectedServices.Count == 0) return;

                if (MessageBox.Show(
                    "Stop selected processes and services? They will be terminated gracefully if possible.",
                    "Confirm",
                    MessageBoxButtons.YesNo) != DialogResult.Yes)
                    return;

                if (selectedProcesses.Count > 0)
                    await StopProcessesGracefully(selectedProcesses);

                if (selectedServices.Count > 0)
                    await StopServices(selectedServices);

                var stoppedItems = new { Processes = selectedProcesses, Services = selectedServices };
                File.WriteAllText("stopped_items.json", JsonConvert.SerializeObject(stoppedItems));

                StopProcessesAndServicesButton.Enabled = false;
                RestoreProcessesAndServicesButton.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowError("Error stopping processes or services.", ex);
            }
        }

        private async Task StopProcessesGracefully(List<ProcessModel> processes)
        {
            _terminationAttempts.Clear();

            foreach (var proc in processes)
            {
                try
                {
                    var runningProcesses = Process.GetProcessesByName(proc.ProcessName);
                    foreach (var p in runningProcesses)
                    {
                        _terminationAttempts[p.ProcessName] = DateTime.Now;
                        p.CloseMainWindow();
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    StatusLabel.Text = $"Access denied to {proc.ProcessName} - requires admin rights";
                    continue; // Skip this process
                }
                catch (Exception ex)
                {
                    ShowError($"Error closing {proc.ProcessName}", ex);
                }
            }

            await Task.Delay(5000); // Give processes time to close gracefully

            // Force kill remaining processes
            foreach (var proc in processes)
            {
                try
                {
                    var runningProcesses = Process.GetProcessesByName(proc.ProcessName);
                    foreach (var p in runningProcesses)
                    {
                        if (!p.HasExited)
                        {
                            p.Kill();
                            StatusLabel.Text = $"Force terminated {proc.ProcessName}";
                        }
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    StatusLabel.Text = $"Access denied to kill {proc.ProcessName}";
                }
                catch (Exception ex)
                {
                    ShowError($"Error terminating {proc.ProcessName}", ex);
                }
            }

            _processManager.SaveStoppedProcesses(processes);
            StatusLabel.Text = "Process termination completed";
            LoadProcesses(); // Refresh the list
        }

        private async Task StopServices(List<ServiceModel> services)
        {
            foreach (var service in services)
            {
                try
                {
                    StatusLabel.Text = $"Stopping service: {service.DisplayName}";
                    await Task.Run(() => _serviceManager.StopService(service));
                }
                catch (Exception ex)
                {
                    ShowError($"Error stopping service {service.DisplayName}", ex);
                }
            }
            _serviceManager.SaveStoppedServices(services);
            StatusLabel.Text = "Service operations completed";
            LoadServices(); // Refresh the list
        }

        private void RestoreProcessesAndServicesButton_Click(object sender, EventArgs e)
        {
            try
            {
                _processManager.RestoreProcesses();
                _serviceManager.RestoreServices();

                StopProcessesAndServicesButton.Enabled = true;
                RestoreProcessesAndServicesButton.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error restoring processes or services: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveCurrentState()
        {
            var state = new AppState
            {
                Processes = _stoppableProcesses,
                Services = _stoppableServices
            };
            File.WriteAllText("app_state.json", JsonConvert.SerializeObject(state));
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show(
                $"{message}\n\nError: {ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
        }
    }
}
