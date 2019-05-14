namespace CopyBlocks
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_OpenProject = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.devicesCheckList = new System.Windows.Forms.CheckedListBox();
            this.btn_ConnectProject = new System.Windows.Forms.Button();
            this.btn_ReadProject = new System.Windows.Forms.Button();
            this.btn_CheckSelection = new System.Windows.Forms.Button();
            this.projectLibraryCheckList = new System.Windows.Forms.CheckedListBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_OpenProject
            // 
            this.btn_OpenProject.Location = new System.Drawing.Point(12, 12);
            this.btn_OpenProject.Name = "btn_OpenProject";
            this.btn_OpenProject.Size = new System.Drawing.Size(113, 47);
            this.btn_OpenProject.TabIndex = 0;
            this.btn_OpenProject.Text = "Open Project";
            this.btn_OpenProject.UseVisualStyleBackColor = true;
            this.btn_OpenProject.Click += new System.EventHandler(this.btn_OpenProject_Click);
            // 
            // statusBox
            // 
            this.statusBox.Location = new System.Drawing.Point(12, 517);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(819, 45);
            this.statusBox.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(718, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(113, 47);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // devicesCheckList
            // 
            this.devicesCheckList.FormattingEnabled = true;
            this.devicesCheckList.Location = new System.Drawing.Point(289, 72);
            this.devicesCheckList.Name = "devicesCheckList";
            this.devicesCheckList.Size = new System.Drawing.Size(268, 439);
            this.devicesCheckList.TabIndex = 3;
            // 
            // btn_ConnectProject
            // 
            this.btn_ConnectProject.Location = new System.Drawing.Point(131, 12);
            this.btn_ConnectProject.Name = "btn_ConnectProject";
            this.btn_ConnectProject.Size = new System.Drawing.Size(113, 47);
            this.btn_ConnectProject.TabIndex = 4;
            this.btn_ConnectProject.Text = "Connect Project";
            this.btn_ConnectProject.UseVisualStyleBackColor = true;
            this.btn_ConnectProject.Click += new System.EventHandler(this.btn_ConnectProject_Click);
            // 
            // btn_ReadProject
            // 
            this.btn_ReadProject.Location = new System.Drawing.Point(250, 12);
            this.btn_ReadProject.Name = "btn_ReadProject";
            this.btn_ReadProject.Size = new System.Drawing.Size(113, 47);
            this.btn_ReadProject.TabIndex = 5;
            this.btn_ReadProject.Text = "Read Project";
            this.btn_ReadProject.UseVisualStyleBackColor = true;
            this.btn_ReadProject.Click += new System.EventHandler(this.btn_ReadProject_Click);
            // 
            // btn_CheckSelection
            // 
            this.btn_CheckSelection.Location = new System.Drawing.Point(369, 12);
            this.btn_CheckSelection.Name = "btn_CheckSelection";
            this.btn_CheckSelection.Size = new System.Drawing.Size(113, 47);
            this.btn_CheckSelection.TabIndex = 6;
            this.btn_CheckSelection.Text = "Check Selection";
            this.btn_CheckSelection.UseVisualStyleBackColor = true;
            this.btn_CheckSelection.Click += new System.EventHandler(this.btn_CheckSelection_Click);
            // 
            // projectLibraryCheckList
            // 
            this.projectLibraryCheckList.FormattingEnabled = true;
            this.projectLibraryCheckList.Location = new System.Drawing.Point(12, 72);
            this.projectLibraryCheckList.Name = "projectLibraryCheckList";
            this.projectLibraryCheckList.Size = new System.Drawing.Size(268, 439);
            this.projectLibraryCheckList.TabIndex = 8;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(564, 72);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(267, 439);
            this.resultsTextBox.TabIndex = 9;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 574);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.projectLibraryCheckList);
            this.Controls.Add(this.btn_CheckSelection);
            this.Controls.Add(this.btn_ReadProject);
            this.Controls.Add(this.btn_ConnectProject);
            this.Controls.Add(this.devicesCheckList);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.btn_OpenProject);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenProject;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.CheckedListBox devicesCheckList;
        private System.Windows.Forms.Button btn_ConnectProject;
        private System.Windows.Forms.Button btn_ReadProject;
        private System.Windows.Forms.Button btn_CheckSelection;
        private System.Windows.Forms.CheckedListBox projectLibraryCheckList;
        private System.Windows.Forms.TextBox resultsTextBox;
    }
}

