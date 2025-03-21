namespace ResourceGuardian
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabControl = new TabControl();
            Processes = new TabPage();
            ProcessesListView = new ListView();
            Services = new TabPage();
            ServicesListView = new ListView();
            SaveSelectionButton = new Button();
            TabControl.SuspendLayout();
            Processes.SuspendLayout();
            Services.SuspendLayout();
            SuspendLayout();
            // 
            // TabControl
            // 
            TabControl.Controls.Add(Processes);
            TabControl.Controls.Add(Services);
            TabControl.Dock = DockStyle.Top;
            TabControl.Location = new Point(0, 0);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(800, 395);
            TabControl.TabIndex = 4;
            // 
            // Processes
            // 
            Processes.Controls.Add(ProcessesListView);
            Processes.Location = new Point(4, 29);
            Processes.Name = "Processes";
            Processes.Padding = new Padding(3);
            Processes.Size = new Size(792, 362);
            Processes.TabIndex = 0;
            Processes.Text = "Processes";
            Processes.UseVisualStyleBackColor = true;
            // 
            // ProcessesListView
            // 
            ProcessesListView.BorderStyle = BorderStyle.FixedSingle;
            ProcessesListView.CheckBoxes = true;
            ProcessesListView.Dock = DockStyle.Fill;
            ProcessesListView.GridLines = true;
            ProcessesListView.Location = new Point(3, 3);
            ProcessesListView.Name = "ProcessesListView";
            ProcessesListView.Size = new Size(786, 356);
            ProcessesListView.TabIndex = 3;
            ProcessesListView.UseCompatibleStateImageBehavior = false;
            ProcessesListView.View = View.Details;
            // 
            // Services
            // 
            Services.Controls.Add(ServicesListView);
            Services.Location = new Point(4, 29);
            Services.Name = "Services";
            Services.Padding = new Padding(3);
            Services.Size = new Size(792, 362);
            Services.TabIndex = 1;
            Services.Text = "Services";
            Services.UseVisualStyleBackColor = true;
            // 
            // ServicesListView
            // 
            ServicesListView.BorderStyle = BorderStyle.FixedSingle;
            ServicesListView.CheckBoxes = true;
            ServicesListView.Dock = DockStyle.Fill;
            ServicesListView.GridLines = true;
            ServicesListView.Location = new Point(3, 3);
            ServicesListView.Name = "ServicesListView";
            ServicesListView.Size = new Size(786, 356);
            ServicesListView.TabIndex = 4;
            ServicesListView.UseCompatibleStateImageBehavior = false;
            ServicesListView.View = View.Details;
            // 
            // SaveSelectionButton
            // 
            SaveSelectionButton.Dock = DockStyle.Bottom;
            SaveSelectionButton.Location = new Point(0, 401);
            SaveSelectionButton.Name = "SaveSelectionButton";
            SaveSelectionButton.Size = new Size(800, 49);
            SaveSelectionButton.TabIndex = 5;
            SaveSelectionButton.Text = "Save Selection";
            SaveSelectionButton.UseVisualStyleBackColor = true;
            SaveSelectionButton.Click += SaveSelectionButton_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SaveSelectionButton);
            Controls.Add(TabControl);
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            TabControl.ResumeLayout(false);
            Processes.ResumeLayout(false);
            Services.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl TabControl;
        private TabPage Processes;
        private ListView ProcessesListView;
        private TabPage Services;
        private ListView ServicesListView;
        private Button SaveSelectionButton;
    }
}