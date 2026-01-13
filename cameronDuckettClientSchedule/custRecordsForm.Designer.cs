namespace cameronDuckettClientSchedule
{
    partial class custRecordsForm
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
            this.addCustBtn = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.cityLabel = new System.Windows.Forms.Label();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.zipCodeLabel = new System.Windows.Forms.Label();
            this.zipCodeTextBox = new System.Windows.Forms.TextBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.countryTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumLabel = new System.Windows.Forms.Label();
            this.phoneNumTextBox = new System.Windows.Forms.TextBox();
            this.deleteCustBtn = new System.Windows.Forms.Button();
            this.custDelTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.custUpdateTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.addAppointBtn = new System.Windows.Forms.Button();
            this.updateAppointBtn = new System.Windows.Forms.Button();
            this.delAppointBtn = new System.Windows.Forms.Button();
            this.titleToUpdate = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.nameToUpdate = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // addCustBtn
            // 
            this.addCustBtn.Location = new System.Drawing.Point(152, 351);
            this.addCustBtn.Margin = new System.Windows.Forms.Padding(2);
            this.addCustBtn.Name = "addCustBtn";
            this.addCustBtn.Size = new System.Drawing.Size(93, 23);
            this.addCustBtn.TabIndex = 0;
            this.addCustBtn.Text = "Add Customer";
            this.addCustBtn.UseVisualStyleBackColor = true;
            this.addCustBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(128, 109);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(133, 20);
            this.nameTextBox.TabIndex = 1;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Location = new System.Drawing.Point(48, 111);
            this.nameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Name:";
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(48, 161);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(48, 13);
            this.addressLabel.TabIndex = 3;
            this.addressLabel.Text = "Address:";
            this.addressLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(128, 161);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(133, 20);
            this.addressTextBox.TabIndex = 4;
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(56, 207);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 5;
            this.cityLabel.Text = "City:";
            this.cityLabel.Click += new System.EventHandler(this.cityLabel_Click);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(128, 205);
            this.cityTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(133, 20);
            this.cityTextBox.TabIndex = 6;
            // 
            // zipCodeLabel
            // 
            this.zipCodeLabel.AutoSize = true;
            this.zipCodeLabel.Location = new System.Drawing.Point(48, 244);
            this.zipCodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zipCodeLabel.Name = "zipCodeLabel";
            this.zipCodeLabel.Size = new System.Drawing.Size(53, 13);
            this.zipCodeLabel.TabIndex = 7;
            this.zipCodeLabel.Text = "Zip Code:";
            // 
            // zipCodeTextBox
            // 
            this.zipCodeTextBox.Location = new System.Drawing.Point(128, 244);
            this.zipCodeTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.zipCodeTextBox.Name = "zipCodeTextBox";
            this.zipCodeTextBox.Size = new System.Drawing.Size(133, 20);
            this.zipCodeTextBox.TabIndex = 8;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(48, 283);
            this.countryLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(46, 13);
            this.countryLabel.TabIndex = 9;
            this.countryLabel.Text = "Country:";
            // 
            // countryTextBox
            // 
            this.countryTextBox.Location = new System.Drawing.Point(128, 281);
            this.countryTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.countryTextBox.Name = "countryTextBox";
            this.countryTextBox.Size = new System.Drawing.Size(133, 20);
            this.countryTextBox.TabIndex = 10;
            // 
            // phoneNumLabel
            // 
            this.phoneNumLabel.AutoSize = true;
            this.phoneNumLabel.Location = new System.Drawing.Point(33, 319);
            this.phoneNumLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.phoneNumLabel.Name = "phoneNumLabel";
            this.phoneNumLabel.Size = new System.Drawing.Size(81, 13);
            this.phoneNumLabel.TabIndex = 11;
            this.phoneNumLabel.Text = "Phone Number:";
            // 
            // phoneNumTextBox
            // 
            this.phoneNumTextBox.Location = new System.Drawing.Point(128, 319);
            this.phoneNumTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.phoneNumTextBox.Name = "phoneNumTextBox";
            this.phoneNumTextBox.Size = new System.Drawing.Size(133, 20);
            this.phoneNumTextBox.TabIndex = 12;
            // 
            // deleteCustBtn
            // 
            this.deleteCustBtn.Location = new System.Drawing.Point(358, 201);
            this.deleteCustBtn.Name = "deleteCustBtn";
            this.deleteCustBtn.Size = new System.Drawing.Size(115, 23);
            this.deleteCustBtn.TabIndex = 13;
            this.deleteCustBtn.Text = "Delete Customer";
            this.deleteCustBtn.UseVisualStyleBackColor = true;
            this.deleteCustBtn.Click += new System.EventHandler(this.deleteCustBtn_Click);
            // 
            // custDelTextBox
            // 
            this.custDelTextBox.Location = new System.Drawing.Point(426, 164);
            this.custDelTextBox.Name = "custDelTextBox";
            this.custDelTextBox.Size = new System.Drawing.Size(134, 20);
            this.custDelTextBox.TabIndex = 14;
            this.custDelTextBox.TextChanged += new System.EventHandler(this.custDelTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Customer Name to Delete:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(158, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "CUSTOMER FORM";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(307, 253);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 24);
            this.label3.TabIndex = 17;
            this.label3.Text = "UPDATE CUSTOMER";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(307, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(211, 24);
            this.label4.TabIndex = 18;
            this.label4.Text = "DELETE CUSTOMER";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 298);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Customer Name to Update:";
            // 
            // custUpdateTextBox
            // 
            this.custUpdateTextBox.Location = new System.Drawing.Point(426, 293);
            this.custUpdateTextBox.Name = "custUpdateTextBox";
            this.custUpdateTextBox.Size = new System.Drawing.Size(134, 20);
            this.custUpdateTextBox.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(358, 333);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 30);
            this.button1.TabIndex = 21;
            this.button1.Text = "Update Customer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(767, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 25);
            this.label6.TabIndex = 22;
            this.label6.Text = "Appointments";
            // 
            // addAppointBtn
            // 
            this.addAppointBtn.Location = new System.Drawing.Point(1081, 405);
            this.addAppointBtn.Name = "addAppointBtn";
            this.addAppointBtn.Size = new System.Drawing.Size(150, 34);
            this.addAppointBtn.TabIndex = 23;
            this.addAppointBtn.Text = "ADD APPOINTMENT";
            this.addAppointBtn.UseVisualStyleBackColor = true;
            this.addAppointBtn.Click += new System.EventHandler(this.addAppointBtn_Click);
            // 
            // updateAppointBtn
            // 
            this.updateAppointBtn.Location = new System.Drawing.Point(1081, 598);
            this.updateAppointBtn.Name = "updateAppointBtn";
            this.updateAppointBtn.Size = new System.Drawing.Size(150, 34);
            this.updateAppointBtn.TabIndex = 24;
            this.updateAppointBtn.Text = "UPDATE APPOINTMENT";
            this.updateAppointBtn.UseVisualStyleBackColor = true;
            this.updateAppointBtn.Click += new System.EventHandler(this.updateAppointBtn_Click);
            // 
            // delAppointBtn
            // 
            this.delAppointBtn.Location = new System.Drawing.Point(1081, 454);
            this.delAppointBtn.Name = "delAppointBtn";
            this.delAppointBtn.Size = new System.Drawing.Size(150, 34);
            this.delAppointBtn.TabIndex = 25;
            this.delAppointBtn.Text = "DELETE APPOINTMENT";
            this.delAppointBtn.UseVisualStyleBackColor = true;
            this.delAppointBtn.Click += new System.EventHandler(this.delAppointBtn_Click);
            // 
            // titleToUpdate
            // 
            this.titleToUpdate.Location = new System.Drawing.Point(1081, 550);
            this.titleToUpdate.Name = "titleToUpdate";
            this.titleToUpdate.Size = new System.Drawing.Size(146, 20);
            this.titleToUpdate.TabIndex = 29;
            this.titleToUpdate.TextChanged += new System.EventHandler(this.titleToUpdate_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(926, 552);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "Appointment Title to UPDATE:";
            // 
            // nameToUpdate
            // 
            this.nameToUpdate.Location = new System.Drawing.Point(1081, 500);
            this.nameToUpdate.Name = "nameToUpdate";
            this.nameToUpdate.Size = new System.Drawing.Size(146, 20);
            this.nameToUpdate.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(914, 490);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(155, 13);
            this.label12.TabIndex = 26;
            this.label12.Text = "Customer Name of appointment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(961, 514);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "to UPDATE:";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(653, 436);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 31;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(653, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(574, 311);
            this.dataGridView1.TabIndex = 32;
            // 
            // custRecordsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 725);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.titleToUpdate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.nameToUpdate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.delAppointBtn);
            this.Controls.Add(this.updateAppointBtn);
            this.Controls.Add(this.addAppointBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.custUpdateTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.custDelTextBox);
            this.Controls.Add(this.deleteCustBtn);
            this.Controls.Add(this.phoneNumTextBox);
            this.Controls.Add(this.phoneNumLabel);
            this.Controls.Add(this.countryTextBox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.zipCodeTextBox);
            this.Controls.Add(this.zipCodeLabel);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.addCustBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "custRecordsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.custRecordsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addCustBtn;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label zipCodeLabel;
        private System.Windows.Forms.TextBox zipCodeTextBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.TextBox countryTextBox;
        private System.Windows.Forms.Label phoneNumLabel;
        private System.Windows.Forms.TextBox phoneNumTextBox;
        private System.Windows.Forms.Button deleteCustBtn;
        private System.Windows.Forms.TextBox custDelTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox custUpdateTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addAppointBtn;
        private System.Windows.Forms.Button updateAppointBtn;
        private System.Windows.Forms.Button delAppointBtn;
        private System.Windows.Forms.TextBox titleToUpdate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox nameToUpdate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}