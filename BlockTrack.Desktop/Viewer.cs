using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BlockTrack.Models;

namespace BlockTrack
{
    public partial class Main : Form
    {
        private BlockChain Chain;
        public Main()
        {
            InitializeComponent();
            Chain = new BlockChain();

            Chain.EnQueueMetadata("TESTE1");
            Chain.EnQueueMetadata("TESTE2");
        }
        private void Main_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void LoadList()
        {
            lbx_blockchain.Items.Clear();
            int i = 1;
            foreach (var block in Chain.GetLedger())
                lbx_blockchain.Items.Add($"Block #{i++}");
        }

        private void lbx_blockchain_SelectedIndexChanged(object sender, EventArgs e)
        {
            var larr = Chain.GetLedger().ToArray();
            var selected = larr[lbx_blockchain.SelectedIndex];

            txt_block_id.Text = selected.GetId();
            txt_block_hash.Text = selected.GetHash();
            txt_block_nounce.Text = selected.GetNounce();
            txt_block_previoushash.Text = selected.GetPreviousHash();
            txt_block_timestamp.Text = selected.GetTimeStamp();
            txt_block_metadata.Text = selected.GetMetadata();
        }

        private void btn_metadata_add_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            input.ShowDialog();

            if (!string.IsNullOrEmpty(input.Metadata))
                Chain.EnQueueMetadata(input.Metadata);

            LoadList();
        }
    }
}
