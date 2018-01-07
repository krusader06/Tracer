namespace Tracer.Forms.Views.Sales
{
    partial class ucSalesDashboard
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
            this.dgActiveQuotes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgActiveQuotes
            // 
            this.dgActiveQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveQuotes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveQuotes.Location = new System.Drawing.Point(16, 16);
            this.dgActiveQuotes.Name = "dgActiveQuotes";
            this.dgActiveQuotes.Size = new System.Drawing.Size(813, 447);
            this.dgActiveQuotes.TabIndex = 0;
            // 
            // ucSalesDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.dgActiveQuotes);
            this.Name = "ucSalesDashboard";
            this.Size = new System.Drawing.Size(845, 479);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgActiveQuotes;
    }
}
