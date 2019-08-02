using Siemens.Engineering;
using Siemens.Engineering.HW;
using Siemens.Engineering.SW;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CopyBlocks
{
    public partial class DeleteBlocksForm : Form
    {
        private Project activeProject;
        private List<String> types;
        private PlcSoftware plcSoftware;

        // Constructor
        public DeleteBlocksForm(Project activeProject, List<String> deviceList)
        {
            // Set types filter list
            this.types = new List<String>
            {
                "OB",
                "FC",
                "FB",
                "GlobalDB",
                "InstanceDB"
            };

            InitializeComponent();

            this.activeProject = activeProject;

            // Add project devices to listbox
            AddDeviceNames(deviceList, devicesCheckList);
            AddDeviceNames(deviceList, comboBoxPLC);

            // Set combo box selection to first item
            comboBoxPLC.SelectedIndex = 0;
        }

        // Add device names to list - Overloaded > CheckedListBox
        private void AddDeviceNames(List<String> deviceList, CheckedListBox list)
        {
            list.BeginUpdate();

            foreach (var deviceName in deviceList)
            {
                list.Items.Add(deviceName);
            }

            list.EndUpdate();
        }

        // Add device names to list - Overloaded > ComboBox
        private void AddDeviceNames(List<String> deviceList, ComboBox list)
        {
            list.BeginUpdate();

            foreach (var deviceName in deviceList)
            {
                list.Items.Add(deviceName);
            }

            list.EndUpdate();
        }

        // Add plc blocks to list
        private void AddPLCBlocks(PlcSoftware plcSoftware, CheckedListBox list, List<String> types)
        {
            list.Items.Clear();

            List<String> plcBlocks = BlockManagement.ReadPlcBlocks(plcSoftware.BlockGroup);

            list.BeginUpdate();

            foreach (string type in types)
            {
                foreach (var block in plcBlocks)
                {
                    if (block.Contains(" " + type + " "))
                    {
                        list.Items.Add(block);
                    }
                }
            }

            list.EndUpdate();
        }

        // Delete blocks button
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            // Determine if any blocks have been checked
            if (blocksCheckList.CheckedItems.Count != 0)
            {
                Utils.Log(blocksCheckList.CheckedItems.Count + " blocks have been selected for removal");

                // Determine if any devices have been checked
                if (devicesCheckList.CheckedItems.Count != 0)
                {
                    Utils.Log("Systems selected: " + devicesCheckList.CheckedItems.Count);

                    var resultsBlock = new List<bool>();
                    var resultsGlobal = new List<bool>();

                    // If so loop through all devices checking if they have been selected
                    foreach (var device in activeProject.Devices)
                    {
                        if (devicesCheckList.CheckedItems.Contains(device.Name))
                        {
                            Utils.Log("Deleting blocks from " + device.Name);

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

                                    Utils.LogVerbose("Searching for " + name);

                                    // first on root folder
                                    foreach (var block in software.BlockGroup.Blocks)
                                    {
                                        if (name.Equals(block.Name))
                                        {
                                            Utils.LogVerbose("Block " + name + " to be deleted found in root folder");

                                            block.Delete();
                                            resultsBlock.Add(true);
                                        }
                                    }

                                    // check also subfolders
                                    foreach (var group in software.BlockGroup.Groups)
                                    {
                                        resultsBlock.Add(BlockManagement.DeleteBlock(name, group));
                                    }

                                    // aggregate results after looking for all blocks
                                    // each one of the main folders will return true/false if the block was found in it/not found
                                    // if one of the results is true it means the block was found
                                    bool blockResult = false;

                                    foreach(bool result in resultsBlock)
                                    {
                                        if (result)
                                        {
                                            blockResult = true;
                                        }
                                    }

                                    resultsGlobal.Add(blockResult);
                                }
                            }
                        }
                    }

                    // group results
                    // checks if all blocks have been deleted
                    // if so all results should be true
                    bool groupResult = true;
                    
                    foreach(bool result in resultsGlobal)
                    {
                        if (!result)
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

                    Utils.Log("No devices have been selected for removal");
                }
            }
            else
            {
                AlertForm alert = new AlertForm("No blocks have been selected", "Error");
                alert.ShowDialog();

                Utils.Log("No blocks have been selected for removal");
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

        // Combo box selection changed
        private void ComboBoxPLC_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Read plc blocks and add them to check list
            // first get currently selected plc
            Device selectedDevice = activeProject.Devices.Find(comboBoxPLC.Text);

            // device represents the rack
            // first element of DeviceItems (modules in the rack) is the plc
            plcSoftware = BlockManagement.GetSoftwareFrom(selectedDevice.DeviceItems[1]);

            AddPLCBlocks(plcSoftware, blocksCheckList, types);
        }

        // Display blocks of type OB
        private void DispOBcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dispOBcheckBox.Checked)
            {
                types.Remove("OB");
            }
            else
            {
                types.Add("OB");
            }

            AddPLCBlocks(plcSoftware, blocksCheckList, types);
        }

        // Display blocks of type FC
        private void DispFCcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dispFCcheckBox.Checked)
            {
                types.Remove("FC");
            }
            else
            {
                types.Add("FC");
            }

            AddPLCBlocks(plcSoftware, blocksCheckList, types);
        }

        // Display blocks of type FB
        private void DispFBcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dispFBcheckBox.Checked)
            {
                types.Remove("FB");
            }
            else
            {
                types.Add("FB");
            }

            AddPLCBlocks(plcSoftware, blocksCheckList, types);
        }

        // Display blocks of type Global DB
        private void DispGlobalDBcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dispGlobalDBcheckBox.Checked)
            {
                types.Remove("GlobalDB");
            }
            else
            {
                types.Add("GlobalDB");
            }

            AddPLCBlocks(plcSoftware, blocksCheckList, types);
        }

        // Display blocks of type Instance DB
        private void DispInstanceDBcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!dispInstanceDBcheckBox.Checked)
            {
                types.Remove("InstanceDB");
            }
            else
            {
                types.Add("InstanceDB");
            }

            AddPLCBlocks(plcSoftware, blocksCheckList, types);
        }
    }
}
