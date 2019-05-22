using Siemens.Engineering;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CopyBlocks
{
    public partial class CopyBlocksForm : Form
    {
        private Project activeProject;
        private TextBox log;

        // Constructor
        public CopyBlocksForm(Project activeProject, TextBox log)
        {
            InitializeComponent();

            this.activeProject = activeProject;
            this.log = log;

            // Read project library master copies names and add them to check list
            List<string> libMasterCopies = BlockManagement.ReadProjectLibrary(activeProject.ProjectLibrary.MasterCopyFolder, "");

            projectLibraryCheckList.Items.AddRange(libMasterCopies.ToArray());

            // Read project Devices and add them to check list
            devicesCheckList.BeginUpdate();

            foreach (var device in activeProject.Devices)
            {
                if (device.TypeIdentifier != "System:Device.PC")
                    devicesCheckList.Items.Add(device.Name);
            }

            devicesCheckList.EndUpdate();
        }

        // Copy blocks button
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            // Determine if there are any devices checked.  
            if (devicesCheckList.CheckedItems.Count != 0)
            {
                log.AppendText("Systems selected: " + devicesCheckList.CheckedItems.Count);
                log.AppendText(Environment.NewLine);

                // If so loop through all devices checking if they have been selected
                foreach (var device in activeProject.Devices)
                {
                    if (devicesCheckList.CheckedItems.Contains(device.Name))
                    {
                        log.AppendText("Applying changes to system " + device.Name);
                        log.AppendText(Environment.NewLine);

                        foreach (var deviceItem in device.DeviceItems)
                        {
                            PlcSoftware software = BlockManagement.GetSoftwareFrom(deviceItem);
                            if (software != null)
                            {
                                MasterCopyFolder masterFolder = activeProject.ProjectLibrary.MasterCopyFolder;

                                bool result = false;

                                // get blocks to be copied info
                                foreach (string item in projectLibraryCheckList.CheckedItems)
                                {
                                    string destFolder = item.Substring(0, item.IndexOf("/"));
                                    string blockToCopy = item.Substring(item.IndexOf("/") + 1);
                                    log.AppendText("Copying " + blockToCopy + " to " + destFolder);
                                    log.AppendText(Environment.NewLine);

                                    

                                    // check if it's a tag table or software block
                                    if (destFolder.Equals("PLC tags"))
                                    {
                                        if (BlockManagement.CopyTagTableToFolder(blockToCopy, masterFolder, software.TagTableGroup, destFolder, log))
                                            result = true;
                                    }
                                    else
                                    {
                                        if (BlockManagement.CopyBlockToFolder(blockToCopy, masterFolder, software.BlockGroup, destFolder, log))
                                            result = true;
                                    }
                                }

                                if (result)
                                {
                                    var alert = new AlertForm("All copy operations successful", "Copy Blocks");
                                    alert.Show();
                                }
                                else
                                {
                                    var alert = new AlertForm("One or more copy operations failed", "Copy Blocks");
                                    alert.Show();
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                AlertForm alert = new AlertForm("No systems have been selected", "Error");
                alert.Show();

                log.AppendText("No systems have been selected");
                log.AppendText(Environment.NewLine);
            }
        }

        // Cancel button
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Select all library blocks
        private void BtnSelectAllLibrary_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < projectLibraryCheckList.Items.Count; i++)
            {
                projectLibraryCheckList.SetItemChecked(i, true);
            }
        }

        // Select no library blocks
        private void BtnSelectNoneLibrary_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < projectLibraryCheckList.Items.Count; i++)
            {
                projectLibraryCheckList.SetItemChecked(i, false);
            }
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
