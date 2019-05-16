using Microsoft.Win32;
using Siemens.Engineering;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.SW;
using Siemens.Engineering.SW.Blocks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
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

        // FUNCTIONS
        private void StartTIA(object sender, EventArgs e)
        {
            MyTiaPortal = new TiaPortal(TiaPortalMode.WithoutUserInterface);
        }

        // open existing TIA Portal project
        private void OpenProject(string ProjectPath)
        {
            try
            {
                MyProject = MyTiaPortal.Projects.Open(new FileInfo(ProjectPath));
                statusBox.Text = "Project " + ProjectPath + " opened";
            }
            catch (Exception ex)
            {
                statusBox.Text = "Error while opening project: " + ProjectPath + " - " + ex.Message;
            }
        }

        // read project library master copies folder and returns list
        private Dictionary<string, MasterCopy> ReadProjectLibrary(MasterCopyFolder mCopiesFolder, string path)
        {
            // check we have some master copies folder to work with
            if (mCopiesFolder == null)
                throw new ArgumentNullException(nameof(mCopiesFolder), "Parameter is null");

            var masterCopies = new Dictionary<string, MasterCopy>();

            // Add new elements to list
            foreach (var mCopy in mCopiesFolder.MasterCopies)
            {
                path = mCopiesFolder.Name + "/" + mCopy.Name;
                masterCopies.Add(path, mCopy);
            }

            // Check for elements in subfolders and add them to the list too
            foreach (var subfolder in mCopiesFolder.Folders)
            {
                masterCopies = masterCopies.Concat(ReadProjectLibrary(subfolder, mCopiesFolder.Name + "/"))
                    .ToLookup(x => x.Key, x => x.Value)
                    .ToDictionary(x => x.Key, g => g.First());
                //masterCopies.AddRange(ReadProjectLibrary(subfolder, path));
            }

            return masterCopies;
        }

        // search project library for the block required and returns it
        private MasterCopy GetMasterCopy(MasterCopyFolder libraryFolder,string blockName)
        {
            // look for block in current folder
            foreach (var masterCopy in libraryFolder.MasterCopies)
            {
                if (masterCopy.Name.Equals(blockName))
                {
                    Console.WriteLine("Block to be copied found in " + libraryFolder.Name);
                    return masterCopy;
                }
            }

            // if not in this folder check subfolders
            foreach (var subfolder in libraryFolder.Folders)
            {
                MasterCopy result = GetMasterCopy(subfolder, blockName);

                if (result != null)
                    return result;
            }

            Console.WriteLine("Block to be copied not found");
            return null;
        }

        // copy block from provided project library to folder in provided plc software object
        // returns true if copied, false otherwise
        private bool CopyToFolder(string blockName, MasterCopyFolder libraryFolder, PlcBlockUserGroup software, string destFolder)
        {
            // if not in the right folder and there are no more subfolders return
            //if (software.Groups.Count == 0 && !software.Name.Equals(destFolder))
            //{
            //    Console.WriteLine("No more subfolders in " + software.Name);
            //    return false;
            //}

            // checks if it's already on the right folder to proceed with the copy
            if (software.Name.Equals(destFolder))
            {
                Console.WriteLine("Destination folder found");
                software.Blocks.CreateFrom(GetMasterCopy(libraryFolder, blockName));
                return true;
            }

            // if it's not in the right folder, recursively check subfolders
            foreach (var group in software.Groups)
            {
                Console.WriteLine("Checking " + software.Name + " subfolders");
                if (CopyToFolder(blockName, libraryFolder, group, destFolder))
                    return true;
            }

            Console.WriteLine("Destination folder not found");
            return false;
        }

        // BUTTON EVENTS

        // open project button
        private void btn_OpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSearch = new OpenFileDialog();

            fileSearch.Filter = "*.ap15|*.ap15";
            fileSearch.RestoreDirectory = true;
            fileSearch.ShowDialog();

            string ProjectPath = fileSearch.FileName.ToString();

            this.StartTIA(sender, e);

            if (string.IsNullOrEmpty(ProjectPath) == false)
            {
                OpenProject(ProjectPath);
            }
        }

        // close TIA Portal button
        private void btn_Close_Click(object sender, EventArgs e)
        {
            MyTiaPortal.Dispose();
            statusBox.Text = "TIA Portal disposed";
        }

        // connect to existing project
        // and read project library and devices
        private void btn_ConnectProject_Click(object sender, EventArgs e)
        {
            // Projec connection
            // TODO refactor into function
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            statusBox.AppendText("Attempting to connect..." + processes.Count + " processes found");

            switch (processes.Count)
            {
                case 1:
                    _tiaProcess = processes[0];
                    MyTiaPortal = _tiaProcess.Attach();

                    if (MyTiaPortal.Projects.Count <= 0)
                    {
                        statusBox.Text = "No TIA Portal Project was found!";
                        return;
                    }
                    statusBox.Text = "Connected to running instance of TIA Portal";
                    MyProject = MyTiaPortal.Projects[0];
                    break;
                case 0:
                    statusBox.Text = "No running instance of TIA Portal was found!";
                    return;
                default:
                    statusBox.Text = "More than one running instance of TIA Portal was found!";
                    return;
            }

            // Read project Devices and add them to check list
            // TODO Refactor into function
            ArrayList deviceList = new ArrayList();

            foreach (var device in MyProject.Devices)
            {
                deviceList.Add(device.Name.ToString());
            }

            deviceList.Sort();

            foreach (var device in deviceList)
            {
                devicesCheckList.Items.Add(device);
            }

            // Read project library
            Dictionary<string, MasterCopy> libMasterCopies = this.ReadProjectLibrary(MyProject.ProjectLibrary.MasterCopyFolder, "");

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


        private void btn_ReadProject_Click(object sender, EventArgs e)
        {
            
        }

        // Check items selected
        // TODO check project library items
        private void btn_CheckSelection_Click(object sender, EventArgs e)
        {
            // Determine if there are any devices checked.  
            if (devicesCheckList.CheckedItems.Count != 0)
            {
                statusBox.AppendText(Environment.NewLine + "Systems selected: " + devicesCheckList.CheckedItems.Count);

                // If so loop through all devices checking if they have been selected
                foreach (var device in MyProject.Devices)
                {
                    if (devicesCheckList.CheckedItems.Contains(device.Name))
                    {
                        statusBox.AppendText(Environment.NewLine + "Applying changes to system " + device.Name);

                        foreach (var deviceItem in device.DeviceItems)
                        {
                            SoftwareContainer softwareContainer = ((IEngineeringServiceProvider)deviceItem).GetService<SoftwareContainer>();
                            if (softwareContainer != null)
                            {
                                PlcSoftware software = softwareContainer.Software as PlcSoftware;
                                MasterCopyFolder masterFolder = MyProject.ProjectLibrary.MasterCopyFolder;

                                string blockToCopy = "XV30_DB";
                                string destFolder = "OB";

                                // if destination folder is root folder just copy the block
                                // otherwise call recursive function
                                if (destFolder.Equals("root"))
                                {
                                    software.BlockGroup.Blocks.CreateFrom(GetMasterCopy(masterFolder, blockToCopy));
                                }
                                else
                                {
                                    foreach (var group in software.BlockGroup.Groups)
                                    {
                                        CopyToFolder(blockToCopy, masterFolder, group, destFolder);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
