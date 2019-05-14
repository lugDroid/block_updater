using Microsoft.Win32;
using Siemens.Engineering;
using Siemens.Engineering.HW.Features;
using Siemens.Engineering.Library;
using Siemens.Engineering.Library.MasterCopies;
using Siemens.Engineering.Library.Types;
using Siemens.Engineering.SW;
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

        // read project library master copies folder and adds all elements to given list box
        private void readProjectLibrary(CheckedListBox projectListBox, MasterCopyFolder mCopiesFolder, string path)
        {
            if (mCopiesFolder == null)
                throw new ArgumentNullException(nameof(mCopiesFolder), "Parameter is null");

            // Disable list box updating before adding new elements
            projectListBox.BeginUpdate();

            // Add new elements
            path = path + mCopiesFolder.Name + "/";

            foreach (var mCopy in mCopiesFolder.MasterCopies)
            {
                projectListBox.Items.Add(path + mCopy.Name);
            }

            foreach (var subfolder in mCopiesFolder.Folders)
            {
                this.readProjectLibrary(projectListBox, subfolder, path);
            }

            // Enable list box updating again
            projectListBox.EndUpdate();
        }

        // BUTTON EVENTS
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

        private void btn_Close_Click(object sender, EventArgs e)
        {
            MyTiaPortal.Dispose();
            statusBox.Text = "TIA Portal disposed";
        }

        // connect to existing project
        private void btn_ConnectProject_Click(object sender, EventArgs e)
        {
            
            IList<TiaPortalProcess> processes = TiaPortal.GetProcesses();
            statusBox.Text = "Attempting to connect..." + processes.Count + " processes found";

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
        }

        // Read project and display devices and library items on check lists
        private void btn_ReadProject_Click(object sender, EventArgs e)
        {
            // Read project Devices and add them to check list
            ArrayList deviceList = new ArrayList();

            foreach (var device in MyProject.Devices)
            {
                deviceList.Add(device.TypeIdentifier + " - " + device.Name.ToString());   
            }

            deviceList.Sort();

            foreach (var device in deviceList)
            {
                devicesCheckList.Items.Add(device);
            }

            // Read project library
            this.readProjectLibrary(projectLibraryCheckList, MyProject.ProjectLibrary.MasterCopyFolder, "");
        }

        // Check items selected
        // TODO check project library items
        private void btn_CheckSelection_Click(object sender, EventArgs e)
        {
            // Determine if there are any devices checked.  
            if (devicesCheckList.CheckedItems.Count != 0)
            {
                // If so loop through all devices checking if they have been selected
                foreach (var device in MyProject.Devices)
                {
                    if (devicesCheckList.CheckedItems.Contains(device.Name))
                    {
                        foreach (var deviceItem in device.DeviceItems)
                        {
                            SoftwareContainer softwareContainer = ((IEngineeringServiceProvider)deviceItem).GetService<SoftwareContainer>();
                            if (softwareContainer != null)
                            {
                                PlcSoftware software = softwareContainer.Software as PlcSoftware;

                                // iterate over project library items and check if they have been selected
                                // comparing against checked list
                                //foreach (var masterCopy in )

                                //foreach (string blockPath in projectLibraryCheckList.CheckedItems)

                                // copy selected blocks from project library
                                //foreach (var softwareBlock in projectLibrarySelected)
                                //{
                                //    software.BlockGroup.Blocks.CreateFrom(softwareBlock);
                                //}
                                

                                //string str = "";
                                
                                //foreach (var group in software.BlockGroup.Groups)
                                //{
                                    //str = str + group.Name.ToString() + Environment.NewLine;
                                    //foreach (var block in group.Blocks)
                                    //{
                                    //    str = str + group.Name.ToString() + " - " + block.Name.ToString() + Environment.NewLine;
                                    //}
                                //}

                                //resultsTextBox.Text = str;
                            }
                        }
                    }
                    
                }
                // If so, loop through all checked items and print results.  
                //string s = "";
                //for (int x = 0; x < devicesCheckList.CheckedItems.Count; x++)
                //{
                //    s = s + "Checked Item " + (x + 1).ToString() + " = " + devicesCheckList.CheckedItems[x].ToString() + "\n";
                //}
                //MessageBox.Show(s);
            }

            
        }
    }
}
