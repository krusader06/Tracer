﻿namespace Tracer.Forms.Views.Sales
{
    partial class ucPurchasingRequest
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
            this.btnRequestPartsReview = new System.Windows.Forms.Button();
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
            this.dgActiveQuotes.TabIndex = 17;
            this.dgActiveQuotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveQuotes_CellClick);
            // 
            // btnRequestPartsReview
            // 
            this.btnRequestPartsReview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRequestPartsReview.Enabled = false;
            this.btnRequestPartsReview.Location = new System.Drawing.Point(299, 10);
            this.btnRequestPartsReview.Name = "btnRequestPartsReview";
            this.btnRequestPartsReview.Size = new System.Drawing.Size(203, 31);
            this.btnRequestPartsReview.TabIndex = 18;
            this.btnRequestPartsReview.Text = "Request Parts Review";
            this.btnRequestPartsReview.UseVisualStyleBackColor = true;
            this.btnRequestPartsReview.Click += new System.EventHandler(this.btnRequestPartsReview_Click);
            // 
            // ucPurchasingRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnRequestPartsReview);
            this.Controls.Add(this.dgActiveQuotes);
            this.Name = "ucPurchasingRequest";
            this.Size = new System.Drawing.Size(800, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgActiveQuotes;
        private System.Windows.Forms.Button btnRequestPartsReview;
    }
}
