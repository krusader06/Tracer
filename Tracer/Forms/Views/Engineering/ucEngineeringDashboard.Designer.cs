namespace Tracer.Forms.Views.Engineering
{
    partial class ucProcessDashboard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgActiveWORs = new System.Windows.Forms.DataGridView();
            this.dgActiveWORStatus = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgActiveWORs
            // 
            this.dgActiveWORs.AllowUserToAddRows = false;
            this.dgActiveWORs.AllowUserToDeleteRows = false;
            this.dgActiveWORs.AllowUserToResizeRows = false;
            this.dgActiveWORs.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveWORs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveWORs.Enabled = false;
            this.dgActiveWORs.Location = new System.Drawing.Point(16, 16);
            this.dgActiveWORs.Margin = new System.Windows.Forms.Padding(1);
            this.dgActiveWORs.Name = "dgActiveWORs";
            this.dgActiveWORs.ReadOnly = true;
            this.dgActiveWORs.RowTemplate.Height = 28;
            this.dgActiveWORs.Size = new System.Drawing.Size(631, 269);
            this.dgActiveWORs.TabIndex = 1;
            this.dgActiveWORs.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveWORs_CellClick);
            // 
            // dgActiveWORStatus
            // 
            this.dgActiveWORStatus.AllowUserToAddRows = false;
            this.dgActiveWORStatus.AllowUserToDeleteRows = false;
            this.dgActiveWORStatus.AllowUserToResizeRows = false;
            this.dgActiveWORStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveWORStatus.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveWORStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveWORStatus.Enabled = false;
            this.dgActiveWORStatus.Location = new System.Drawing.Point(601, 16);
            this.dgActiveWORStatus.Margin = new System.Windows.Forms.Padding(1);
            this.dgActiveWORStatus.Name = "dgActiveWORStatus";
            this.dgActiveWORStatus.ReadOnly = true;
            this.dgActiveWORStatus.RowTemplate.Height = 28;
            this.dgActiveWORStatus.Size = new System.Drawing.Size(940, 269);
            this.dgActiveWORStatus.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Work Orders and Quotes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(646, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(16, 306);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1525, 423);
            this.dataGridView1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tasks";
            // 
            // ucProcessDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.dgActiveWORs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgActiveWORStatus);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucProcessDashboard";
            this.Size = new System.Drawing.Size(1557, 748);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgActiveWORs;
        private System.Windows.Forms.DataGridView dgActiveWORStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
    }
}
