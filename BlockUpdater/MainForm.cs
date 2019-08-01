using Microsoft.Win32;
using Siemens.Engineering;
using System;
using System.Collections.Generic;
using System.IO;
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

        // Constructor
        public MainForm()
        {
            InitializeComponent();
            AppDomain CurrentDomain = AppDomain.CurrentDomain;
            CurrentDomain.AssemblyResolve += new ResolveEventHandler(MyResolver);
            Globals.log = statusBox;
        }

        // Resolver
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

        // Open project button
        private void Btn_OpenProject_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileSearch = new OpenFileDialog
            {
                Filter = " Tia Portal v15|*.ap15| Tia Portal v14|*.ap14",
                RestoreDirectory = true
            };
            fileSearch.ShowDialog();

            string ProjectPath = fileSearch.FileName.ToString();

            if (string.IsNullOrEmpty(ProjectPath) == false)
            {
                MyTiaPortal = BlockManagement.StartTIA(sender, e);
                MyProject = BlockManagement.OpenProject(ProjectPath, MyTiaPortal);

                btnCheckSelection.Enabled = true;
                btnDeleteSelection.Enabled = true;
                btnCompile.Enabled = true;
            } 
        }

        // Close button
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            if (MyTiaPortal != null)
            {
                MyTiaPortal.Dispose();
                Globals.Log("TIA Portal disposed");
            }
            System.Windows.Forms.Application.Exit();
        }

        // Connect to existing project button
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

                    btnCheckSelection.Enabled = true;
                    btnDeleteSelection.Enabled = true;
                    btnCompile.Enabled = true;

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
        }

        // Show copy blocks form
        private void Btn_CopySelection_Click(object sender, EventArgs e)
        {
            var copyBlocksForm = new CopyBlocksForm(MyProject);
            copyBlocksForm.ShowDialog();
        }

        // Show delete blocks form
        private void Btn_DeleteSelection_Click(object sender, EventArgs e)
        {
            var deleteBlocksForm = new DeleteBlocksForm(MyProject);
            deleteBlocksForm.ShowDialog();
        }

        // Show compile form
        private void BtnCompile_Click(object sender, EventArgs e)
        {
            var compileForm = new CompileForm(MyProject);
            compileForm.ShowDialog();
        }

        // Verbose output selection
        private void CheckBoxVerbose_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxVerbose.Checked)
            {
                Globals.verbose = true;
                statusBox.AppendText("Debug mode activated");
                statusBox.AppendText(Environment.NewLine);
            }
            else
            {
                Globals.verbose = false;
                statusBox.AppendText("Debug mode deactivated");
                statusBox.AppendText(Environment.NewLine);
            }
        }
    }
}
