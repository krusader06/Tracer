namespace Tracer.Forms.Views.Engineering
{
    partial class formAddWOR
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtWORLot = new System.Windows.Forms.Label();
            this.ckParts = new System.Windows.Forms.CheckBox();
            this.ckPCBs = new System.Windows.Forms.CheckBox();
            this.ckStencils = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job Number:";
            // 
            // txtWORLot
            // 
            this.txtWORLot.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtWORLot.AutoSize = true;
            this.txtWORLot.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWORLot.Location = new System.Drawing.Point(235, 9);
            this.txtWORLot.Name = "txtWORLot";
            this.txtWORLot.Size = new System.Drawing.Size(142, 31);
            this.txtWORLot.TabIndex = 1;
            this.txtWORLot.Text = "1801001/1";
            // 
            // ckParts
            // 
            this.ckParts.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckParts.AutoSize = true;
            this.ckParts.Location = new System.Drawing.Point(118, 89);
            this.ckParts.Name = "ckParts";
            this.ckParts.Size = new System.Drawing.Size(50, 17);
            this.ckParts.TabIndex = 2;
            this.ckParts.Text = "Parts";
            this.ckParts.UseVisualStyleBackColor = true;
            // 
            // ckPCBs
            // 
            this.ckPCBs.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckPCBs.AutoSize = true;
            this.ckPCBs.Location = new System.Drawing.Point(193, 89);
            this.ckPCBs.Name = "ckPCBs";
            this.ckPCBs.Size = new System.Drawing.Size(52, 17);
            this.ckPCBs.TabIndex = 3;
            this.ckPCBs.Text = "PCBs";
            this.ckPCBs.UseVisualStyleBackColor = true;
            // 
            // ckStencils
            // 
            this.ckStencils.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ckStencils.AutoSize = true;
            this.ckStencils.Location = new System.Drawing.Point(264, 89);
            this.ckStencils.Name = "ckStencils";
            this.ckStencils.Size = new System.Drawing.Size(63, 17);
            this.ckStencils.TabIndex = 4;
            this.ckStencils.Text = "Stencils";
            this.ckStencils.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(162, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Need To Order:";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Location = new System.Drawing.Point(41, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(160, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(225, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(160, 32);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // formAddWOR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(430, 172);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ckStencils);
            this.Controls.Add(this.ckPCBs);
            this.Controls.Add(this.ckParts);
            this.Controls.Add(this.txtWORLot);
            this.Controls.Add(this.label1);
            this.Name = "formAddWOR";
            this.Text = "Release Work Order";
            this.Load += new System.EventHandler(this.formAddWOR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtWORLot;
        private System.Windows.Forms.CheckBox ckParts;
        private System.Windows.Forms.CheckBox ckPCBs;
        private System.Windows.Forms.CheckBox ckStencils;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}