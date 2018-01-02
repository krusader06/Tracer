namespace Tracer.Forms.Views.Sales
{
    partial class ucAddEditQuote
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
            this.radioHighConf = new System.Windows.Forms.RadioButton();
            this.radioMedConf = new System.Windows.Forms.RadioButton();
            this.radioLowConf = new System.Windows.Forms.RadioButton();
            this.dgQuoteGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtPartID = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtWOR = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dtDueDate = new System.Windows.Forms.DateTimePicker();
            this.ckShowAll = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgQuoteGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // radioHighConf
            // 
            this.radioHighConf.AutoSize = true;
            this.radioHighConf.Location = new System.Drawing.Point(652, 77);
            this.radioHighConf.Margin = new System.Windows.Forms.Padding(2);
            this.radioHighConf.Name = "radioHighConf";
            this.radioHighConf.Size = new System.Drawing.Size(47, 17);
            this.radioHighConf.TabIndex = 23;
            this.radioHighConf.TabStop = true;
            this.radioHighConf.Text = "High";
            this.radioHighConf.UseVisualStyleBackColor = true;
            // 
            // radioMedConf
            // 
            this.radioMedConf.AutoSize = true;
            this.radioMedConf.Location = new System.Drawing.Point(588, 77);
            this.radioMedConf.Margin = new System.Windows.Forms.Padding(2);
            this.radioMedConf.Name = "radioMedConf";
            this.radioMedConf.Size = new System.Drawing.Size(62, 17);
            this.radioMedConf.TabIndex = 22;
            this.radioMedConf.TabStop = true;
            this.radioMedConf.Text = "Medium";
            this.radioMedConf.UseVisualStyleBackColor = true;
            // 
            // radioLowConf
            // 
            this.radioLowConf.AutoSize = true;
            this.radioLowConf.Location = new System.Drawing.Point(523, 77);
            this.radioLowConf.Margin = new System.Windows.Forms.Padding(2);
            this.radioLowConf.Name = "radioLowConf";
            this.radioLowConf.Size = new System.Drawing.Size(45, 17);
            this.radioLowConf.TabIndex = 21;
            this.radioLowConf.TabStop = true;
            this.radioLowConf.Text = "Low";
            this.radioLowConf.UseVisualStyleBackColor = true;
            // 
            // dgQuoteGrid
            // 
            this.dgQuoteGrid.AllowUserToAddRows = false;
            this.dgQuoteGrid.AllowUserToDeleteRows = false;
            this.dgQuoteGrid.AllowUserToResizeRows = false;
            this.dgQuoteGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgQuoteGrid.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgQuoteGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgQuoteGrid.Location = new System.Drawing.Point(16, 114);
            this.dgQuoteGrid.Margin = new System.Windows.Forms.Padding(2);
            this.dgQuoteGrid.Name = "dgQuoteGrid";
            this.dgQuoteGrid.ReadOnly = true;
            this.dgQuoteGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgQuoteGrid.RowTemplate.Height = 28;
            this.dgQuoteGrid.Size = new System.Drawing.Size(813, 347);
            this.dgQuoteGrid.TabIndex = 20;
            this.dgQuoteGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgQuoteGrid_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Comment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 52);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Customer";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(382, 77);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Confidence Level";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Part ID";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(412, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Description";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "WOR";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(473, 49);
            this.txtComment.Margin = new System.Windows.Forms.Padding(2);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(264, 20);
            this.txtComment.TabIndex = 13;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(101, 49);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.Size = new System.Drawing.Size(264, 20);
            this.txtCustomer.TabIndex = 12;
            // 
            // txtPartID
            // 
            this.txtPartID.Location = new System.Drawing.Point(101, 28);
            this.txtPartID.Margin = new System.Windows.Forms.Padding(2);
            this.txtPartID.Name = "txtPartID";
            this.txtPartID.Size = new System.Drawing.Size(264, 20);
            this.txtPartID.TabIndex = 11;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(473, 7);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(264, 20);
            this.txtDescription.TabIndex = 10;
            // 
            // txtWOR
            // 
            this.txtWOR.Location = new System.Drawing.Point(101, 7);
            this.txtWOR.Margin = new System.Windows.Forms.Padding(2);
            this.txtWOR.Name = "txtWOR";
            this.txtWOR.Size = new System.Drawing.Size(264, 20);
            this.txtWOR.TabIndex = 9;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(280, 78);
            this.btnClear.Margin = new System.Windows.Forms.Padding(2);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 26);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(102, 78);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 26);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(419, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Due Date";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dtDueDate
            // 
            this.dtDueDate.Location = new System.Drawing.Point(473, 28);
            this.dtDueDate.Name = "dtDueDate";
            this.dtDueDate.Size = new System.Drawing.Size(264, 20);
            this.dtDueDate.TabIndex = 26;
            // 
            // ckShowAll
            // 
            this.ckShowAll.AutoSize = true;
            this.ckShowAll.Location = new System.Drawing.Point(16, 84);
            this.ckShowAll.Name = "ckShowAll";
            this.ckShowAll.Size = new System.Drawing.Size(67, 17);
            this.ckShowAll.TabIndex = 27;
            this.ckShowAll.Text = "Show All";
            this.ckShowAll.UseVisualStyleBackColor = true;
            this.ckShowAll.CheckedChanged += new System.EventHandler(this.ckShowAll_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(191, 78);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(85, 26);
            this.btnUpdate.TabIndex = 28;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // ucAddEditQuote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.ckShowAll);
            this.Controls.Add(this.dtDueDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radioHighConf);
            this.Controls.Add(this.radioMedConf);
            this.Controls.Add(this.radioLowConf);
            this.Controls.Add(this.dgQuoteGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComment);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtPartID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtWOR);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAdd);
            this.Name = "ucAddEditQuote";
            this.Size = new System.Drawing.Size(845, 479);
            ((System.ComponentModel.ISupportInitialize)(this.dgQuoteGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioHighConf;
        private System.Windows.Forms.RadioButton radioMedConf;
        private System.Windows.Forms.RadioButton radioLowConf;
        private System.Windows.Forms.DataGridView dgQuoteGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtPartID;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtWOR;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtDueDate;
        private System.Windows.Forms.CheckBox ckShowAll;
        private System.Windows.Forms.Button btnUpdate;
    }
}
