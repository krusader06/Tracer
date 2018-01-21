namespace Tracer.Forms.Views.Executive
{
    partial class ucSuperHot
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
            this.btnReset = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.dgActiveWOR = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWOR)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(535, 11);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(203, 31);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnSet
            // 
            this.btnSet.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSet.Enabled = false;
            this.btnSet.Location = new System.Drawing.Point(326, 11);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(203, 31);
            this.btnSet.TabIndex = 28;
            this.btnSet.Text = "Set";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
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
            this.dgActiveWOR.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveWOR_CellClick);
            // 
            // ucSuperHot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.dgActiveWOR);
            this.Name = "ucSuperHot";
            this.Size = new System.Drawing.Size(1068, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWOR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.DataGridView dgActiveWOR;
    }
}
