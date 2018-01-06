namespace Tracer.Forms.Views.Sales
{
    partial class ucEngineeringRequest
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
            this.btnRequestPreBid = new System.Windows.Forms.Button();
            this.btnRequestBOMValidation = new System.Windows.Forms.Button();
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
            this.dgActiveQuotes.Location = new System.Drawing.Point(16, 52);
            this.dgActiveQuotes.Name = "dgActiveQuotes";
            this.dgActiveQuotes.Size = new System.Drawing.Size(768, 508);
            this.dgActiveQuotes.TabIndex = 16;
            this.dgActiveQuotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveQuotes_CellClick);
            // 
            // btnRequestPreBid
            // 
            this.btnRequestPreBid.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRequestPreBid.Enabled = false;
            this.btnRequestPreBid.Location = new System.Drawing.Point(196, 11);
            this.btnRequestPreBid.Name = "btnRequestPreBid";
            this.btnRequestPreBid.Size = new System.Drawing.Size(203, 31);
            this.btnRequestPreBid.TabIndex = 17;
            this.btnRequestPreBid.Text = "Request Pre-Bid Review";
            this.btnRequestPreBid.UseVisualStyleBackColor = true;
            this.btnRequestPreBid.Click += new System.EventHandler(this.btnRequestPreBid_Click);
            // 
            // btnRequestBOMValidation
            // 
            this.btnRequestBOMValidation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRequestBOMValidation.Enabled = false;
            this.btnRequestBOMValidation.Location = new System.Drawing.Point(405, 11);
            this.btnRequestBOMValidation.Name = "btnRequestBOMValidation";
            this.btnRequestBOMValidation.Size = new System.Drawing.Size(203, 31);
            this.btnRequestBOMValidation.TabIndex = 18;
            this.btnRequestBOMValidation.Text = "Request BOM Validation";
            this.btnRequestBOMValidation.UseVisualStyleBackColor = true;
            this.btnRequestBOMValidation.Click += new System.EventHandler(this.btnRequestBOMValidation_Click);
            // 
            // ucEngineeringRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnRequestBOMValidation);
            this.Controls.Add(this.btnRequestPreBid);
            this.Controls.Add(this.dgActiveQuotes);
            this.Name = "ucEngineeringRequest";
            this.Size = new System.Drawing.Size(800, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgActiveQuotes;
        private System.Windows.Forms.Button btnRequestPreBid;
        private System.Windows.Forms.Button btnRequestBOMValidation;
    }
}
