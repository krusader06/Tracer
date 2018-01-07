namespace Tracer.Forms.Views.Engineering
{
    partial class ucPerformEngineeringTask
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
            this.btnReleaseWOR = new System.Windows.Forms.Button();
            this.dgActiveWOR = new System.Windows.Forms.DataGridView();
            this.btnCompileTraveler = new System.Windows.Forms.Button();
            this.btnReturnTraveler = new System.Windows.Forms.Button();
            this.btnApproveStencilPlots = new System.Windows.Forms.Button();
            this.btnApprovePCBArrays = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWOR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReleaseWOR
            // 
            this.btnReleaseWOR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReleaseWOR.Enabled = false;
            this.btnReleaseWOR.Location = new System.Drawing.Point(15, 10);
            this.btnReleaseWOR.Name = "btnReleaseWOR";
            this.btnReleaseWOR.Size = new System.Drawing.Size(203, 31);
            this.btnReleaseWOR.TabIndex = 22;
            this.btnReleaseWOR.Text = "Release Work Order";
            this.btnReleaseWOR.UseVisualStyleBackColor = true;
            this.btnReleaseWOR.Click += new System.EventHandler(this.btnReleaseWOR_Click);
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
            this.dgActiveWOR.TabIndex = 21;
            this.dgActiveWOR.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveQuotes_CellClick);
            // 
            // btnCompileTraveler
            // 
            this.btnCompileTraveler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCompileTraveler.Enabled = false;
            this.btnCompileTraveler.Location = new System.Drawing.Point(224, 10);
            this.btnCompileTraveler.Name = "btnCompileTraveler";
            this.btnCompileTraveler.Size = new System.Drawing.Size(203, 31);
            this.btnCompileTraveler.TabIndex = 23;
            this.btnCompileTraveler.Text = "Release Traveler";
            this.btnCompileTraveler.UseVisualStyleBackColor = true;
            this.btnCompileTraveler.Click += new System.EventHandler(this.btnReleaseTraveler_Click);
            // 
            // btnReturnTraveler
            // 
            this.btnReturnTraveler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReturnTraveler.Enabled = false;
            this.btnReturnTraveler.Location = new System.Drawing.Point(433, 10);
            this.btnReturnTraveler.Name = "btnReturnTraveler";
            this.btnReturnTraveler.Size = new System.Drawing.Size(203, 31);
            this.btnReturnTraveler.TabIndex = 24;
            this.btnReturnTraveler.Text = "Return Traveler";
            this.btnReturnTraveler.UseVisualStyleBackColor = true;
            this.btnReturnTraveler.Click += new System.EventHandler(this.btnReturnTraveler_Click);
            // 
            // btnApproveStencilPlots
            // 
            this.btnApproveStencilPlots.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnApproveStencilPlots.Enabled = false;
            this.btnApproveStencilPlots.Location = new System.Drawing.Point(642, 10);
            this.btnApproveStencilPlots.Name = "btnApproveStencilPlots";
            this.btnApproveStencilPlots.Size = new System.Drawing.Size(203, 31);
            this.btnApproveStencilPlots.TabIndex = 25;
            this.btnApproveStencilPlots.Text = "Approve Stencil Plots";
            this.btnApproveStencilPlots.UseVisualStyleBackColor = true;
            this.btnApproveStencilPlots.Click += new System.EventHandler(this.btnApproveStencilPlots_Click);
            // 
            // btnApprovePCBArrays
            // 
            this.btnApprovePCBArrays.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnApprovePCBArrays.Enabled = false;
            this.btnApprovePCBArrays.Location = new System.Drawing.Point(851, 10);
            this.btnApprovePCBArrays.Name = "btnApprovePCBArrays";
            this.btnApprovePCBArrays.Size = new System.Drawing.Size(203, 31);
            this.btnApprovePCBArrays.TabIndex = 26;
            this.btnApprovePCBArrays.Text = "Approve PCB Arrays";
            this.btnApprovePCBArrays.UseVisualStyleBackColor = true;
            this.btnApprovePCBArrays.Click += new System.EventHandler(this.btnApprovePCBArrays_Click);
            // 
            // ucPerformEngineeringTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnApprovePCBArrays);
            this.Controls.Add(this.btnApproveStencilPlots);
            this.Controls.Add(this.btnReturnTraveler);
            this.Controls.Add(this.btnCompileTraveler);
            this.Controls.Add(this.btnReleaseWOR);
            this.Controls.Add(this.dgActiveWOR);
            this.Name = "ucPerformEngineeringTask";
            this.Size = new System.Drawing.Size(1068, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWOR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReleaseWOR;
        private System.Windows.Forms.DataGridView dgActiveWOR;
        private System.Windows.Forms.Button btnCompileTraveler;
        private System.Windows.Forms.Button btnReturnTraveler;
        private System.Windows.Forms.Button btnApproveStencilPlots;
        private System.Windows.Forms.Button btnApprovePCBArrays;
    }
}
