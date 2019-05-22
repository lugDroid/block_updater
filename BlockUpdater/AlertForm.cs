using System;
using System.Windows.Forms;

namespace CopyBlocks
{
    public partial class AlertForm : Form
    {
        public AlertForm(string alertText, string caption)
        {
            InitializeComponent();

            alertTextBox.Text = alertText;
            this.Text = caption;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
