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
            this.components = new System.ComponentModel.Container();
            this.btn_OpenProject = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.devicesCheckList = new System.Windows.Forms.CheckedListBox();
            this.btn_ConnectProject = new System.Windows.Forms.Button();
            this.btn_CheckSelection = new System.Windows.Forms.Button();
            this.projectLibraryCheckList = new System.Windows.Forms.CheckedListBox();
            this.resultsTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
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
            this.btn_OpenProject.Click += new System.EventHandler(this.Btn_OpenProject_Click);
            // 
            // statusBox
            // 
            this.statusBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.statusBox.Location = new System.Drawing.Point(3, 559);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(916, 93);
            this.statusBox.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Location = new System.Drawing.Point(820, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(113, 47);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // devicesCheckList
            // 
            this.devicesCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.devicesCheckList.FormattingEnabled = true;
            this.devicesCheckList.Location = new System.Drawing.Point(293, 3);
            this.devicesCheckList.Name = "devicesCheckList";
            this.devicesCheckList.Size = new System.Drawing.Size(310, 544);
            this.devicesCheckList.Sorted = true;
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
            this.btn_ConnectProject.Click += new System.EventHandler(this.Btn_ConnectProject_Click);
            // 
            // btn_CheckSelection
            // 
            this.btn_CheckSelection.Location = new System.Drawing.Point(369, 12);
            this.btn_CheckSelection.Name = "btn_CheckSelection";
            this.btn_CheckSelection.Size = new System.Drawing.Size(113, 47);
            this.btn_CheckSelection.TabIndex = 6;
            this.btn_CheckSelection.Text = "Copy Selection";
            this.btn_CheckSelection.UseVisualStyleBackColor = true;
            this.btn_CheckSelection.Click += new System.EventHandler(this.Btn_CheckSelection_Click);
            // 
            // projectLibraryCheckList
            // 
            this.projectLibraryCheckList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectLibraryCheckList.FormattingEnabled = true;
            this.projectLibraryCheckList.Location = new System.Drawing.Point(3, 3);
            this.projectLibraryCheckList.Name = "projectLibraryCheckList";
            this.projectLibraryCheckList.Size = new System.Drawing.Size(284, 544);
            this.projectLibraryCheckList.TabIndex = 8;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsTextBox.Location = new System.Drawing.Point(609, 3);
            this.resultsTextBox.Multiline = true;
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.ReadOnly = true;
            this.resultsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.resultsTextBox.Size = new System.Drawing.Size(304, 544);
            this.resultsTextBox.TabIndex = 9;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.8855F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.1145F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(922, 655);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.86184F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.13816F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 309F));
            this.tableLayoutPanel2.Controls.Add(this.projectLibraryCheckList, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.devicesCheckList, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.resultsTextBox, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(916, 550);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 740);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_CheckSelection);
            this.Controls.Add(this.btn_ConnectProject);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OpenProject);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenProject;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.CheckedListBox devicesCheckList;
        private System.Windows.Forms.Button btn_ConnectProject;
        private System.Windows.Forms.Button btn_CheckSelection;
        private System.Windows.Forms.CheckedListBox projectLibraryCheckList;
        private System.Windows.Forms.TextBox resultsTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

