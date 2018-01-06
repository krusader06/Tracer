namespace Tracer.Forms.Views.Engineering
{
    partial class ucSalesRequest
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
            this.btnRequestMasterReview = new System.Windows.Forms.Button();
            this.dgActiveQuotes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRequestMasterReview
            // 
            this.btnRequestMasterReview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRequestMasterReview.Enabled = false;
            this.btnRequestMasterReview.Location = new System.Drawing.Point(299, 10);
            this.btnRequestMasterReview.Name = "btnRequestMasterReview";
            this.btnRequestMasterReview.Size = new System.Drawing.Size(203, 31);
            this.btnRequestMasterReview.TabIndex = 20;
            this.btnRequestMasterReview.Text = "Request Master Review";
            this.btnRequestMasterReview.UseVisualStyleBackColor = true;
            this.btnRequestMasterReview.Click += new System.EventHandler(this.btnRequestMasterReview_Click);
            // 
            // dgActiveQuotes
            // 
            this.dgActiveQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveQuotes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveQuotes.Location = new System.Drawing.Point(16, 52);
            this.dgActiveQuotes.Name = "dgActiveQuotes";
            this.dgActiveQuotes.Size = new System.Drawing.Size(768, 508);
            this.dgActiveQuotes.TabIndex = 19;
            this.dgActiveQuotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveQuotes_CellClick);
            // 
            // ucSalesTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnRequestMasterReview);
            this.Controls.Add(this.dgActiveQuotes);
            this.Name = "ucSalesTask";
            this.Size = new System.Drawing.Size(800, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRequestMasterReview;
        private System.Windows.Forms.DataGridView dgActiveQuotes;
    }
}
