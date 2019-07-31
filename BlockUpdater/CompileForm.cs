using Siemens.Engineering;
using Siemens.Engineering.Compiler;
using Siemens.Engineering.SW;
using System;
using System.Windows.Forms;

namespace CopyBlocks
{
    public partial class CompileForm : Form
    {
        private Project activeProject;

        // Constructor
        public CompileForm(Project activeProject)
        {
            InitializeComponent();

            this.activeProject = activeProject;

            // Read project Devices and add them to check list
            devicesCheckList.BeginUpdate();

            foreach (var device in activeProject.Devices)
            {
                if (device.TypeIdentifier != "System:Device.PC")
                    devicesCheckList.Items.Add(device.Name);
            }

            devicesCheckList.EndUpdate();
        }

        // Compile button
        private void BtnCompile_Click(object sender, EventArgs e)
        {
            //Determine if there are any devices checked.  
            if (devicesCheckList.CheckedItems.Count != 0)
            {
                Globals.Log("Systems selected: " + devicesCheckList.CheckedItems.Count);

                // If so loop through all devices checking if they have been selected
                foreach (var device in activeProject.Devices)
                {
                    if (devicesCheckList.CheckedItems.Contains(device.Name))
                    {
                        Globals.Log("Compiling system " + device.Name);

                        foreach (var deviceItem in device.DeviceItems)
                        {
                            PlcSoftware software = BlockManagement.GetSoftwareFrom(deviceItem);
                            if (software != null)
                            {
                                ICompilable compileService = software.GetService<ICompilable>();
                                CompilerResult result = compileService.Compile();

                                Globals.Log(
                                    result.State + ": Compiling finished for system " +
                                    device.Name + ", " +
                                    result.WarningCount + " warnings and " +
                                    result.ErrorCount + " errors"
                                );

                            }
                        }
                    }
                }
            }
            }

        // Cancel button
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Select all devices
        private void BtnSelectAllDevices_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < devicesCheckList.Items.Count; i++)
            {
                devicesCheckList.SetItemChecked(i, true);
            }
        }

        // Select no devices
        private void BtnSelectNoneDevices_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < devicesCheckList.Items.Count; i++)
            {
                devicesCheckList.SetItemChecked(i, false);
            }
        }
    }
}
