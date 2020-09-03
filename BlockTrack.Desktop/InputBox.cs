using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BlockTrack
{
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
            Metadata = string.Empty;
        }

        public string Metadata;
        private void btn_ok_Click(object sender, EventArgs e)
        {
            Metadata = $"B: {txt_barcode.Text} {Environment.NewLine}" +
                $"S: {txt_status.Text} {Environment.NewLine}" +
                $"U: JULIO {Environment.NewLine}" +
                $"T: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")} ";

            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            Metadata = string.Empty;
            this.Close();
        }
    }
}
