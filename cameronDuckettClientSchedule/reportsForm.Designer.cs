namespace cameronDuckettClientSchedule
{
    partial class reportsForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnByMonth = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSchedule = new System.Windows.Forms.Button();
            this.btnCustCount = new System.Windows.Forms.Button();
            this.reportDGV = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reportDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(137, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(176, 37);
            this.label6.TabIndex = 23;
            this.label6.Text = "REPORTS";
            // 
            // btnByMonth
            // 
            this.btnByMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnByMonth.Location = new System.Drawing.Point(35, 163);
            this.btnByMonth.Name = "btnByMonth";
            this.btnByMonth.Size = new System.Drawing.Size(402, 38);
            this.btnByMonth.TabIndex = 24;
            this.btnByMonth.Text = "Appts by Month";
            this.btnByMonth.UseVisualStyleBackColor = true;
            this.btnByMonth.Click += new System.EventHandler(this.btnByMonth_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 37);
            this.label1.TabIndex = 25;
            this.label1.Text = "Select Report Below";
            // 
            // btnSchedule
            // 
            this.btnSchedule.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSchedule.Location = new System.Drawing.Point(35, 266);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(402, 38);
            this.btnSchedule.TabIndex = 26;
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.UseVisualStyleBackColor = true;
            this.btnSchedule.Click += new System.EventHandler(this.btnSchedule_Click);
            // 
            // btnCustCount
            // 
            this.btnCustCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustCount.Location = new System.Drawing.Point(35, 372);
            this.btnCustCount.Name = "btnCustCount";
            this.btnCustCount.Size = new System.Drawing.Size(429, 61);
            this.btnCustCount.TabIndex = 27;
            this.btnCustCount.Text = "Customer Count by Country";
            this.btnCustCount.UseVisualStyleBackColor = true;
            this.btnCustCount.Click += new System.EventHandler(this.btnCustCount_Click);
            // 
            // reportDGV
            // 
            this.reportDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportDGV.Location = new System.Drawing.Point(528, 32);
            this.reportDGV.Name = "reportDGV";
            this.reportDGV.RowHeadersWidth = 62;
            this.reportDGV.Size = new System.Drawing.Size(644, 484);
            this.reportDGV.TabIndex = 28;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(52, 498);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 38);
            this.button1.TabIndex = 29;
            this.button1.Text = "BACK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // reportsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 586);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.reportDGV);
            this.Controls.Add(this.btnCustCount);
            this.Controls.Add(this.btnSchedule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnByMonth);
            this.Controls.Add(this.label6);
            this.Name = "reportsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.reportsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reportDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnByMonth;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSchedule;
        private System.Windows.Forms.Button btnCustCount;
        private System.Windows.Forms.DataGridView reportDGV;
        private System.Windows.Forms.Button button1;
    }
}