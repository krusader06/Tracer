namespace Tracer.Forms.Views.Purchasing
{
    partial class ucPerformPurchasingTask
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
            this.btnReleaseKit = new System.Windows.Forms.Button();
            this.btnPCBsReceived = new System.Windows.Forms.Button();
            this.btnStencilsReceived = new System.Windows.Forms.Button();
            this.btnPartsReceived = new System.Windows.Forms.Button();
            this.dgActiveWOR = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWOR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReleaseKit
            // 
            this.btnReleaseKit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReleaseKit.Enabled = false;
            this.btnReleaseKit.Location = new System.Drawing.Point(738, 10);
            this.btnReleaseKit.Name = "btnReleaseKit";
            this.btnReleaseKit.Size = new System.Drawing.Size(203, 31);
            this.btnReleaseKit.TabIndex = 31;
            this.btnReleaseKit.Text = "Release Kit";
            this.btnReleaseKit.UseVisualStyleBackColor = true;
            this.btnReleaseKit.Click += new System.EventHandler(this.btnReleaseKit_Click);
            // 
            // btnPCBsReceived
            // 
            this.btnPCBsReceived.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPCBsReceived.Enabled = false;
            this.btnPCBsReceived.Location = new System.Drawing.Point(529, 10);
            this.btnPCBsReceived.Name = "btnPCBsReceived";
            this.btnPCBsReceived.Size = new System.Drawing.Size(203, 31);
            this.btnPCBsReceived.TabIndex = 30;
            this.btnPCBsReceived.Text = "PCBs Received";
            this.btnPCBsReceived.UseVisualStyleBackColor = true;
            this.btnPCBsReceived.Click += new System.EventHandler(this.btnPCBsReceived_Click);
            // 
            // btnStencilsReceived
            // 
            this.btnStencilsReceived.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStencilsReceived.Enabled = false;
            this.btnStencilsReceived.Location = new System.Drawing.Point(320, 10);
            this.btnStencilsReceived.Name = "btnStencilsReceived";
            this.btnStencilsReceived.Size = new System.Drawing.Size(203, 31);
            this.btnStencilsReceived.TabIndex = 29;
            this.btnStencilsReceived.Text = "Stencils Received";
            this.btnStencilsReceived.UseVisualStyleBackColor = true;
            this.btnStencilsReceived.Click += new System.EventHandler(this.btnStencilsReceived_Click);
            // 
            // btnPartsReceived
            // 
            this.btnPartsReceived.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPartsReceived.Enabled = false;
            this.btnPartsReceived.Location = new System.Drawing.Point(111, 10);
            this.btnPartsReceived.Name = "btnPartsReceived";
            this.btnPartsReceived.Size = new System.Drawing.Size(203, 31);
            this.btnPartsReceived.TabIndex = 28;
            this.btnPartsReceived.Text = "Parts Received";
            this.btnPartsReceived.UseVisualStyleBackColor = true;
            this.btnPartsReceived.Click += new System.EventHandler(this.btnPartsReceived_Click);
            // 
            // dgActiveWOR
            // 
            this.dgActiveWOR.AllowUserToAddRows = false;
            this.dgActiveWOR.AllowUserToDeleteRows = false;
            this.dgActiveWOR.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveWOR.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveWOR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveWOR.Location = new System.Drawing.Point(16, 52);
            this.dgActiveWOR.Name = "dgActiveWOR";
            this.dgActiveWOR.ReadOnly = true;
            this.dgActiveWOR.Size = new System.Drawing.Size(1036, 508);
            this.dgActiveWOR.TabIndex = 27;
            this.dgActiveWOR.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveQuotes_CellClick);
            // 
            // ucPerformPurchasingTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnReleaseKit);
            this.Controls.Add(this.btnPCBsReceived);
            this.Controls.Add(this.btnStencilsReceived);
            this.Controls.Add(this.btnPartsReceived);
            this.Controls.Add(this.dgActiveWOR);
            this.Name = "ucPerformPurchasingTask";
            this.Size = new System.Drawing.Size(1068, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWOR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReleaseKit;
        private System.Windows.Forms.Button btnPCBsReceived;
        private System.Windows.Forms.Button btnStencilsReceived;
        private System.Windows.Forms.Button btnPartsReceived;
        private System.Windows.Forms.DataGridView dgActiveWOR;
    }
}
