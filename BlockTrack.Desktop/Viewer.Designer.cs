namespace BlockTrack
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbx_blockchain = new System.Windows.Forms.ListBox();
            this.lbl_block_id = new System.Windows.Forms.Label();
            this.lbl_block_previoushash = new System.Windows.Forms.Label();
            this.lbl_block_hash = new System.Windows.Forms.Label();
            this.lbl_block_nounce = new System.Windows.Forms.Label();
            this.lbl_block_timestamp = new System.Windows.Forms.Label();
            this.lbl_block_metadata = new System.Windows.Forms.Label();
            this.txt_block_id = new System.Windows.Forms.TextBox();
            this.txt_block_previoushash = new System.Windows.Forms.TextBox();
            this.txt_block_hash = new System.Windows.Forms.TextBox();
            this.txt_block_nounce = new System.Windows.Forms.TextBox();
            this.txt_block_timestamp = new System.Windows.Forms.TextBox();
            this.txt_block_metadata = new System.Windows.Forms.TextBox();
            this.btn_metadata_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbx_blockchain
            // 
            this.lbx_blockchain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lbx_blockchain.FormattingEnabled = true;
            this.lbx_blockchain.HorizontalScrollbar = true;
            this.lbx_blockchain.ItemHeight = 15;
            this.lbx_blockchain.Location = new System.Drawing.Point(13, 28);
            this.lbx_blockchain.Name = "lbx_blockchain";
            this.lbx_blockchain.Size = new System.Drawing.Size(348, 409);
            this.lbx_blockchain.TabIndex = 0;
            this.lbx_blockchain.SelectedIndexChanged += new System.EventHandler(this.lbx_blockchain_SelectedIndexChanged);
            // 
            // lbl_block_id
            // 
            this.lbl_block_id.AutoSize = true;
            this.lbl_block_id.Location = new System.Drawing.Point(368, 13);
            this.lbl_block_id.Name = "lbl_block_id";
            this.lbl_block_id.Size = new System.Drawing.Size(17, 15);
            this.lbl_block_id.TabIndex = 1;
            this.lbl_block_id.Text = "Id";
            // 
            // lbl_block_previoushash
            // 
            this.lbl_block_previoushash.AutoSize = true;
            this.lbl_block_previoushash.Location = new System.Drawing.Point(367, 66);
            this.lbl_block_previoushash.Name = "lbl_block_previoushash";
            this.lbl_block_previoushash.Size = new System.Drawing.Size(82, 15);
            this.lbl_block_previoushash.TabIndex = 2;
            this.lbl_block_previoushash.Text = "Previous Hash";
            // 
            // lbl_block_hash
            // 
            this.lbl_block_hash.AutoSize = true;
            this.lbl_block_hash.Location = new System.Drawing.Point(368, 119);
            this.lbl_block_hash.Name = "lbl_block_hash";
            this.lbl_block_hash.Size = new System.Drawing.Size(34, 15);
            this.lbl_block_hash.TabIndex = 3;
            this.lbl_block_hash.Text = "Hash";
            // 
            // lbl_block_nounce
            // 
            this.lbl_block_nounce.AutoSize = true;
            this.lbl_block_nounce.Location = new System.Drawing.Point(368, 172);
            this.lbl_block_nounce.Name = "lbl_block_nounce";
            this.lbl_block_nounce.Size = new System.Drawing.Size(49, 15);
            this.lbl_block_nounce.TabIndex = 3;
            this.lbl_block_nounce.Text = "Nounce";
            // 
            // lbl_block_timestamp
            // 
            this.lbl_block_timestamp.AutoSize = true;
            this.lbl_block_timestamp.Location = new System.Drawing.Point(368, 225);
            this.lbl_block_timestamp.Name = "lbl_block_timestamp";
            this.lbl_block_timestamp.Size = new System.Drawing.Size(70, 15);
            this.lbl_block_timestamp.TabIndex = 4;
            this.lbl_block_timestamp.Text = "Time Stamp";
            // 
            // lbl_block_metadata
            // 
            this.lbl_block_metadata.AutoSize = true;
            this.lbl_block_metadata.Location = new System.Drawing.Point(368, 278);
            this.lbl_block_metadata.Name = "lbl_block_metadata";
            this.lbl_block_metadata.Size = new System.Drawing.Size(57, 15);
            this.lbl_block_metadata.TabIndex = 5;
            this.lbl_block_metadata.Text = "Metadata";
            // 
            // txt_block_id
            // 
            this.txt_block_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_block_id.Location = new System.Drawing.Point(368, 31);
            this.txt_block_id.Name = "txt_block_id";
            this.txt_block_id.ReadOnly = true;
            this.txt_block_id.Size = new System.Drawing.Size(275, 23);
            this.txt_block_id.TabIndex = 6;
            // 
            // txt_block_previoushash
            // 
            this.txt_block_previoushash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_block_previoushash.Location = new System.Drawing.Point(368, 84);
            this.txt_block_previoushash.Name = "txt_block_previoushash";
            this.txt_block_previoushash.ReadOnly = true;
            this.txt_block_previoushash.Size = new System.Drawing.Size(275, 23);
            this.txt_block_previoushash.TabIndex = 6;
            // 
            // txt_block_hash
            // 
            this.txt_block_hash.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_block_hash.Location = new System.Drawing.Point(368, 137);
            this.txt_block_hash.Name = "txt_block_hash";
            this.txt_block_hash.ReadOnly = true;
            this.txt_block_hash.Size = new System.Drawing.Size(275, 23);
            this.txt_block_hash.TabIndex = 6;
            // 
            // txt_block_nounce
            // 
            this.txt_block_nounce.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_block_nounce.Location = new System.Drawing.Point(368, 190);
            this.txt_block_nounce.Name = "txt_block_nounce";
            this.txt_block_nounce.ReadOnly = true;
            this.txt_block_nounce.Size = new System.Drawing.Size(275, 23);
            this.txt_block_nounce.TabIndex = 6;
            // 
            // txt_block_timestamp
            // 
            this.txt_block_timestamp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_block_timestamp.Location = new System.Drawing.Point(368, 243);
            this.txt_block_timestamp.Name = "txt_block_timestamp";
            this.txt_block_timestamp.ReadOnly = true;
            this.txt_block_timestamp.Size = new System.Drawing.Size(275, 23);
            this.txt_block_timestamp.TabIndex = 6;
            // 
            // txt_block_metadata
            // 
            this.txt_block_metadata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_block_metadata.Location = new System.Drawing.Point(368, 296);
            this.txt_block_metadata.Multiline = true;
            this.txt_block_metadata.Name = "txt_block_metadata";
            this.txt_block_metadata.ReadOnly = true;
            this.txt_block_metadata.Size = new System.Drawing.Size(275, 141);
            this.txt_block_metadata.TabIndex = 6;
            // 
            // btn_metadata_add
            // 
            this.btn_metadata_add.Location = new System.Drawing.Point(12, 5);
            this.btn_metadata_add.Name = "btn_metadata_add";
            this.btn_metadata_add.Size = new System.Drawing.Size(75, 23);
            this.btn_metadata_add.TabIndex = 7;
            this.btn_metadata_add.Text = "Add";
            this.btn_metadata_add.UseVisualStyleBackColor = true;
            this.btn_metadata_add.Click += new System.EventHandler(this.btn_metadata_add_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 450);
            this.Controls.Add(this.btn_metadata_add);
            this.Controls.Add(this.txt_block_metadata);
            this.Controls.Add(this.txt_block_timestamp);
            this.Controls.Add(this.txt_block_nounce);
            this.Controls.Add(this.txt_block_hash);
            this.Controls.Add(this.txt_block_previoushash);
            this.Controls.Add(this.txt_block_id);
            this.Controls.Add(this.lbl_block_metadata);
            this.Controls.Add(this.lbl_block_timestamp);
            this.Controls.Add(this.lbl_block_nounce);
            this.Controls.Add(this.lbl_block_hash);
            this.Controls.Add(this.lbl_block_previoushash);
            this.Controls.Add(this.lbl_block_id);
            this.Controls.Add(this.lbx_blockchain);
            this.Name = "Main";
            this.Text = "BlockTrack Viewer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbx_blockchain;
        private System.Windows.Forms.Label lbl_block_id;
        private System.Windows.Forms.Label lbl_block_previoushash;
        private System.Windows.Forms.Label lbl_block_hash;
        private System.Windows.Forms.Label lbl_block_nounce;
        private System.Windows.Forms.Label lbl_block_timestamp;
        private System.Windows.Forms.Label lbl_block_metadata;
        private System.Windows.Forms.TextBox txt_block_id;
        private System.Windows.Forms.TextBox txt_block_previoushash;
        private System.Windows.Forms.TextBox txt_block_hash;
        private System.Windows.Forms.TextBox txt_block_nounce;
        private System.Windows.Forms.TextBox txt_block_timestamp;
        private System.Windows.Forms.TextBox txt_block_metadata;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_metadata_add;
    }
}

