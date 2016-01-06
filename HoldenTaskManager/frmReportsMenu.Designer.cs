namespace HoldenTaskManager
{
    partial class frmReportsMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportsMenu));
            this.btnRptbyJobNum = new System.Windows.Forms.Button();
            this.btnRptbyEmployee = new System.Windows.Forms.Button();
            this.btnRptbyTaskType = new System.Windows.Forms.Button();
            this.btnOpenJobsReport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRptbyJobNum
            // 
            this.btnRptbyJobNum.Location = new System.Drawing.Point(12, 12);
            this.btnRptbyJobNum.Name = "btnRptbyJobNum";
            this.btnRptbyJobNum.Size = new System.Drawing.Size(221, 41);
            this.btnRptbyJobNum.TabIndex = 16;
            this.btnRptbyJobNum.Text = "&Open Tasks Report by Job";
            this.btnRptbyJobNum.UseVisualStyleBackColor = true;
            this.btnRptbyJobNum.Click += new System.EventHandler(this.btnRptbyJobNum_Click);
            // 
            // btnRptbyEmployee
            // 
            this.btnRptbyEmployee.Location = new System.Drawing.Point(12, 78);
            this.btnRptbyEmployee.Name = "btnRptbyEmployee";
            this.btnRptbyEmployee.Size = new System.Drawing.Size(221, 41);
            this.btnRptbyEmployee.TabIndex = 17;
            this.btnRptbyEmployee.Text = "Open Tasks Report by &Employee";
            this.btnRptbyEmployee.UseVisualStyleBackColor = true;
            this.btnRptbyEmployee.Click += new System.EventHandler(this.btnRptbyEmployee_Click);
            // 
            // btnRptbyTaskType
            // 
            this.btnRptbyTaskType.Location = new System.Drawing.Point(12, 144);
            this.btnRptbyTaskType.Name = "btnRptbyTaskType";
            this.btnRptbyTaskType.Size = new System.Drawing.Size(221, 41);
            this.btnRptbyTaskType.TabIndex = 18;
            this.btnRptbyTaskType.Text = "&Open Tasks Report by Task &Type";
            this.btnRptbyTaskType.UseVisualStyleBackColor = true;
            this.btnRptbyTaskType.Click += new System.EventHandler(this.btnRptbyTaskType_Click);
            // 
            // btnOpenJobsReport
            // 
            this.btnOpenJobsReport.Location = new System.Drawing.Point(12, 209);
            this.btnOpenJobsReport.Name = "btnOpenJobsReport";
            this.btnOpenJobsReport.Size = new System.Drawing.Size(221, 41);
            this.btnOpenJobsReport.TabIndex = 19;
            this.btnOpenJobsReport.Text = "&List Open Jobs";
            this.btnOpenJobsReport.UseVisualStyleBackColor = true;
            this.btnOpenJobsReport.Click += new System.EventHandler(this.btnOpenJobsReport_Click);
            // 
            // frmReportsMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 264);
            this.Controls.Add(this.btnOpenJobsReport);
            this.Controls.Add(this.btnRptbyTaskType);
            this.Controls.Add(this.btnRptbyEmployee);
            this.Controls.Add(this.btnRptbyJobNum);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmReportsMenu";
            this.Text = "Reports Center";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRptbyJobNum;
        private System.Windows.Forms.Button btnRptbyEmployee;
        private System.Windows.Forms.Button btnRptbyTaskType;
        private System.Windows.Forms.Button btnOpenJobsReport;
    }
}