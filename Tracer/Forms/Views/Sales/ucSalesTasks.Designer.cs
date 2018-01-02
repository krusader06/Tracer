namespace Tracer.Forms.Views.Sales
{
    partial class ucSalesTasks
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
            this.dgTaskView = new System.Windows.Forms.DataGridView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnEnd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgTaskView
            // 
            this.dgTaskView.AllowUserToAddRows = false;
            this.dgTaskView.AllowUserToDeleteRows = false;
            this.dgTaskView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgTaskView.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgTaskView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgTaskView.Location = new System.Drawing.Point(16, 90);
            this.dgTaskView.Name = "dgTaskView";
            this.dgTaskView.ReadOnly = true;
            this.dgTaskView.Size = new System.Drawing.Size(782, 425);
            this.dgTaskView.TabIndex = 0;
            this.dgTaskView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaskView_CellClick);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(228, 45);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(327, 31);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start Task";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(228, 45);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(327, 31);
            this.btnEnd.TabIndex = 2;
            this.btnEnd.Text = "End Task";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Visible = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select A Task to Perform";
            // 
            // ucSalesTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgTaskView);
            this.Name = "ucSalesTasks";
            this.Size = new System.Drawing.Size(814, 531);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgTaskView;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Label label1;
    }
}
