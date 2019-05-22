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
        private TextBox log;

        // Constructor
        public CompileForm(Project activeProject, TextBox log)
        {
            InitializeComponent();

            this.activeProject = activeProject;
            this.log = log;
        }

        // Compile button
        private void BtnCompile_Click(object sender, EventArgs e)
        {
            //Determine if there are any devices checked.  
            if (devicesCheckList.CheckedItems.Count != 0)
            {
                log.AppendText("Systems selected: " + devicesCheckList.CheckedItems.Count);
                log.AppendText(Environment.NewLine);

                // If so loop through all devices checking if they have been selected
                foreach (var device in activeProject.Devices)
                {
                    if (devicesCheckList.CheckedItems.Contains(device.Name))
                    {
                        log.AppendText("Compiling system " + device.Name);
                        log.AppendText(Environment.NewLine);

                        foreach (var deviceItem in device.DeviceItems)
                        {
                            PlcSoftware software = BlockManagement.GetSoftwareFrom(deviceItem);
                            if (software != null)
                            {
                                ICompilable compileService = software.GetService<ICompilable>();
                                CompilerResult result = compileService.Compile();

                                log.AppendText(
                                    result.State + ": Compiling finished for system " +
                                    device.Name + ", " +
                                    result.WarningCount + " warnings and " +
                                    result.ErrorCount + " errors"
                                );
                                log.AppendText(Environment.NewLine);
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
