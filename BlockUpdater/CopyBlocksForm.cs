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

        // Constructor
        public CopyBlocksForm(Project activeProject, List<String> deviceList)
        {
            InitializeComponent();

            this.activeProject = activeProject;

            // Read project library master copies names and add them to check list
            List<string> libMasterCopies = BlockManagement.ReadProjectLibrary(activeProject.ProjectLibrary.MasterCopyFolder, "");

            projectLibraryCheckList.Items.AddRange(libMasterCopies.ToArray());

            // Read project Devices and add them to check list
            devicesCheckList.BeginUpdate();

            // Add to check list
            foreach (var deviceName in deviceList)
            {
                devicesCheckList.Items.Add(deviceName);
            }

            devicesCheckList.EndUpdate();
        }

        // Copy blocks button
        private void BtnCopy_Click(object sender, EventArgs e)
        {
            // Determine if any blocks have been checked
            if (projectLibraryCheckList.CheckedItems.Count != 0)
            {
                Globals.Log(projectLibraryCheckList.CheckedItems.Count + " blocks have been selected for copy");

                // Determine if there are any devices checked.  
                if (devicesCheckList.CheckedItems.Count != 0)
                {
                    Globals.Log("Systems selected: " + devicesCheckList.CheckedItems.Count);

                    var results = new List<bool>();

                    // If so loop through all devices checking if they have been selected
                    foreach (var device in activeProject.Devices)
                    {
                        if (devicesCheckList.CheckedItems.Contains(device.Name))
                        {
                            Globals.Log("Copying blocks to system " + device.Name);

                            // get plc software
                            // device represents the rack
                            // first element of DeviceItems (modules in the rack) is the plc
                            PlcSoftware software = BlockManagement.GetSoftwareFrom(device.DeviceItems[1]);

                            if (software != null)
                            {
                                MasterCopyFolder masterFolder = activeProject.ProjectLibrary.MasterCopyFolder;

                                // get blocks to be copied info
                                foreach (string item in projectLibraryCheckList.CheckedItems)
                                {
                                    string destFolder = item.Substring(0, item.IndexOf("/"));
                                    string blockToCopy = item.Substring(item.IndexOf("/") + 1);

                                    Globals.Log("Copying " + blockToCopy + " to " + destFolder);

                                    // check if it's a tag table or software block
                                    if (destFolder.Equals("PLC tags"))
                                    {
                                        results.Add(BlockManagement.CopyTagTableToFolder(blockToCopy, masterFolder, software.TagTableGroup, destFolder));
                                    }
                                    else
                                    {
                                        results.Add(BlockManagement.CopyBlockToFolder(blockToCopy, masterFolder, software.BlockGroup, destFolder));
                                    }
                                }
                            }
                        }
                    }

                    // group results
                    bool groupResult = true;

                    foreach (bool result in results)
                    {
                        if (result == false)
                            groupResult = false;
                    }

                    // final notification
                    if (groupResult)
                    {
                        var alert = new AlertForm("All copy operations successful", "Copy Blocks");
                        alert.ShowDialog();
                    }
                    else
                    {
                        var alert = new AlertForm("One or more copy operations failed", "Copy Blocks");
                        alert.ShowDialog();
                    }
                }
                else
                {
                    AlertForm alert = new AlertForm("No devices have been selected", "Error");
                    alert.Show();

                    Globals.Log("No devices have been selected");
                }
            }
            else
            {
                AlertForm alert = new AlertForm("No blocks have been selected", "Error");
                alert.ShowDialog();

                Globals.Log("No blocks have been selected for copy");
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
