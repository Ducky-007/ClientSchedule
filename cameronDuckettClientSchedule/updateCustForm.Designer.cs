namespace cameronDuckettClientSchedule
{
    partial class updateCustForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.currName = new System.Windows.Forms.Label();
            this.currAddress = new System.Windows.Forms.Label();
            this.currCity = new System.Windows.Forms.Label();
            this.currZip = new System.Windows.Forms.Label();
            this.CurrPhoneNum = new System.Windows.Forms.Label();
            this.custCurrInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(184, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "UPDATE CUSTOMER FORM";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "City:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Zip Code:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Phone Number:";
            // 
            // currName
            // 
            this.currName.AutoSize = true;
            this.currName.Location = new System.Drawing.Point(163, 116);
            this.currName.Name = "currName";
            this.currName.Size = new System.Drawing.Size(72, 13);
            this.currName.TabIndex = 6;
            this.currName.Text = "Current Name";
            // 
            // currAddress
            // 
            this.currAddress.AutoSize = true;
            this.currAddress.Location = new System.Drawing.Point(163, 146);
            this.currAddress.Name = "currAddress";
            this.currAddress.Size = new System.Drawing.Size(82, 13);
            this.currAddress.TabIndex = 7;
            this.currAddress.Text = "Current Address";
            // 
            // currCity
            // 
            this.currCity.AutoSize = true;
            this.currCity.Location = new System.Drawing.Point(163, 178);
            this.currCity.Name = "currCity";
            this.currCity.Size = new System.Drawing.Size(61, 13);
            this.currCity.TabIndex = 8;
            this.currCity.Text = "Current City";
            // 
            // currZip
            // 
            this.currZip.AutoSize = true;
            this.currZip.Location = new System.Drawing.Point(163, 209);
            this.currZip.Name = "currZip";
            this.currZip.Size = new System.Drawing.Size(87, 13);
            this.currZip.TabIndex = 9;
            this.currZip.Text = "Current Zip Code";
            // 
            // CurrPhoneNum
            // 
            this.CurrPhoneNum.AutoSize = true;
            this.CurrPhoneNum.Location = new System.Drawing.Point(163, 239);
            this.CurrPhoneNum.Name = "CurrPhoneNum";
            this.CurrPhoneNum.Size = new System.Drawing.Size(115, 13);
            this.CurrPhoneNum.TabIndex = 10;
            this.CurrPhoneNum.Text = "Current Phone Number";
            // 
            // custCurrInfo
            // 
            this.custCurrInfo.AutoSize = true;
            this.custCurrInfo.Location = new System.Drawing.Point(55, 80);
            this.custCurrInfo.Name = "custCurrInfo";
            this.custCurrInfo.Size = new System.Drawing.Size(85, 13);
            this.custCurrInfo.TabIndex = 11;
            this.custCurrInfo.Text = "Current Info Title";
            this.custCurrInfo.Click += new System.EventHandler(this.custCurrInfo_Click);
            // 
            // updateCustForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.custCurrInfo);
            this.Controls.Add(this.CurrPhoneNum);
            this.Controls.Add(this.currZip);
            this.Controls.Add(this.currCity);
            this.Controls.Add(this.currAddress);
            this.Controls.Add(this.currName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "updateCustForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.updateCustForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currName;
        private System.Windows.Forms.Label currAddress;
        private System.Windows.Forms.Label currCity;
        private System.Windows.Forms.Label currZip;
        private System.Windows.Forms.Label CurrPhoneNum;
        private System.Windows.Forms.Label custCurrInfo;
    }
}