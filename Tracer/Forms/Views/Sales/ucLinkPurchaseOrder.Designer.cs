namespace Tracer.Forms.Views.Sales
{
    partial class ucLinkPurchaseOrder
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
            this.txtPONumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddPO = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSelectedQuote = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgActiveQuotes
            // 
            this.dgActiveQuotes.AllowUserToAddRows = false;
            this.dgActiveQuotes.AllowUserToDeleteRows = false;
            this.dgActiveQuotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveQuotes.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveQuotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveQuotes.Location = new System.Drawing.Point(18, 62);
            this.dgActiveQuotes.Name = "dgActiveQuotes";
            this.dgActiveQuotes.ReadOnly = true;
            this.dgActiveQuotes.Size = new System.Drawing.Size(946, 298);
            this.dgActiveQuotes.TabIndex = 4;
            this.dgActiveQuotes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveQuotes_CellClick);
            // 
            // txtPONumber
            // 
            this.txtPONumber.Location = new System.Drawing.Point(143, 20);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(177, 20);
            this.txtPONumber.TabIndex = 6;
            this.txtPONumber.TextChanged += new System.EventHandler(this.txtPONumber_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Purchase Order Number";
            // 
            // btnAddPO
            // 
            this.btnAddPO.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPO.Enabled = false;
            this.btnAddPO.Location = new System.Drawing.Point(769, 15);
            this.btnAddPO.Name = "btnAddPO";
            this.btnAddPO.Size = new System.Drawing.Size(196, 28);
            this.btnAddPO.TabIndex = 8;
            this.btnAddPO.Text = "Add Purchase Order to Quote";
            this.btnAddPO.UseVisualStyleBackColor = true;
            this.btnAddPO.Click += new System.EventHandler(this.btnAddPO_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(330, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Selected Quote:";
            // 
            // lblSelectedQuote
            // 
            this.lblSelectedQuote.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblSelectedQuote.AutoSize = true;
            this.lblSelectedQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedQuote.Location = new System.Drawing.Point(482, 14);
            this.lblSelectedQuote.Name = "lblSelectedQuote";
            this.lblSelectedQuote.Size = new System.Drawing.Size(57, 24);
            this.lblSelectedQuote.TabIndex = 10;
            this.lblSelectedQuote.Text = "None";
            // 
            // ucLinkPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.lblSelectedQuote);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddPO);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPONumber);
            this.Controls.Add(this.dgActiveQuotes);
            this.Name = "ucLinkPurchaseOrder";
            this.Size = new System.Drawing.Size(980, 378);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveQuotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgActiveQuotes;
        private System.Windows.Forms.TextBox txtPONumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddPO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSelectedQuote;
    }
}
