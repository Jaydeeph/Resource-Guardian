﻿namespace ResourceGuardian
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TabControl = new TabControl();
            Processes = new TabPage();
            ProcessesListView = new ListView();
            Services = new TabPage();
            ServicesListView = new ListView();
            StatusLabel = new Label();
            StopProcessesAndServicesButton = new Button();
            RestoreProcessesAndServicesButton = new Button();
            SettingsButton = new Button();
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
            TabControl.Size = new Size(788, 395);
            TabControl.TabIndex = 3;
            // 
            // Processes
            // 
            Processes.Controls.Add(ProcessesListView);
            Processes.Location = new Point(4, 29);
            Processes.Name = "Processes";
            Processes.Padding = new Padding(3);
            Processes.Size = new Size(780, 362);
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
            ProcessesListView.Size = new Size(774, 356);
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
            Services.Size = new Size(780, 362);
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
            ServicesListView.Size = new Size(774, 356);
            ServicesListView.TabIndex = 4;
            ServicesListView.UseCompatibleStateImageBehavior = false;
            ServicesListView.View = View.Details;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.Dock = DockStyle.Bottom;
            StatusLabel.Location = new Point(0, 460);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(56, 20);
            StatusLabel.TabIndex = 8;
            StatusLabel.Text = "Status: ";
            // 
            // StopProcessesAndServicesButton
            // 
            StopProcessesAndServicesButton.Location = new Point(12, 399);
            StopProcessesAndServicesButton.Name = "StopProcessesAndServicesButton";
            StopProcessesAndServicesButton.Size = new Size(211, 57);
            StopProcessesAndServicesButton.TabIndex = 10;
            StopProcessesAndServicesButton.Text = "Stop Processes/Services";
            StopProcessesAndServicesButton.UseVisualStyleBackColor = true;
            StopProcessesAndServicesButton.MouseClick += StopProcessesAndServicesButton_Click;
            // 
            // RestoreProcessesAndServicesButton
            // 
            RestoreProcessesAndServicesButton.Location = new Point(229, 400);
            RestoreProcessesAndServicesButton.Name = "RestoreProcessesAndServicesButton";
            RestoreProcessesAndServicesButton.Size = new Size(211, 55);
            RestoreProcessesAndServicesButton.TabIndex = 11;
            RestoreProcessesAndServicesButton.Text = "Restore Processes/Services";
            RestoreProcessesAndServicesButton.UseVisualStyleBackColor = true;
            RestoreProcessesAndServicesButton.Click += RestoreProcessesAndServicesButton_Click;
            // 
            // SettingsButton
            // 
            SettingsButton.Location = new Point(565, 401);
            SettingsButton.Name = "SettingsButton";
            SettingsButton.Size = new Size(211, 55);
            SettingsButton.TabIndex = 12;
            SettingsButton.Text = "Settings";
            SettingsButton.UseVisualStyleBackColor = true;
            SettingsButton.Click += SettingsButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(788, 480);
            Controls.Add(SettingsButton);
            Controls.Add(RestoreProcessesAndServicesButton);
            Controls.Add(StopProcessesAndServicesButton);
            Controls.Add(StatusLabel);
            Controls.Add(TabControl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Resource Guardian";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            TabControl.ResumeLayout(false);
            Processes.ResumeLayout(false);
            Services.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl TabControl;
        private TabPage Processes;
        private TabPage Services;
        private ListView ProcessesListView;
        private ListView ServicesListView;
        private Label StatusLabel;
        private Button StopProcessesAndServicesButton;
        private Button RestoreProcessesAndServicesButton;
        private Button SettingsButton;
    }
}
