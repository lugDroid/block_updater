namespace CopyBlocks
{
    partial class DeleteBlocksForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteBlocksForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.blocksCheckList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectNoneDevices = new System.Windows.Forms.Button();
            this.btnSelectAllDevices = new System.Windows.Forms.Button();
            this.ProjectLibraryLabel = new System.Windows.Forms.Label();
            this.DevicesLabel = new System.Windows.Forms.Label();
            this.devicesCheckList = new System.Windows.Forms.CheckedListBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectNoneBlocks = new System.Windows.Forms.Button();
            this.btnSelectAllBlocks = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.blocksCheckList, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.ProjectLibraryLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.DevicesLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.devicesCheckList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.186275F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 96.81373F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(960, 781);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // blocksCheckList
            // 
            this.blocksCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blocksCheckList.CheckOnClick = true;
            this.blocksCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blocksCheckList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blocksCheckList.FormattingEnabled = true;
            this.blocksCheckList.Location = new System.Drawing.Point(3, 26);
            this.blocksCheckList.Name = "blocksCheckList";
            this.blocksCheckList.Size = new System.Drawing.Size(474, 703);
            this.blocksCheckList.Sorted = true;
            this.blocksCheckList.TabIndex = 27;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel3.Controls.Add(this.btnSelectNoneDevices, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnSelectAllDevices, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(483, 735);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(474, 43);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // btnSelectNoneDevices
            // 
            this.btnSelectNoneDevices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNoneDevices.Location = new System.Drawing.Point(145, 3);
            this.btnSelectNoneDevices.Name = "btnSelectNoneDevices";
            this.btnSelectNoneDevices.Size = new System.Drawing.Size(82, 22);
            this.btnSelectNoneDevices.TabIndex = 25;
            this.btnSelectNoneDevices.Text = "Select None";
            this.btnSelectNoneDevices.UseVisualStyleBackColor = true;
            this.btnSelectNoneDevices.Click += new System.EventHandler(this.BtnSelectNoneDevices_Click);
            // 
            // btnSelectAllDevices
            // 
            this.btnSelectAllDevices.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllDevices.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAllDevices.Name = "btnSelectAllDevices";
            this.btnSelectAllDevices.Size = new System.Drawing.Size(82, 22);
            this.btnSelectAllDevices.TabIndex = 24;
            this.btnSelectAllDevices.Text = "Select All";
            this.btnSelectAllDevices.UseVisualStyleBackColor = true;
            this.btnSelectAllDevices.Click += new System.EventHandler(this.BtnSelectAllDevices_Click);
            // 
            // ProjectLibraryLabel
            // 
            this.ProjectLibraryLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ProjectLibraryLabel.AutoSize = true;
            this.ProjectLibraryLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLibraryLabel.Location = new System.Drawing.Point(3, 3);
            this.ProjectLibraryLabel.Name = "ProjectLibraryLabel";
            this.ProjectLibraryLabel.Size = new System.Drawing.Size(69, 17);
            this.ProjectLibraryLabel.TabIndex = 15;
            this.ProjectLibraryLabel.Text = "PLC Blocks";
            // 
            // DevicesLabel
            // 
            this.DevicesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DevicesLabel.AutoSize = true;
            this.DevicesLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DevicesLabel.Location = new System.Drawing.Point(483, 3);
            this.DevicesLabel.Name = "DevicesLabel";
            this.DevicesLabel.Size = new System.Drawing.Size(96, 17);
            this.DevicesLabel.TabIndex = 16;
            this.DevicesLabel.Text = "Project Devices";
            // 
            // devicesCheckList
            // 
            this.devicesCheckList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.devicesCheckList.CheckOnClick = true;
            this.devicesCheckList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.devicesCheckList.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.devicesCheckList.FormattingEnabled = true;
            this.devicesCheckList.Location = new System.Drawing.Point(483, 26);
            this.devicesCheckList.Name = "devicesCheckList";
            this.devicesCheckList.Size = new System.Drawing.Size(474, 703);
            this.devicesCheckList.Sorted = true;
            this.devicesCheckList.TabIndex = 22;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.btnSelectNoneBlocks, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnSelectAllBlocks, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 735);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(474, 43);
            this.tableLayoutPanel2.TabIndex = 23;
            // 
            // btnSelectNoneBlocks
            // 
            this.btnSelectNoneBlocks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectNoneBlocks.Location = new System.Drawing.Point(145, 3);
            this.btnSelectNoneBlocks.Name = "btnSelectNoneBlocks";
            this.btnSelectNoneBlocks.Size = new System.Drawing.Size(82, 22);
            this.btnSelectNoneBlocks.TabIndex = 24;
            this.btnSelectNoneBlocks.Text = "Select None";
            this.btnSelectNoneBlocks.UseVisualStyleBackColor = true;
            this.btnSelectNoneBlocks.Click += new System.EventHandler(this.BtnSelectNoneBlocks_Click);
            // 
            // btnSelectAllBlocks
            // 
            this.btnSelectAllBlocks.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAllBlocks.Location = new System.Drawing.Point(3, 3);
            this.btnSelectAllBlocks.Name = "btnSelectAllBlocks";
            this.btnSelectAllBlocks.Size = new System.Drawing.Size(82, 22);
            this.btnSelectAllBlocks.TabIndex = 23;
            this.btnSelectAllBlocks.Text = "Select All";
            this.btnSelectAllBlocks.UseVisualStyleBackColor = true;
            this.btnSelectAllBlocks.Click += new System.EventHandler(this.BtnSelectAllBlocks_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(15, 817);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 36);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(869, 817);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 36);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Blocks";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // DeleteBlocksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 861);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteBlocksForm";
            this.ShowInTaskbar = false;
            this.Text = "Delete Blocks";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btnSelectNoneDevices;
        private System.Windows.Forms.Button btnSelectAllDevices;
        private System.Windows.Forms.Label ProjectLibraryLabel;
        private System.Windows.Forms.Label DevicesLabel;
        private System.Windows.Forms.CheckedListBox devicesCheckList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnSelectNoneBlocks;
        private System.Windows.Forms.Button btnSelectAllBlocks;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckedListBox blocksCheckList;
    }
}