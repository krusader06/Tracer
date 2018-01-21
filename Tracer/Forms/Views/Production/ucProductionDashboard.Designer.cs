namespace Tracer.Forms.Views.Production
{
    partial class ucProductionDashboard
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
            this.ckQuotes = new System.Windows.Forms.CheckBox();
            this.ckWORs = new System.Windows.Forms.CheckBox();
            this.dgTaskView = new System.Windows.Forms.DataGridView();
            this.btnEnd = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.dgActiveWORs = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORs)).BeginInit();
            this.SuspendLayout();
            // 
            // ckQuotes
            // 
            this.ckQuotes.AutoSize = true;
            this.ckQuotes.Checked = true;
            this.ckQuotes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckQuotes.Location = new System.Drawing.Point(110, 9);
            this.ckQuotes.Name = "ckQuotes";
            this.ckQuotes.Size = new System.Drawing.Size(60, 17);
            this.ckQuotes.TabIndex = 20;
            this.ckQuotes.Text = "Quotes";
            this.ckQuotes.UseVisualStyleBackColor = true;
            this.ckQuotes.CheckedChanged += new System.EventHandler(this.ckQuotes_CheckedChanged);
            // 
            // ckWORs
            // 
            this.ckWORs.AutoSize = true;
            this.ckWORs.Checked = true;
            this.ckWORs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckWORs.Location = new System.Drawing.Point(18, 9);
            this.ckWORs.Name = "ckWORs";
            this.ckWORs.Size = new System.Drawing.Size(86, 17);
            this.ckWORs.TabIndex = 19;
            this.ckWORs.Text = "Work Orders";
            this.ckWORs.UseVisualStyleBackColor = true;
            this.ckWORs.CheckedChanged += new System.EventHandler(this.ckWORs_CheckedChanged);
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
            this.dgTaskView.Location = new System.Drawing.Point(16, 368);
            this.dgTaskView.Name = "dgTaskView";
            this.dgTaskView.ReadOnly = true;
            this.dgTaskView.Size = new System.Drawing.Size(1525, 374);
            this.dgTaskView.TabIndex = 18;
            this.dgTaskView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgTaskView_CellClick);
            this.dgTaskView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgTaskView_CellFormatting);
            // 
            // btnEnd
            // 
            this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnd.Enabled = false;
            this.btnEnd.Location = new System.Drawing.Point(18, 331);
            this.btnEnd.Name = "btnEnd";
            this.btnEnd.Size = new System.Drawing.Size(1525, 31);
            this.btnEnd.TabIndex = 17;
            this.btnEnd.Text = "End Task";
            this.btnEnd.UseVisualStyleBackColor = true;
            this.btnEnd.Visible = false;
            this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(16, 331);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(1525, 31);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start Task";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgActiveWORs
            // 
            this.dgActiveWORs.AllowUserToAddRows = false;
            this.dgActiveWORs.AllowUserToDeleteRows = false;
            this.dgActiveWORs.AllowUserToResizeColumns = false;
            this.dgActiveWORs.AllowUserToResizeRows = false;
            this.dgActiveWORs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgActiveWORs.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgActiveWORs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgActiveWORs.Enabled = false;
            this.dgActiveWORs.Location = new System.Drawing.Point(16, 35);
            this.dgActiveWORs.Margin = new System.Windows.Forms.Padding(1);
            this.dgActiveWORs.Name = "dgActiveWORs";
            this.dgActiveWORs.Size = new System.Drawing.Size(1525, 261);
            this.dgActiveWORs.TabIndex = 13;
            this.dgActiveWORs.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgActiveWORs_CellBeginEdit);
            this.dgActiveWORs.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgActiveWORs_CellEndEdit);
            this.dgActiveWORs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgActiveWORs_CellFormatting);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(734, 297);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 31);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tasks";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(624, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "Work Orders and Quotes";
            // 
            // ucProductionDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.ckQuotes);
            this.Controls.Add(this.ckWORs);
            this.Controls.Add(this.dgTaskView);
            this.Controls.Add(this.btnEnd);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.dgActiveWORs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "ucProductionDashboard";
            this.Size = new System.Drawing.Size(1557, 761);
            ((System.ComponentModel.ISupportInitialize)(this.dgTaskView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgActiveWORs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckQuotes;
        private System.Windows.Forms.CheckBox ckWORs;
        private System.Windows.Forms.DataGridView dgTaskView;
        private System.Windows.Forms.Button btnEnd;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgActiveWORs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}
