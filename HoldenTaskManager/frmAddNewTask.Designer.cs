namespace HoldenTaskManager
{
    partial class frmAddNewTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddNewTask));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAddTask_Notes = new System.Windows.Forms.Label();
            this.lblAddTask_DueDate = new System.Windows.Forms.Label();
            this.lblAddTask_Employee = new System.Windows.Forms.Label();
            this.lblAddTask_Task = new System.Windows.Forms.Label();
            this.lblAddTask_JobNum = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.txtAddTask_Notes = new System.Windows.Forms.TextBox();
            this.dtpAddTask_DueDate = new System.Windows.Forms.DateTimePicker();
            this.icbAddTask_Employee = new IbisUtils.IbisComboBox();
            this.icbAddTask_Task = new IbisUtils.IbisComboBox();
            this.icbAddTask_JobNum = new IbisUtils.IbisComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblAddTask_Notes);
            this.panel1.Controls.Add(this.lblAddTask_DueDate);
            this.panel1.Controls.Add(this.lblAddTask_Employee);
            this.panel1.Controls.Add(this.lblAddTask_Task);
            this.panel1.Controls.Add(this.lblAddTask_JobNum);
            this.panel1.Controls.Add(this.btnAddTask);
            this.panel1.Controls.Add(this.txtAddTask_Notes);
            this.panel1.Controls.Add(this.dtpAddTask_DueDate);
            this.panel1.Controls.Add(this.icbAddTask_Employee);
            this.panel1.Controls.Add(this.icbAddTask_Task);
            this.panel1.Controls.Add(this.icbAddTask_JobNum);
            this.panel1.Location = new System.Drawing.Point(1, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 119);
            this.panel1.TabIndex = 17;
            // 
            // lblAddTask_Notes
            // 
            this.lblAddTask_Notes.AutoSize = true;
            this.lblAddTask_Notes.Location = new System.Drawing.Point(8, 60);
            this.lblAddTask_Notes.Name = "lblAddTask_Notes";
            this.lblAddTask_Notes.Size = new System.Drawing.Size(35, 13);
            this.lblAddTask_Notes.TabIndex = 13;
            this.lblAddTask_Notes.Text = "Notes";
            // 
            // lblAddTask_DueDate
            // 
            this.lblAddTask_DueDate.AutoSize = true;
            this.lblAddTask_DueDate.Location = new System.Drawing.Point(543, 13);
            this.lblAddTask_DueDate.Name = "lblAddTask_DueDate";
            this.lblAddTask_DueDate.Size = new System.Drawing.Size(64, 13);
            this.lblAddTask_DueDate.TabIndex = 12;
            this.lblAddTask_DueDate.Text = "Target Date";
            // 
            // lblAddTask_Employee
            // 
            this.lblAddTask_Employee.AutoSize = true;
            this.lblAddTask_Employee.Location = new System.Drawing.Point(343, 13);
            this.lblAddTask_Employee.Name = "lblAddTask_Employee";
            this.lblAddTask_Employee.Size = new System.Drawing.Size(53, 13);
            this.lblAddTask_Employee.TabIndex = 11;
            this.lblAddTask_Employee.Text = "Employee";
            // 
            // lblAddTask_Task
            // 
            this.lblAddTask_Task.AutoSize = true;
            this.lblAddTask_Task.Location = new System.Drawing.Point(143, 13);
            this.lblAddTask_Task.Name = "lblAddTask_Task";
            this.lblAddTask_Task.Size = new System.Drawing.Size(31, 13);
            this.lblAddTask_Task.TabIndex = 10;
            this.lblAddTask_Task.Text = "Task";
            // 
            // lblAddTask_JobNum
            // 
            this.lblAddTask_JobNum.AutoSize = true;
            this.lblAddTask_JobNum.Location = new System.Drawing.Point(9, 13);
            this.lblAddTask_JobNum.Name = "lblAddTask_JobNum";
            this.lblAddTask_JobNum.Size = new System.Drawing.Size(64, 13);
            this.lblAddTask_JobNum.TabIndex = 9;
            this.lblAddTask_JobNum.Text = "Job Number";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(630, 72);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(130, 26);
            this.btnAddTask.TabIndex = 8;
            this.btnAddTask.Text = "&Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // txtAddTask_Notes
            // 
            this.txtAddTask_Notes.Location = new System.Drawing.Point(9, 76);
            this.txtAddTask_Notes.Name = "txtAddTask_Notes";
            this.txtAddTask_Notes.Size = new System.Drawing.Size(598, 20);
            this.txtAddTask_Notes.TabIndex = 7;
            // 
            // dtpAddTask_DueDate
            // 
            this.dtpAddTask_DueDate.Location = new System.Drawing.Point(544, 30);
            this.dtpAddTask_DueDate.Name = "dtpAddTask_DueDate";
            this.dtpAddTask_DueDate.Size = new System.Drawing.Size(216, 20);
            this.dtpAddTask_DueDate.TabIndex = 6;
            // 
            // icbAddTask_Employee
            // 
            this.icbAddTask_Employee.FormattingEnabled = true;
            this.icbAddTask_Employee.Location = new System.Drawing.Point(344, 29);
            this.icbAddTask_Employee.Name = "icbAddTask_Employee";
            this.icbAddTask_Employee.Size = new System.Drawing.Size(194, 21);
            this.icbAddTask_Employee.srchdtxt = "";
            this.icbAddTask_Employee.TabIndex = 5;
            // 
            // icbAddTask_Task
            // 
            this.icbAddTask_Task.FormattingEnabled = true;
            this.icbAddTask_Task.Location = new System.Drawing.Point(144, 29);
            this.icbAddTask_Task.Name = "icbAddTask_Task";
            this.icbAddTask_Task.Size = new System.Drawing.Size(194, 21);
            this.icbAddTask_Task.srchdtxt = "";
            this.icbAddTask_Task.TabIndex = 4;
            // 
            // icbAddTask_JobNum
            // 
            this.icbAddTask_JobNum.FormattingEnabled = true;
            this.icbAddTask_JobNum.Location = new System.Drawing.Point(10, 29);
            this.icbAddTask_JobNum.Name = "icbAddTask_JobNum";
            this.icbAddTask_JobNum.Size = new System.Drawing.Size(128, 21);
            this.icbAddTask_JobNum.srchdtxt = "";
            this.icbAddTask_JobNum.TabIndex = 3;
            // 
            // frmAddNewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 125);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAddNewTask";
            this.Text = "Add New Task";
            this.Load += new System.EventHandler(this.frmAddNewTask_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAddTask_Notes;
        private System.Windows.Forms.Label lblAddTask_DueDate;
        private System.Windows.Forms.Label lblAddTask_Employee;
        private System.Windows.Forms.Label lblAddTask_Task;
        private System.Windows.Forms.Label lblAddTask_JobNum;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.TextBox txtAddTask_Notes;
        private System.Windows.Forms.DateTimePicker dtpAddTask_DueDate;
        private IbisUtils.IbisComboBox icbAddTask_Employee;
        private IbisUtils.IbisComboBox icbAddTask_Task;
        private IbisUtils.IbisComboBox icbAddTask_JobNum;

    }
}