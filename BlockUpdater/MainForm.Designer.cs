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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_OpenProject = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_ConnectProject = new System.Windows.Forms.Button();
            this.btn_CheckSelection = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectAllBlocks = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectAllDevices = new System.Windows.Forms.Button();
            this.ProjectLibraryLabel = new System.Windows.Forms.Label();
            this.DevicesLabel = new System.Windows.Forms.Label();
            this.BlockLabel = new System.Windows.Forms.Label();
            this.projectLibraryCheckList = new System.Windows.Forms.CheckedListBox();
            this.blocksCheckList = new System.Windows.Forms.CheckedListBox();
            this.devicesCheckList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectNoneLibrary = new System.Windows.Forms.Button();
            this.btnSelectAllLibrary = new System.Windows.Forms.Button();
            this.btn_DeleteSelection = new System.Windows.Forms.Button();
            this.btnSelectNoneDevices = new System.Windows.Forms.Button();
            this.btnSelectNoneBlocks = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_OpenProject
            // 
            this.btn_OpenProject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.statusBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.Location = new System.Drawing.Point(3, 769);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(1014, 69);
            this.statusBox.TabIndex = 1;
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(918, 12);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(113, 47);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // btn_ConnectProject
            // 
            this.btn_ConnectProject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btn_CheckSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CheckSelection.Location = new System.Drawing.Point(250, 12);
            this.btn_CheckSelection.Name = "btn_CheckSelection";
            this.btn_CheckSelection.Size = new System.Drawing.Size(113, 47);
            this.btn_CheckSelection.TabIndex = 6;
            this.btn_CheckSelection.Text = "Copy Selection";
            this.btn_CheckSelection.UseVisualStyleBackColor = true;
            this.btn_CheckSelection.Click += new System.EventHandler(this.Btn_CopySelection_Click);
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
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.statusBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 72);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1020, 841);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel5, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel4, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.ProjectLibraryLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.DevicesLabel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.BlockLabel, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.projectLibraryCheckList, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.blocksCheckList, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.devicesCheckList, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1014, 760);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 2;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel5.Controls.Add(this.btnSelectNoneBlocks, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.btnSelectAllBlocks, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(677, 723);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(334, 34);
            this.tableLayoutPanel5.TabIndex = 26;
            // 
            // btnSelectAllBlocks
            // 
            this.btnSelectAllBlocks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllBlocks.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAllBlocks.Name = "btnSelectAllBlocks";
            this.btnSelectAllBlocks.Size = new System.Drawing.Size(82, 23);
            this.btnSelectAllBlocks.TabIndex = 23;
            this.btnSelectAllBlocks.Text = "Select All";
            this.btnSelectAllBlocks.UseVisualStyleBackColor = true;
            this.btnSelectAllBlocks.Click += new System.EventHandler(this.BtnSelectAllBlocks_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel4.Controls.Add(this.btnSelectNoneDevices, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnSelectAllDevices, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(340, 723);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(331, 34);
            this.tableLayoutPanel4.TabIndex = 25;
            // 
            // btnSelectAllDevices
            // 
            this.btnSelectAllDevices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllDevices.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAllDevices.Name = "btnSelectAllDevices";
            this.btnSelectAllDevices.Size = new System.Drawing.Size(82, 23);
            this.btnSelectAllDevices.TabIndex = 22;
            this.btnSelectAllDevices.Text = "Select All";
            this.btnSelectAllDevices.UseVisualStyleBackColor = true;
            this.btnSelectAllDevices.Click += new System.EventHandler(this.BtnSelectAllDevices_Click);
            // 
            // ProjectLibraryLabel
            // 
            this.ProjectLibraryLabel.AutoSize = true;
            this.ProjectLibraryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLibraryLabel.Location = new System.Drawing.Point(3, 0);
            this.ProjectLibraryLabel.Name = "ProjectLibraryLabel";
            this.ProjectLibraryLabel.Size = new System.Drawing.Size(92, 17);
            this.ProjectLibraryLabel.TabIndex = 13;
            this.ProjectLibraryLabel.Text = "Project Library";
            // 
            // DevicesLabel
            // 
            this.DevicesLabel.AutoSize = true;
            this.DevicesLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevicesLabel.Location = new System.Drawing.Point(340, 0);
            this.DevicesLabel.Name = "DevicesLabel";
            this.DevicesLabel.Size = new System.Drawing.Size(96, 17);
            this.DevicesLabel.TabIndex = 14;
            this.DevicesLabel.Text = "Project Devices";
            // 
            // BlockLabel
            // 
            this.BlockLabel.AutoSize = true;
            this.BlockLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlockLabel.Location = new System.Drawing.Point(677, 0);
            this.BlockLabel.Name = "BlockLabel";
            this.BlockLabel.Size = new System.Drawing.Size(113, 17);
            this.BlockLabel.TabIndex = 15;
            this.BlockLabel.Text = "Project PLC Blocks";
            // 
            // projectLibraryCheckList
            // 
            this.projectLibraryCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectLibraryCheckList.CheckOnClick = true;
            this.projectLibraryCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectLibraryCheckList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projectLibraryCheckList.FormattingEnabled = true;
            this.projectLibraryCheckList.Location = new System.Drawing.Point(3, 23);
            this.projectLibraryCheckList.Name = "projectLibraryCheckList";
            this.projectLibraryCheckList.Size = new System.Drawing.Size(331, 694);
            this.projectLibraryCheckList.TabIndex = 18;
            // 
            // blocksCheckList
            // 
            this.blocksCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blocksCheckList.CheckOnClick = true;
            this.blocksCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blocksCheckList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blocksCheckList.FormattingEnabled = true;
            this.blocksCheckList.Location = new System.Drawing.Point(677, 23);
            this.blocksCheckList.Name = "blocksCheckList";
            this.blocksCheckList.Size = new System.Drawing.Size(334, 694);
            this.blocksCheckList.Sorted = true;
            this.blocksCheckList.TabIndex = 19;
            // 
            // devicesCheckList
            // 
            this.devicesCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devicesCheckList.CheckOnClick = true;
            this.devicesCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devicesCheckList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devicesCheckList.FormattingEnabled = true;
            this.devicesCheckList.Location = new System.Drawing.Point(340, 23);
            this.devicesCheckList.Name = "devicesCheckList";
            this.devicesCheckList.Size = new System.Drawing.Size(331, 694);
            this.devicesCheckList.Sorted = true;
            this.devicesCheckList.TabIndex = 20;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.btnSelectNoneLibrary, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSelectAllLibrary, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 723);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(331, 34);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // btnSelectNoneLibrary
            // 
            this.btnSelectNoneLibrary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNoneLibrary.Location = new System.Drawing.Point(102, 3);
            this.btnSelectNoneLibrary.Name = "btnSelectNoneLibrary";
            this.btnSelectNoneLibrary.Size = new System.Drawing.Size(82, 23);
            this.btnSelectNoneLibrary.TabIndex = 22;
            this.btnSelectNoneLibrary.Text = "Select None";
            this.btnSelectNoneLibrary.UseVisualStyleBackColor = true;
            this.btnSelectNoneLibrary.Click += new System.EventHandler(this.BtnSelectNoneLibrary_Click);
            // 
            // btnSelectAllLibrary
            // 
            this.btnSelectAllLibrary.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllLibrary.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAllLibrary.Name = "btnSelectAllLibrary";
            this.btnSelectAllLibrary.Size = new System.Drawing.Size(82, 23);
            this.btnSelectAllLibrary.TabIndex = 21;
            this.btnSelectAllLibrary.Text = "Select All";
            this.btnSelectAllLibrary.UseVisualStyleBackColor = true;
            this.btnSelectAllLibrary.Click += new System.EventHandler(this.BtnSelectAllLibrary_Click);
            // 
            // btn_DeleteSelection
            // 
            this.btn_DeleteSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DeleteSelection.Location = new System.Drawing.Point(369, 12);
            this.btn_DeleteSelection.Name = "btn_DeleteSelection";
            this.btn_DeleteSelection.Size = new System.Drawing.Size(113, 47);
            this.btn_DeleteSelection.TabIndex = 13;
            this.btn_DeleteSelection.Text = "Delete Selection";
            this.btn_DeleteSelection.UseVisualStyleBackColor = true;
            this.btn_DeleteSelection.Click += new System.EventHandler(this.Btn_DeleteSelection_Click);
            // 
            // btnSelectNoneDevices
            // 
            this.btnSelectNoneDevices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNoneDevices.Location = new System.Drawing.Point(102, 3);
            this.btnSelectNoneDevices.Name = "btnSelectNoneDevices";
            this.btnSelectNoneDevices.Size = new System.Drawing.Size(82, 23);
            this.btnSelectNoneDevices.TabIndex = 23;
            this.btnSelectNoneDevices.Text = "Select None";
            this.btnSelectNoneDevices.UseVisualStyleBackColor = true;
            this.btnSelectNoneDevices.Click += new System.EventHandler(this.BtnSelectNoneDevices_Click);
            // 
            // btnSelectNoneBlocks
            // 
            this.btnSelectNoneBlocks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNoneBlocks.Location = new System.Drawing.Point(103, 3);
            this.btnSelectNoneBlocks.Name = "btnSelectNoneBlocks";
            this.btnSelectNoneBlocks.Size = new System.Drawing.Size(82, 23);
            this.btnSelectNoneBlocks.TabIndex = 24;
            this.btnSelectNoneBlocks.Text = "Select None";
            this.btnSelectNoneBlocks.UseVisualStyleBackColor = true;
            this.btnSelectNoneBlocks.Click += new System.EventHandler(this.BtnSelectNoneBlocks_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1045, 926);
            this.Controls.Add(this.btn_DeleteSelection);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_CheckSelection);
            this.Controls.Add(this.btn_ConnectProject);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_OpenProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "TIA Portal Block Updater";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenProject;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_ConnectProject;
        private System.Windows.Forms.Button btn_CheckSelection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_DeleteSelection;
        private System.Windows.Forms.Label ProjectLibraryLabel;
        private System.Windows.Forms.Label DevicesLabel;
        private System.Windows.Forms.Label BlockLabel;
        private System.Windows.Forms.CheckedListBox projectLibraryCheckList;
        private System.Windows.Forms.CheckedListBox blocksCheckList;
        private System.Windows.Forms.CheckedListBox devicesCheckList;
        private System.Windows.Forms.Button btnSelectAllBlocks;
        private System.Windows.Forms.Button btnSelectAllDevices;
        private System.Windows.Forms.Button btnSelectAllLibrary;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSelectNoneLibrary;
        private System.Windows.Forms.Button btnSelectNoneBlocks;
        private System.Windows.Forms.Button btnSelectNoneDevices;
    }
}

