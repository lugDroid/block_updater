using Siemens.Engineering;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CopyBlocks
{
    public partial class DeleteBlocksForm : Form
    {
        private Project activeProject;
        private TextBox log;

        // Constructor
        public DeleteBlocksForm(Project activeProject, TextBox log)
        {
            InitializeComponent();

            this.activeProject = activeProject;
            this.log = log;

            // Read project Devices and add them to check list
            devicesCheckList.BeginUpdate();

            foreach (var device in activeProject.Devices)
            {
                if (device.TypeIdentifier != "System:Device.PC")
                    devicesCheckList.Items.Add(device.Name);
            }

            devicesCheckList.EndUpdate();

            // Read plc blocks and add them to check list
            // device represents the rack
            // first element of DeviceItems (modules in the rack) is the plc
            PlcSoftware firstPlcSoftware = BlockManagement.GetSoftwareFrom(activeProject.Devices[0].DeviceItems[1]);

            List<string> plcBlocks = BlockManagement.ReadPlcBlocks(firstPlcSoftware.BlockGroup);

            blocksCheckList.Items.AddRange(plcBlocks.ToArray());
        }

        // Delete blocks button
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Determine if any blocks have been checked
            if (blocksCheckList.CheckedItems.Count != 0)
            {
                log.AppendText(blocksCheckList.CheckedItems.Count + " blocks have been selected for deletion");
                log.AppendText(Environment.NewLine);

                // Determine if any devices have been checked
                if (devicesCheckList.CheckedItems.Count != 0)
                {
                    log.AppendText("Systems selected: " + devicesCheckList.CheckedItems.Count);
                    log.AppendText(Environment.NewLine);

                    var results = new List<bool>();

                    // If so loop through all devices checking if they have been selected
                    foreach (var device in activeProject.Devices)
                    {
                        if (devicesCheckList.CheckedItems.Contains(device.Name))
                        {
                            log.AppendText("Deleting blocks from " + device.Name);
                            log.AppendText(Environment.NewLine);

                            // get plc software
                            // device represents the rack
                            // first element of DeviceItems (modules in the rack) is the plc
                            PlcSoftware software = BlockManagement.GetSoftwareFrom(device.DeviceItems[1]);

                            if (software != null)
                            {
                                // now remove selected blocks
                                foreach (string blockName in blocksCheckList.CheckedItems)
                                {
                                    // clean blockName string
                                    string name = blockName.Substring(0, blockName.IndexOf('-') - 1);

                                    log.AppendText("Searching for " + name);
                                    log.AppendText(Environment.NewLine);

                                    // first on root folder
                                    foreach (var block in software.BlockGroup.Blocks)
                                    {
                                        if (name.Equals(block.Name))
                                        {
                                            log.AppendText("Block " + name + " to be deleted found in root folder");
                                            log.AppendText(Environment.NewLine);
                                            block.Delete();
                                            results.Add(true);
                                        }
                                    }

                                    // check also subfolders
                                    foreach (var group in software.BlockGroup.Groups)
                                    {
                                        BlockManagement.DeleteBlock(name, group, log);
                                    }
                                }
                            }
                        }
                    }

                    // group results
                    bool groupResult = true;

                    foreach(bool result in results)
                    {
                        if (result == false)
                            groupResult = false;
                    }

                    // final notification
                    if (groupResult)
                    {
                        var alert = new AlertForm("All delete operations successful", "Delete Blocks");
                        alert.ShowDialog();
                    }
                    else
                    {
                        var alert = new AlertForm("One or more delete operations failed", "Delete Blocks");
                        alert.ShowDialog();
                    }
                }
                else
                {
                    AlertForm alert = new AlertForm("No devices have been selected", "Error");
                    alert.ShowDialog();

                    log.AppendText("No devices have been selected for deletion");
                    log.AppendText(Environment.NewLine);
                }
            }
            else
            {
                AlertForm alert = new AlertForm("No blocks have been selected", "Error");
                alert.ShowDialog();

                log.AppendText("No blocks have been selected for deletion");
                log.AppendText(Environment.NewLine);
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

        // Select all plc program blocks
        private void BtnSelectAllBlocks_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < blocksCheckList.Items.Count; i++)
            {
                blocksCheckList.SetItemChecked(i, true);
            }
        }

        // Select no plc program blocks
        private void BtnSelectNoneBlocks_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < blocksCheckList.Items.Count; i++)
            {
                blocksCheckList.SetItemChecked(i, false);
            }
        }
    }
}
