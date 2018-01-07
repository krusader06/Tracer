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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgActiveWORs
            // 
            this.dgActiveWORs.AllowUserToAddRows = false;
            this.dgActiveWORs.AllowUserToDeleteRows = false;
            this.dgActiveWORs.AllowUserToResizeRows = false;
            this.dgActiveWORs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveWORs.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveWORs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveWORs.Enabled = false;
            this.dgActiveWORs.Location = new System.Drawing.Point(17, 67);
            this.dgActiveWORs.Margin = new System.Windows.Forms.Padding(1);
            this.dgActiveWORs.Name = "dgActiveWORs";
            this.dgActiveWORs.ReadOnly = true;
            this.dgActiveWORs.RowTemplate.Height = 28;
            this.dgActiveWORs.Size = new System.Drawing.Size(812, 395);
            this.dgActiveWORs.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(360, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Active Jobs";
            // 
            // ucProcessDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgActiveWORs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ucProcessDashboard";
            this.Size = new System.Drawing.Size(845, 479);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgActiveWORs;
        private System.Windows.Forms.Label label1;
    }
}
