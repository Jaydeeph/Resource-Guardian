using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceGuardian
{
    public partial class SettingsForm : Form
    {
        private ProcessManager _processManager;
        private ServiceManager _serviceManager;
        private List<ProcessModel> _stoppableProcesses;
        private List<ServiceModel> _stoppableServices;
        private MainForm _mainForm;

        public SettingsForm(MainForm mainform)
        {
            InitializeComponent();
            _mainForm = mainform;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
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

        private void LoadSelections()
        {
            if (File.Exists("termination_selections.json"))
            {
                var selections = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText("termination_selections.json"));
                foreach (ListViewItem item in ProcessesListView.Items)
                {
                    if (selections.Processes.Contains(item.Text))
                        item.Checked = true;
                }
                foreach (ListViewItem item in ServicesListView.Items)
                {
                    if (selections.Services.Contains(item.Text))
                        item.Checked = true;
                }
            }
        }

        private void SaveSelectionButton_Click(object sender, EventArgs e)
        {
            var selectedProcesses = ProcessesListView.CheckedItems.Cast<ListViewItem>().Select(item => item.Text).ToList();
            var selectedServices = ServicesListView.CheckedItems.Cast<ListViewItem>().Select(item => item.Text).ToList();
            var selections = new TerminationSelections { Processes = selectedProcesses, Services = selectedServices };

            File.WriteAllText("termination_selections.json", JsonConvert.SerializeObject(new { Processes = selectedProcesses, Services = selectedServices }));
            _mainForm.LoadSelections();
            MessageBox.Show("Selection has been saved.", "Close Settings", MessageBoxButtons.OK);
            this.Close();
        }

        
    }
}
