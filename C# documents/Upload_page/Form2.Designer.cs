namespace Upload_page
{
    partial class Upload_Page
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
            this.BtnChoose = new System.Windows.Forms.Button();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RejLable = new System.Windows.Forms.Label();
            this.btnsendsms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnChoose
            // 
            this.BtnChoose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnChoose.AutoSize = true;
            this.BtnChoose.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnChoose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnChoose.Location = new System.Drawing.Point(82, 372);
            this.BtnChoose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnChoose.Name = "BtnChoose";
            this.BtnChoose.Size = new System.Drawing.Size(230, 68);
            this.BtnChoose.TabIndex = 0;
            this.BtnChoose.Text = "Choose File";
            this.BtnChoose.UseVisualStyleBackColor = false;
            this.BtnChoose.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblFilePath
            // 
            this.lblFilePath.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFilePath.BackColor = System.Drawing.Color.Transparent;
            this.lblFilePath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblFilePath.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFilePath.Location = new System.Drawing.Point(30, 234);
            this.lblFilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(702, 72);
            this.lblFilePath.TabIndex = 1;
            this.lblFilePath.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFilePath.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpload.AutoSize = true;
            this.btnUpload.BackColor = System.Drawing.Color.YellowGreen;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpload.Location = new System.Drawing.Point(443, 372);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(225, 68);
            this.btnUpload.TabIndex = 2;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(767, 186);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(937, 365);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Visible = false;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // RejLable
            // 
            this.RejLable.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RejLable.AutoSize = true;
            this.RejLable.BackColor = System.Drawing.Color.Transparent;
            this.RejLable.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RejLable.ForeColor = System.Drawing.Color.Black;
            this.RejLable.Location = new System.Drawing.Point(989, 103);
            this.RejLable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.RejLable.Name = "RejLable";
            this.RejLable.Size = new System.Drawing.Size(526, 55);
            this.RejLable.TabIndex = 4;
            this.RejLable.Text = "Rejected Student Details";
            this.RejLable.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnsendsms
            // 
            this.btnsendsms.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnsendsms.AutoSize = true;
            this.btnsendsms.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnsendsms.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsendsms.ForeColor = System.Drawing.Color.Snow;
            this.btnsendsms.Location = new System.Drawing.Point(1263, 594);
            this.btnsendsms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsendsms.Name = "btnsendsms";
            this.btnsendsms.Size = new System.Drawing.Size(230, 78);
            this.btnsendsms.TabIndex = 5;
            this.btnsendsms.Text = "Send SMS";
            this.btnsendsms.UseVisualStyleBackColor = false;
            this.btnsendsms.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(265, 157);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 55);
            this.label1.TabIndex = 6;
            this.label1.Text = "Upload File";
            this.label1.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // Upload_Page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1730, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnsendsms);
            this.Controls.Add(this.RejLable);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.BtnChoose);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Upload_Page";
            this.Text = "Upload_page";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnChoose;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label RejLable;
        private System.Windows.Forms.Button btnsendsms;
        private System.Windows.Forms.Label label1;
    }
}

