namespace Tracer.Forms.Views.Sales
{
    partial class ucEditLot
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
            this.ckShowAll = new System.Windows.Forms.CheckBox();
            this.dgLotGrid = new System.Windows.Forms.DataGridView();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgWORGrid = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtMasterDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtJobDueDate = new System.Windows.Forms.DateTimePicker();
            this.ckConsigned = new System.Windows.Forms.CheckBox();
            this.ckTurnkey = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtJobComments = new System.Windows.Forms.TextBox();
            this.txtTurnTime = new System.Windows.Forms.TextBox();
            this.txtOrderQuantity = new System.Windows.Forms.TextBox();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgLotGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWORGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ckShowAll
            // 
            this.ckShowAll.AutoSize = true;
            this.ckShowAll.Location = new System.Drawing.Point(125, 133);
            this.ckShowAll.Name = "ckShowAll";
            this.ckShowAll.Size = new System.Drawing.Size(67, 17);
            this.ckShowAll.TabIndex = 47;
            this.ckShowAll.Text = "Show All";
            this.ckShowAll.UseVisualStyleBackColor = true;
            this.ckShowAll.CheckedChanged += new System.EventHandler(this.ckShowAll_CheckedChanged);
            // 
            // dgLotGrid
            // 
            this.dgLotGrid.AllowUserToAddRows = false;
            this.dgLotGrid.AllowUserToDeleteRows = false;
            this.dgLotGrid.AllowUserToResizeRows = false;
            this.dgLotGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgLotGrid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgLotGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLotGrid.Location = new System.Drawing.Point(197, 149);
            this.dgLotGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dgLotGrid.Name = "dgLotGrid";
            this.dgLotGrid.ReadOnly = true;
            this.dgLotGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgLotGrid.RowTemplate.Height = 28;
            this.dgLotGrid.Size = new System.Drawing.Size(496, 194);
            this.dgLotGrid.TabIndex = 41;
            this.dgLotGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgLotGrid_CellClick);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(264, 87);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 26);
            this.btnClear.TabIndex = 29;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(86, 87);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 26);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgWORGrid
            // 
            this.dgWORGrid.AllowUserToAddRows = false;
            this.dgWORGrid.AllowUserToDeleteRows = false;
            this.dgWORGrid.AllowUserToResizeRows = false;
            this.dgWORGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgWORGrid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgWORGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWORGrid.Location = new System.Drawing.Point(16, 149);
            this.dgWORGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dgWORGrid.Name = "dgWORGrid";
            this.dgWORGrid.ReadOnly = true;
            this.dgWORGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgWORGrid.RowTemplate.Height = 28;
            this.dgWORGrid.Size = new System.Drawing.Size(176, 194);
            this.dgWORGrid.TabIndex = 48;
            this.dgWORGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgWORGrid_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Lot Numbers";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 134);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 49;
            this.label9.Text = "Work Orders";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(175, 87);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 26);
            this.btnUpdate.TabIndex = 50;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dtMasterDueDate
            // 
            this.dtMasterDueDate.Location = new System.Drawing.Point(441, 38);
            this.dtMasterDueDate.Name = "dtMasterDueDate";
            this.dtMasterDueDate.Size = new System.Drawing.Size(253, 20);
            this.dtMasterDueDate.TabIndex = 66;
            // 
            // dtJobDueDate
            // 
            this.dtJobDueDate.Location = new System.Drawing.Point(441, 17);
            this.dtJobDueDate.Name = "dtJobDueDate";
            this.dtJobDueDate.Size = new System.Drawing.Size(253, 20);
            this.dtJobDueDate.TabIndex = 65;
            // 
            // ckConsigned
            // 
            this.ckConsigned.AutoSize = true;
            this.ckConsigned.Location = new System.Drawing.Point(513, 87);
            this.ckConsigned.Name = "ckConsigned";
            this.ckConsigned.Size = new System.Drawing.Size(76, 17);
            this.ckConsigned.TabIndex = 64;
            this.ckConsigned.Text = "Consigned";
            this.ckConsigned.UseVisualStyleBackColor = true;
            // 
            // ckTurnkey
            // 
            this.ckTurnkey.AutoSize = true;
            this.ckTurnkey.Location = new System.Drawing.Point(442, 87);
            this.ckTurnkey.Name = "ckTurnkey";
            this.ckTurnkey.Size = new System.Drawing.Size(65, 17);
            this.ckTurnkey.TabIndex = 63;
            this.ckTurnkey.Text = "Turnkey";
            this.ckTurnkey.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "Job Comments";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(362, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 13);
            this.label11.TabIndex = 60;
            this.label11.Text = "Job Due Date";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(25, 62);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 13);
            this.label12.TabIndex = 58;
            this.label12.Text = "Turn Time";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(350, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 13);
            this.label13.TabIndex = 57;
            this.label13.Text = "Master Due Date";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 13);
            this.label14.TabIndex = 56;
            this.label14.Text = "Order Quantity";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 55;
            this.label15.Text = "Lot Number";
            // 
            // txtJobComments
            // 
            this.txtJobComments.Location = new System.Drawing.Point(441, 59);
            this.txtJobComments.Name = "txtJobComments";
            this.txtJobComments.Size = new System.Drawing.Size(253, 20);
            this.txtJobComments.TabIndex = 54;
            // 
            // txtTurnTime
            // 
            this.txtTurnTime.Location = new System.Drawing.Point(86, 59);
            this.txtTurnTime.Name = "txtTurnTime";
            this.txtTurnTime.Size = new System.Drawing.Size(263, 20);
            this.txtTurnTime.TabIndex = 53;
            // 
            // txtOrderQuantity
            // 
            this.txtOrderQuantity.Location = new System.Drawing.Point(86, 38);
            this.txtOrderQuantity.Name = "txtOrderQuantity";
            this.txtOrderQuantity.Size = new System.Drawing.Size(263, 20);
            this.txtOrderQuantity.TabIndex = 52;
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.Location = new System.Drawing.Point(86, 17);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(263, 20);
            this.txtLotNumber.TabIndex = 51;
            // 
            // ucEditLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.dtMasterDueDate);
            this.Controls.Add(this.dtJobDueDate);
            this.Controls.Add(this.ckConsigned);
            this.Controls.Add(this.ckTurnkey);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtJobComments);
            this.Controls.Add(this.txtTurnTime);
            this.Controls.Add(this.txtOrderQuantity);
            this.Controls.Add(this.txtLotNumber);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgWORGrid);
            this.Controls.Add(this.ckShowAll);
            this.Controls.Add(this.dgLotGrid);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Name = "ucEditLot";
            this.Size = new System.Drawing.Size(709, 362);
            ((System.ComponentModel.ISupportInitialize)(this.dgLotGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgWORGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ckShowAll;
        private System.Windows.Forms.DataGridView dgLotGrid;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgWORGrid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DateTimePicker dtMasterDueDate;
        private System.Windows.Forms.DateTimePicker dtJobDueDate;
        private System.Windows.Forms.CheckBox ckConsigned;
        private System.Windows.Forms.CheckBox ckTurnkey;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtJobComments;
        private System.Windows.Forms.TextBox txtTurnTime;
        private System.Windows.Forms.TextBox txtOrderQuantity;
        private System.Windows.Forms.TextBox txtLotNumber;
    }
}
