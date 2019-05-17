﻿using Microsoft.Win32;
using Siemens.Engineering;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace CopyBlocks
{
    public partial class MainForm : Form
    {
        public TiaPortal MyTiaPortal
        {
            get; set;
        }
        public Project MyProject
        {
            get; set;
        }
        public static TiaPortalProcess _tiaProcess;

        public MainForm()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
        }

        private static Assembly MyResolver(object sender, ResolveEventArgs args)
        {
            int index = args.Name.IndexOf(',');
            if (index == -1)
            {
                return null;
            }
            string name = args.Name.Substring(0, index);

            RegistryKey filePathReg = Registry.LocalMachine.OpenSubKey(
                "SOFTWARE\\Siemens\\Automation\\Openness\\15.0\\PublicAPI\\15.0.0.0");

            object oRegKeyValue = filePathReg?.GetValue(name);
            if (oRegKeyValue != null)
            {
                string filePath = oRegKeyValue.ToString();

                string path = filePath;
                string fullPath = Path.GetFullPath(path);
                if (File.Exists(fullPath))
                {
                    return Assembly.LoadFrom(fullPath);
                }
            }

            return null;
        }

        // EVENTS

        // open project button
        private void Btn_OpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSearch = new OpenFileDialog
            {
                Filter = "*.ap15|*.ap15",
                RestoreDirectory = true
            };
            fileSearch.ShowDialog();

            string ProjectPath = fileSearch.FileName.ToString();

            MyTiaPortal = BlockManagement.StartTIA(sender, e);

            if (string.IsNullOrEmpty(ProjectPath) == false)
            {
                MyProject = BlockManagement.OpenProject(ProjectPath, MyTiaPortal, statusBox);
            }
        }

        // close TIA Portal button
        // TODO remove, maybe it's not needed anymore?
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            MyTiaPortal.Dispose();
            statusBox.AppendText("TIA Portal disposed");
            statusBox.AppendText(Environment.NewLine);
        }

        // connect to existing project
        // and read project library and devices
        private void Btn_ConnectProject_Click(object sender, EventArgs e)
        {
            // Project connection
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            statusBox.AppendText("Attempting to connect..." + processes.Count + " processes found");
            statusBox.AppendText(Environment.NewLine);

            switch (processes.Count)
            {
                case 1:
                    _tiaProcess = processes[0];
                    MyTiaPortal = _tiaProcess.Attach();

                    if (MyTiaPortal.Projects.Count <= 0)
                    {
                        statusBox.AppendText("No TIA Portal Project was found!");
                        statusBox.AppendText(Environment.NewLine);
                        return;
                    }
                    statusBox.AppendText("Connected to running instance of TIA Portal");
                    statusBox.AppendText(Environment.NewLine);
                    MyProject = MyTiaPortal.Projects[0];
                    break;
                case 0:
                    statusBox.AppendText("No running instance of TIA Portal was found!");
                    statusBox.AppendText(Environment.NewLine);
                    return;
                default:
                    statusBox.AppendText("More than one running instance of TIA Portal was found!");
                    statusBox.AppendText(Environment.NewLine);
                    return;
            }

            // Read project Devices and add them to check list
            foreach (var device in MyProject.Devices)
            {
                if (device.TypeIdentifier != "System:Device.PC")
                    devicesCheckList.Items.Add(device.Name);
            }

            // Read project library
            Dictionary<string, MasterCopy> libMasterCopies = BlockManagement.ReadProjectLibrary(MyProject.ProjectLibrary.MasterCopyFolder, "");

            // Disable list box updating before adding new elements
            projectLibraryCheckList.BeginUpdate();

            // Add master copies from list to checked list
            //foreach (MasterCopy copy in libMasterCopies)
            foreach (KeyValuePair<string, MasterCopy> entry in libMasterCopies)
            {
                projectLibraryCheckList.Items.Add(entry.Key);
            }

            // Enable list box updating again
            projectLibraryCheckList.EndUpdate();
        }

        // Check items selected
        private void Btn_CopySelection_Click(object sender, EventArgs e)
        {
            // Determine if there are any devices checked.  
            if (devicesCheckList.CheckedItems.Count != 0)
            {
                statusBox.AppendText("Systems selected: " + devicesCheckList.CheckedItems.Count);
                statusBox.AppendText(Environment.NewLine);

                // If so loop through all devices checking if they have been selected
                foreach (var device in MyProject.Devices)
                {
                    if (devicesCheckList.CheckedItems.Contains(device.Name))
                    {
                        statusBox.AppendText("Applying changes to system " + device.Name);
                        statusBox.AppendText(Environment.NewLine);

                        foreach (var deviceItem in device.DeviceItems)
                        {
                            SoftwareContainer softwareContainer = ((IEngineeringServiceProvider)deviceItem).GetService<SoftwareContainer>();
                            if (softwareContainer != null)
                            {
                                PlcSoftware software = softwareContainer.Software as PlcSoftware;
                                MasterCopyFolder masterFolder = MyProject.ProjectLibrary.MasterCopyFolder;

                                // get blocks to be copied info
                                foreach (string item in projectLibraryCheckList.CheckedItems)
                                {
                                    string destFolder = item.Substring(0, item.IndexOf("/"));
                                    string blockToCopy = item.Substring(item.IndexOf("/") + 1);
                                    statusBox.AppendText("Copying " + blockToCopy + " to " + destFolder);
                                    statusBox.AppendText(Environment.NewLine);

                                    // Type of BlockGroup is PlcBlockSystemGroup is not compatible with type of
                                    // Group that is PlcBlockUserGroup so the same functions can't be applied 
                                    // in both cases, that's the reason for the exception when copying to the root folder
                                    if (destFolder.Equals("PLC"))
                                    {
                                        // delete block if already exists
                                        foreach (var block in software.BlockGroup.Blocks)
                                        {
                                            if (blockToCopy.Equals(block.Name))
                                                block.Delete();
                                        }
                                        // now copy block
                                        software.BlockGroup.Blocks.CreateFrom(BlockManagement.GetMasterCopy(masterFolder, blockToCopy, statusBox));
                                    }
                                    else
                                    {
                                        foreach (var group in software.BlockGroup.Groups)
                                        {
                                            BlockManagement.CopyToFolder(blockToCopy, masterFolder, group, destFolder, statusBox);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                statusBox.AppendText("No systems have been selected");
                statusBox.AppendText(Environment.NewLine);
            }
        }

        private void Btn_DeleteSelection_Click(object sender, EventArgs e)
        {

        }
    }
}