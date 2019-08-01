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
            this.btnOpenProject = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btnConnectProject = new System.Windows.Forms.Button();
            this.btnCheckSelection = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnDeleteSelection = new System.Windows.Forms.Button();
            this.btnCompile = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.checkBoxVerbose = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnOpenProject
            // 
            this.btnOpenProject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnOpenProject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenProject.Location = new System.Drawing.Point(123, 67);
            this.btnOpenProject.Name = "btnOpenProject";
            this.btnOpenProject.Size = new System.Drawing.Size(130, 45);
            this.btnOpenProject.TabIndex = 0;
            this.btnOpenProject.Text = "Open Project";
            this.btnOpenProject.UseVisualStyleBackColor = true;
            this.btnOpenProject.Click += new System.EventHandler(this.Btn_OpenProject_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.Location = new System.Drawing.Point(123, 356);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(130, 45);
            this.btn_Close.TabIndex = 2;
            this.btn_Close.Text = "Close";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.Btn_Close_Click);
            // 
            // btnConnectProject
            // 
            this.btnConnectProject.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnConnectProject.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectProject.Location = new System.Drawing.Point(123, 118);
            this.btnConnectProject.Name = "btnConnectProject";
            this.btnConnectProject.Size = new System.Drawing.Size(130, 45);
            this.btnConnectProject.TabIndex = 4;
            this.btnConnectProject.Text = "Connect Project";
            this.btnConnectProject.UseVisualStyleBackColor = true;
            this.btnConnectProject.Click += new System.EventHandler(this.Btn_ConnectProject_Click);
            // 
            // btnCheckSelection
            // 
            this.btnCheckSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckSelection.Enabled = false;
            this.btnCheckSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckSelection.Location = new System.Drawing.Point(123, 169);
            this.btnCheckSelection.Name = "btnCheckSelection";
            this.btnCheckSelection.Size = new System.Drawing.Size(130, 45);
            this.btnCheckSelection.TabIndex = 6;
            this.btnCheckSelection.Text = "Copy Blocks";
            this.btnCheckSelection.UseVisualStyleBackColor = true;
            this.btnCheckSelection.Click += new System.EventHandler(this.Btn_CopySelection_Click);
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
            // btnDeleteSelection
            // 
            this.btnDeleteSelection.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDeleteSelection.Enabled = false;
            this.btnDeleteSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelection.Location = new System.Drawing.Point(123, 220);
            this.btnDeleteSelection.Name = "btnDeleteSelection";
            this.btnDeleteSelection.Size = new System.Drawing.Size(130, 45);
            this.btnDeleteSelection.TabIndex = 13;
            this.btnDeleteSelection.Text = "Delete Blocks";
            this.btnDeleteSelection.UseVisualStyleBackColor = true;
            this.btnDeleteSelection.Click += new System.EventHandler(this.Btn_DeleteSelection_Click);
            // 
            // btnCompile
            // 
            this.btnCompile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCompile.Enabled = false;
            this.btnCompile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompile.Location = new System.Drawing.Point(123, 271);
            this.btnCompile.Name = "btnCompile";
            this.btnCompile.Size = new System.Drawing.Size(130, 45);
            this.btnCompile.TabIndex = 14;
            this.btnCompile.Text = "Compile PLC";
            this.btnCompile.UseVisualStyleBackColor = true;
            this.btnCompile.Click += new System.EventHandler(this.BtnCompile_Click);
            // 
            // statusBox
            // 
            this.statusBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBox.Location = new System.Drawing.Point(0, 451);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.statusBox.Size = new System.Drawing.Size(383, 172);
            this.statusBox.TabIndex = 15;
            // 
            // checkBoxVerbose
            // 
            this.checkBoxVerbose.AutoSize = true;
            this.checkBoxVerbose.Location = new System.Drawing.Point(12, 428);
            this.checkBoxVerbose.Name = "checkBoxVerbose";
            this.checkBoxVerbose.Size = new System.Drawing.Size(65, 17);
            this.checkBoxVerbose.TabIndex = 16;
            this.checkBoxVerbose.Text = "Verbose";
            this.checkBoxVerbose.UseVisualStyleBackColor = true;
            this.checkBoxVerbose.CheckedChanged += new System.EventHandler(this.CheckBoxVerbose_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 623);
            this.Controls.Add(this.checkBoxVerbose);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.btnCompile);
            this.Controls.Add(this.btnDeleteSelection);
            this.Controls.Add(this.btnCheckSelection);
            this.Controls.Add(this.btnConnectProject);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btnOpenProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "TIA Portal Block Updater";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpenProject;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btnConnectProject;
        private System.Windows.Forms.Button btnCheckSelection;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.Button btnDeleteSelection;
        private System.Windows.Forms.Button btnCompile;
        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.CheckBox checkBoxVerbose;
    }
}

