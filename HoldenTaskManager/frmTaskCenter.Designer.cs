namespace HoldenTaskManager
{
    partial class frmTaskCenter
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaskCenter));
            this.btnExit = new System.Windows.Forms.Button();
            this.chkOnlyShowUnfinishedTasks = new System.Windows.Forms.CheckBox();
            this.btnReportsMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.btnPrintDGV = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Image = ((System.Drawing.Image)(resources.GetObject("btnExit.Image")));
            this.btnExit.Location = new System.Drawing.Point(951, 333);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(50, 50);
            this.btnExit.TabIndex = 14;
            this.toolTip1.SetToolTip(this.btnExit, "Close Application");
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // chkOnlyShowUnfinishedTasks
            // 
            this.chkOnlyShowUnfinishedTasks.AutoSize = true;
            this.chkOnlyShowUnfinishedTasks.Location = new System.Drawing.Point(656, 438);
            this.chkOnlyShowUnfinishedTasks.Name = "chkOnlyShowUnfinishedTasks";
            this.chkOnlyShowUnfinishedTasks.Size = new System.Drawing.Size(157, 17);
            this.chkOnlyShowUnfinishedTasks.TabIndex = 16;
            this.chkOnlyShowUnfinishedTasks.Text = "Only show unfinished tasks.";
            this.chkOnlyShowUnfinishedTasks.UseVisualStyleBackColor = true;
            this.chkOnlyShowUnfinishedTasks.Visible = false;
            this.chkOnlyShowUnfinishedTasks.CheckedChanged += new System.EventHandler(this.chkOnlyShowUnfinishedTasks_CheckedChanged);
            // 
            // btnReportsMenu
            // 
            this.btnReportsMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportsMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnReportsMenu.Image")));
            this.btnReportsMenu.Location = new System.Drawing.Point(951, 165);
            this.btnReportsMenu.Name = "btnReportsMenu";
            this.btnReportsMenu.Size = new System.Drawing.Size(50, 50);
            this.btnReportsMenu.TabIndex = 15;
            this.toolTip1.SetToolTip(this.btnReportsMenu, "Open Reports Menu");
            this.btnReportsMenu.UseVisualStyleBackColor = true;
            this.btnReportsMenu.Click += new System.EventHandler(this.btnReportsMenu_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Imprint MT Shadow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 19);
            this.label1.TabIndex = 17;
            this.label1.Text = "Task Control && Notification Center";
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTasks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Location = new System.Drawing.Point(15, 53);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.Size = new System.Drawing.Size(930, 379);
            this.dgvTasks.TabIndex = 16;
            this.dgvTasks.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvTasks_CellMouseDown);
            this.dgvTasks.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvTasks_CurrentCellDirtyStateChanged_1);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(951, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 50);
            this.btnRefresh.TabIndex = 18;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.Location = new System.Drawing.Point(951, 221);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(50, 50);
            this.btnFilter.TabIndex = 19;
            this.toolTip1.SetToolTip(this.btnFilter, "Toggle displaying only finished tasks.");
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNewTask.Image")));
            this.btnAddNewTask.Location = new System.Drawing.Point(951, 109);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(50, 50);
            this.btnAddNewTask.TabIndex = 20;
            this.toolTip1.SetToolTip(this.btnAddNewTask, "Add New Task");
            this.btnAddNewTask.UseVisualStyleBackColor = true;
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // btnPrintDGV
            // 
            this.btnPrintDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintDGV.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintDGV.Image")));
            this.btnPrintDGV.Location = new System.Drawing.Point(951, 277);
            this.btnPrintDGV.Name = "btnPrintDGV";
            this.btnPrintDGV.Size = new System.Drawing.Size(50, 50);
            this.btnPrintDGV.TabIndex = 21;
            this.toolTip1.SetToolTip(this.btnPrintDGV, "Print Task Control & Notification Center");
            this.btnPrintDGV.UseVisualStyleBackColor = true;
            this.btnPrintDGV.Click += new System.EventHandler(this.btnPrintDGV_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmTaskCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 462);
            this.Controls.Add(this.btnPrintDGV);
            this.Controls.Add(this.btnAddNewTask);
            this.Controls.Add(this.chkOnlyShowUnfinishedTasks);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnReportsMenu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTasks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaskCenter";
            this.Text = "Holden Engineering & Surveying Task Management Center";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.Button btnReportsMenu;
        private System.Windows.Forms.CheckBox chkOnlyShowUnfinishedTasks;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnAddNewTask;
        private System.Windows.Forms.Button btnPrintDGV;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}

