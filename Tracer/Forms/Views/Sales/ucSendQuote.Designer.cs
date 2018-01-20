namespace Tracer.Forms.Views.Sales
{
    partial class ucSendQuote
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
            this.btnSendQuote = new System.Windows.Forms.Button();
            this.dgActiveQuotes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSendQuote
            // 
            this.btnSendQuote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSendQuote.Enabled = false;
            this.btnSendQuote.Location = new System.Drawing.Point(304, 10);
            this.btnSendQuote.Name = "btnSendQuote";
            this.btnSendQuote.Size = new System.Drawing.Size(203, 31);
            this.btnSendQuote.TabIndex = 20;
            this.btnSendQuote.Text = "Send Quote to Customer";
            this.btnSendQuote.UseVisualStyleBackColor = true;
            this.btnSendQuote.Click += new System.EventHandler(this.btnSendQuote_Click);
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
            // ucSendQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnSendQuote);
            this.Controls.Add(this.dgActiveQuotes);
            this.Name = "ucSendQuote";
            this.Size = new System.Drawing.Size(800, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSendQuote;
        private System.Windows.Forms.DataGridView dgActiveQuotes;
    }
}
