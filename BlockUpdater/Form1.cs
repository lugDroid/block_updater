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
                deviceList.Add(device.Name.ToString());   
            }

            deviceList.Sort();

            foreach (var device in deviceList)
            {
                devicesCheckList.Items.Add(device);
            }

            // Read project library
            //List<MasterCopy> libMasterCopies = this.ReadProjectLibrary(MyProject.ProjectLibrary.MasterCopyFolder);
            Dictionary<string, MasterCopy> libMasterCopies = this.ReadProjectLibrary(MyProject.ProjectLibrary.MasterCopyFolder, "");

            // Disable list box updating before adding new elements
            projectLibraryCheckList.BeginUpdate();

            // Add master copies from list to checked list
            //foreach (MasterCopy copy in libMasterCopies)
            foreach(KeyValuePair<string, MasterCopy> entry in libMasterCopies)
            {
                projectLibraryCheckList.Items.Add(entry.Key);
            }

            // Enable list box updating again
            projectLibraryCheckList.EndUpdate();
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

                                string pathToFind = "/DB/Analogues";
                                string[] pathArray = pathToFind.Split('/');

                                int i = 0;

                                do
                                {
                                    if (software.BlockGroup.Groups.Contains(pathArray[i]))
                                    {

                                    }
                                    i++;
                                } while (i < pathArray.Length);

                                string str = "";

                                foreach (var group in software.BlockGroup.Groups)
                                {
                                    str = str + group.Name.ToString() + Environment.NewLine;
                                    foreach (var block in group.Blocks)
                                    {
                                        str = str + group.Name.ToString() + " - " + block.Name.ToString() + Environment.NewLine;
                                    }
                                }


                                // iterate over project library items and check if they have been selected
                                // comparing against checked list
                                //foreach (var masterCopy in )

                                //foreach (string blockPath in projectLibraryCheckList.CheckedItems)

                                // copy selected blocks from project library
                                //foreach (var softwareBlock in projectLibrarySelected)
                                //{
                                //    software.BlockGroup.Blocks.CreateFrom(softwareBlock);
                                //}


                                resultsTextBox.Text = str;
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
