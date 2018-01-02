namespace Tracer.Forms.Views.Sales
{
    partial class ucAddLot
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
            this.lblWorkOrder = new System.Windows.Forms.Label();
            this.dtMasterDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtJobDueDate = new System.Windows.Forms.DateTimePicker();
            this.ckConsigned = new System.Windows.Forms.CheckBox();
            this.ckTurnkey = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddLot = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtJobComments = new System.Windows.Forms.TextBox();
            this.txtTurnTime = new System.Windows.Forms.TextBox();
            this.txtOrderQuantity = new System.Windows.Forms.TextBox();
            this.txtLotNumber = new System.Windows.Forms.TextBox();
            this.dgNewLots = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgNewLots)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWorkOrder
            // 
            this.lblWorkOrder.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblWorkOrder.AutoSize = true;
            this.lblWorkOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWorkOrder.Location = new System.Drawing.Point(410, 14);
            this.lblWorkOrder.Name = "lblWorkOrder";
            this.lblWorkOrder.Size = new System.Drawing.Size(72, 25);
            this.lblWorkOrder.TabIndex = 32;
            this.lblWorkOrder.Text = "NONE";
            // 
            // dtMasterDueDate
            // 
            this.dtMasterDueDate.Location = new System.Drawing.Point(443, 73);
            this.dtMasterDueDate.Name = "dtMasterDueDate";
            this.dtMasterDueDate.Size = new System.Drawing.Size(253, 20);
            this.dtMasterDueDate.TabIndex = 31;
            // 
            // dtJobDueDate
            // 
            this.dtJobDueDate.Location = new System.Drawing.Point(443, 52);
            this.dtJobDueDate.Name = "dtJobDueDate";
            this.dtJobDueDate.Size = new System.Drawing.Size(253, 20);
            this.dtJobDueDate.TabIndex = 30;
            // 
            // ckConsigned
            // 
            this.ckConsigned.AutoSize = true;
            this.ckConsigned.Location = new System.Drawing.Point(515, 122);
            this.ckConsigned.Name = "ckConsigned";
            this.ckConsigned.Size = new System.Drawing.Size(76, 17);
            this.ckConsigned.TabIndex = 29;
            this.ckConsigned.Text = "Consigned";
            this.ckConsigned.UseVisualStyleBackColor = true;
            // 
            // ckTurnkey
            // 
            this.ckTurnkey.AutoSize = true;
            this.ckTurnkey.Location = new System.Drawing.Point(444, 122);
            this.ckTurnkey.Name = "ckTurnkey";
            this.ckTurnkey.Size = new System.Drawing.Size(65, 17);
            this.ckTurnkey.TabIndex = 28;
            this.ckTurnkey.Text = "Turnkey";
            this.ckTurnkey.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(228, 120);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(123, 29);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnAddLot
            // 
            this.btnAddLot.Location = new System.Drawing.Point(98, 120);
            this.btnAddLot.Name = "btnAddLot";
            this.btnAddLot.Size = new System.Drawing.Size(124, 29);
            this.btnAddLot.TabIndex = 26;
            this.btnAddLot.Text = "Add Lot Number";
            this.btnAddLot.UseVisualStyleBackColor = true;
            this.btnAddLot.Click += new System.EventHandler(this.btnAddLot_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(361, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Job Comments";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(364, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Job Due Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Turn Time";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(352, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Master Due Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Order Quantity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Lot Number";
            // 
            // txtJobComments
            // 
            this.txtJobComments.Location = new System.Drawing.Point(443, 94);
            this.txtJobComments.Name = "txtJobComments";
            this.txtJobComments.Size = new System.Drawing.Size(253, 20);
            this.txtJobComments.TabIndex = 19;
            // 
            // txtTurnTime
            // 
            this.txtTurnTime.Location = new System.Drawing.Point(98, 94);
            this.txtTurnTime.Name = "txtTurnTime";
            this.txtTurnTime.Size = new System.Drawing.Size(253, 20);
            this.txtTurnTime.TabIndex = 18;
            // 
            // txtOrderQuantity
            // 
            this.txtOrderQuantity.Location = new System.Drawing.Point(98, 73);
            this.txtOrderQuantity.Name = "txtOrderQuantity";
            this.txtOrderQuantity.Size = new System.Drawing.Size(253, 20);
            this.txtOrderQuantity.TabIndex = 17;
            // 
            // txtLotNumber
            // 
            this.txtLotNumber.Location = new System.Drawing.Point(98, 52);
            this.txtLotNumber.Name = "txtLotNumber";
            this.txtLotNumber.Size = new System.Drawing.Size(253, 20);
            this.txtLotNumber.TabIndex = 16;
            // 
            // dgNewLots
            // 
            this.dgNewLots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNewLots.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgNewLots.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNewLots.Location = new System.Drawing.Point(16, 155);
            this.dgNewLots.Name = "dgNewLots";
            this.dgNewLots.Size = new System.Drawing.Size(768, 405);
            this.dgNewLots.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(276, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Work Order:";
            // 
            // ucAddLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.lblWorkOrder);
            this.Controls.Add(this.dtMasterDueDate);
            this.Controls.Add(this.dtJobDueDate);
            this.Controls.Add(this.ckConsigned);
            this.Controls.Add(this.ckTurnkey);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddLot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtJobComments);
            this.Controls.Add(this.txtTurnTime);
            this.Controls.Add(this.txtOrderQuantity);
            this.Controls.Add(this.txtLotNumber);
            this.Controls.Add(this.dgNewLots);
            this.Controls.Add(this.label2);
            this.Name = "ucAddLot";
            this.Size = new System.Drawing.Size(800, 577);
            ((System.ComponentModel.ISupportInitialize)(this.dgNewLots)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWorkOrder;
        private System.Windows.Forms.DateTimePicker dtMasterDueDate;
        private System.Windows.Forms.DateTimePicker dtJobDueDate;
        private System.Windows.Forms.CheckBox ckConsigned;
        private System.Windows.Forms.CheckBox ckTurnkey;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAddLot;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtJobComments;
        private System.Windows.Forms.TextBox txtTurnTime;
        private System.Windows.Forms.TextBox txtOrderQuantity;
        private System.Windows.Forms.TextBox txtLotNumber;
        private System.Windows.Forms.DataGridView dgNewLots;
        private System.Windows.Forms.Label label2;
    }
}
