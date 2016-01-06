using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Windows.Forms;
using IbisUtils;
using MySql.Data.MySqlClient;
using WindowsInstaller;

namespace HoldenTaskManager
{
    public partial class frmTaskCenter : Form
    {
        // make a list of task_ids keyed on row index.
        private static List<int> task_ids = new List<int>();
            
        public frmTaskCenter()
        {
            Ibis ibisobj = new Ibis();
            InitializeComponent();
            initTaskCenter(0);

            //string version = GetMsiInfo(Properties.Settings.Default.InstallDirectory +  @"\HoldenTaskManager.msi", "ProductVersion");
            //if(!version.Equals(Properties.Settings.Default.CurrentVersion))
            //{
            //    string inst_msg = "The current version of this software is " + Properties.Settings.Default.CurrentVersion +
            //        ".\nThere is a newer version (" + version + ") of this software available.\n" +
            //        "Would you like to install it now?";
            //    string caption = "New Version Available";
            //    DialogResult dr = MessageBox.Show(inst_msg, caption, MessageBoxButtons.YesNo);
            //    if (dr == DialogResult.Yes)
            //    {
            //        Properties.Settings.Default.CurrentVersion = version;
            //        Properties.Settings.Default.Save();
            //    }
            //}
        }

        private void initTaskCenter(int iter)
        {
            List<int> tasktype_ids = new List<int>();

            dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //
            // ADD JOB INFO COLUMNS SECTION
            //
            dgvTasks.Columns.Add("job_job_key", "Job Number");
            dgvTasks.Columns.Add("job_descr", "Project Name");
            dgvTasks.Columns.Add("job_city", "Town");
            dgvTasks.Columns.Add("job_addr1", "Location");
            dgvTasks.Columns.Add("job_due_date", "Due Date");
            dgvTasks.Columns[0].ReadOnly = true;
            dgvTasks.Columns[1].ReadOnly = true;
            dgvTasks.Columns[2].ReadOnly = true;
            dgvTasks.Columns[3].ReadOnly = true;
            dgvTasks.Columns[4].ReadOnly = true;
            dgvTasks.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTasks.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTasks.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTasks.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTasks.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvTasks.Columns[4].DefaultCellStyle.Format = "d";

            Ibis ibisobj = new Ibis();

            string sql = "SELECT employee_e_uname, employee_id FROM employee WHERE employee_active = 1 ORDER BY employee_e_uname ASC";
            MySqlDataAdapter da = new MySqlDataAdapter(sql, ibisobj.dbh);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRow blankrow = dt.NewRow();
            blankrow["employee_e_uname"] = "";
            blankrow["employee_id"] = 0;
            dt.Rows.InsertAt(blankrow, 0);

            //
            // SEE CURRENT OPEN TASKS SECTION INITIALIZATION
            //
            // get all open task types and add those columns to the datagridview.
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            cellStyle.BackColor = Color.LightGray;
            string sqlGetTT;
            if (chkOnlyShowUnfinishedTasks.Checked) // only show tasks which are active.
                sqlGetTT = "SELECT distinct task_type_id, ibis_tasktype_label FROM task, ibis_tasktype " +
                           "WHERE task_taskstatus_id = 1 AND ibis_tasktype_id = task_type_id ORDER BY task_type_id ASC";
            else // show all tasks.
                sqlGetTT = "SELECT distinct task_type_id, ibis_tasktype_label FROM task, ibis_tasktype " + 
                           "WHERE ibis_tasktype_id = task_type_id ORDER BY task_type_id ASC";

            DataTable dtTS = ibisobj.getDataTable(sqlGetTT);
            foreach (DataRow dataRow in dtTS.Rows)
            {
                dgvTasks.Columns.Add(
                    new DataGridViewCheckBoxColumn()
                    {
                        HeaderText = "",
                        Name = dataRow.Field<int>("task_type_id") + "_active",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                        TrueValue = "2",
                        FalseValue = "1",
                        ReadOnly = true
                    });
                dgvTasks.Columns.Add(
                    new CalendarColumn()
                    {
                        HeaderText = dataRow.Field<string>("ibis_tasktype_label"),
                        Name = dataRow.Field<int>("task_type_id") + "_duedate",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 100,
                        ReadOnly = true,
                        DefaultCellStyle = cellStyle
                    });
                dgvTasks.Columns.Add(
                    new DataGridViewComboBoxColumn()
                    {
                        HeaderText = "",
                        Name = dataRow.Field<int>("task_type_id") + "_employee",
                        AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                        Width = 110,
                        DataSource = dt.DefaultView,
                        DisplayMember = "employee_e_uname",
                        ValueMember = "employee_id",
                        DataPropertyName = "employee_id",
                        ReadOnly = true,
                        DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing,
                        DefaultCellStyle = cellStyle
                    });
            }

            string sqlGetJobInfo;
            if (chkOnlyShowUnfinishedTasks.Checked) // only show jobs with tasks which are active.
                sqlGetJobInfo = "SELECT job_job_key, job_descr, job_city, job_addr1, job_due_date, task.*, employee_e_uname FROM task " +
                                "LEFT JOIN job ON job_id = task_job_id LEFT JOIN employee ON employee_id = task_assignedemp " + 
                                "HAVING task.task_taskstatus_id = 1 ORDER BY job_job_key ASC";
            else // show all jobs with tasks.
                sqlGetJobInfo = "SELECT job_job_key, job_descr, job_city, job_addr1, job_due_date, task.*, employee_e_uname FROM task " +
                                "LEFT JOIN job ON job_id = task_job_id LEFT JOIN employee ON employee_id = task_assignedemp ORDER BY job_job_key ASC";
            DataTable dtJN = ibisobj.getDataTable(sqlGetJobInfo);

            string curr_jobkey = "0";
            DataGridViewCellStyle activeStyle = new DataGridViewCellStyle();
            activeStyle.BackColor = dgvTasks.DefaultCellStyle.BackColor;
            foreach (DataRow dataRow in dtJN.Rows)
            {
                int rowIndex = dgvTasks.Rows.Add();
                DataGridViewRow dgvRow = dgvTasks.Rows[rowIndex];

                // store the task_id in a tag for the context menu in the first column to use to edit and delete.
                ContextMenuStrip cmsTaskOptions = new ContextMenuStrip();
                ToolStripMenuItem tsmiEditNotes = new ToolStripMenuItem("Edit Notes", null, new EventHandler(tsmiEditNotes_Click));
                ToolStripMenuItem tsmiDeleteTask = new ToolStripMenuItem("Delete Task", null, new EventHandler(tsmiDeleteNotes_Click));
                ToolStripSeparator tss = new ToolStripSeparator();
                cmsTaskOptions.Items.Add(tsmiEditNotes);
                cmsTaskOptions.Items.Add(tss);
                cmsTaskOptions.Items.Add(tsmiDeleteTask);
                dgvRow.Cells[0].ContextMenuStrip = cmsTaskOptions;
                dgvRow.Cells[0].ContextMenuStrip.Tag = (int)dataRow.Field<uint>("task_id");

                if (curr_jobkey != dataRow.Field<string>("job_job_key"))
                {
                    dgvRow.Cells[0].Value = dataRow.Field<string>("job_job_key");
                    dgvRow.Cells[1].Value = dataRow.Field<string>("job_descr");
                    dgvRow.Cells[2].Value = dataRow.Field<string>("job_city");
                    dgvRow.Cells[3].Value = dataRow.Field<string>("job_addr1");
                    dgvRow.Cells[4].Value = dataRow.Field<DateTime>("job_due_date");
                    curr_jobkey = dataRow.Field<string>("job_job_key");
                }
                else
                {
                    dgvRow.Cells[0].Value = dataRow.Field<string>("job_job_key");
                    dgvRow.Cells[0].Style = new DataGridViewCellStyle() { ForeColor = Color.Transparent, SelectionForeColor = Color.Transparent };
                }
                task_ids.Add((int)dataRow.Field<uint>("task_id"));

                DataGridViewCheckBoxCell tmpchkcell = (DataGridViewCheckBoxCell)dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_active"];
                if (dataRow.Field<int>("task_taskstatus_id") == 1)
                {
                    tmpchkcell.Value = tmpchkcell.FalseValue;
                }
                else
                {
                    tmpchkcell.Value = tmpchkcell.TrueValue;
                }

                string tooltiptxtmsg = dataRow.Field<string>("job_job_key") + ": " + 
                                       dataRow.Field<string>("job_descr") +
                                       dataRow.Field<string>("job_city") +
                                       dataRow.Field<string>("job_addr1") + ": " +
                                       dataRow.Field<string>("task_notes");

                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_active"].ToolTipText = tooltiptxtmsg;
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_duedate"].Value = dataRow.Field<DateTime>("task_duedate");
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_duedate"].ToolTipText = tooltiptxtmsg;
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_employee"].ToolTipText = tooltiptxtmsg;

                // all of the columns are made default to readonly. we need to make
                // sure the cells with real information are editable.
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_active"].ReadOnly = false;
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_duedate"].ReadOnly = false;
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_employee"].ReadOnly = false;

                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_duedate"].Style = activeStyle;
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_duedate"].Style.Format = "d";
                dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_employee"].Style = activeStyle;

                DataGridViewComboBoxCell dgvcbx = (DataGridViewComboBoxCell)dgvRow.Cells[dataRow.Field<int>("task_type_id") + "_employee"];
                dgvcbx.Value = dataRow.Field<int>("task_assignedemp");
            }
        }

        private void tsmiDeleteNotes_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            frmDeleteTask f = new frmDeleteTask(tsmi.GetCurrentParent().Tag, this);
            f.ShowDialog();
        }

        private void tsmiEditNotes_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            frmEditTaskNotes f = new frmEditTaskNotes(tsmi.GetCurrentParent().Tag, this);
            f.ShowDialog();
        }

        public void resetForm()
        {
            dgvTasks.Rows.Clear();
            dgvTasks.Columns.Clear();
            dgvTasks.Refresh();
            task_ids.Clear();
            initTaskCenter(1);
        }

        private void dgvTasks_CurrentCellDirtyStateChanged_1(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                if (dgvTasks.IsCurrentCellDirty)
                {
                    Point celladdr = ((DataGridView)sender).CurrentCellAddress;
                    int colidx = celladdr.X;
                    int rowidx = celladdr.Y;
                    dgvTasks.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    //MessageBox.Show("current cell[" + colidx + ", " + rowidx + "] = "
                    //    + dgvTasks.CurrentCell.Value + " : " + dgvTasks.Columns[colidx].Name
                    //    + " : " + task_ids[rowidx]);

                    try
                    {
                        Ibis ibisobj = new Ibis();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = ibisobj.dbh;
                        
                        string tmpstr = dgvTasks.Columns[colidx].Name;
                        string db_col = tmpstr.Substring(tmpstr.IndexOf("_") + 1);

                        bool doqry = true;
                        if (db_col.Equals("active"))
                            cmd.CommandText = "UPDATE task SET task_taskstatus_id = @dataph WHERE task_id = @taskid";
                        else if (db_col.Equals("duedate"))
                            cmd.CommandText = "UPDATE task SET task_duedate = @dataph WHERE task_id = @taskid";
                        else if (db_col.Equals("employee"))
                            cmd.CommandText = "UPDATE task SET task_assignedemp = @dataph WHERE task_id = @taskid";
                        else
                        {
                            MessageBox.Show("db_col: " + db_col);
                            doqry = false;
                        }

                        cmd.Prepare();

                        cmd.Parameters.AddWithValue("@dataph", dgvTasks.CurrentCell.Value);
                        cmd.Parameters.AddWithValue("@taskid", task_ids[rowidx]);

                        if (doqry)
                            cmd.ExecuteNonQuery();
                    }
                    catch (MySqlException mysqle)
                    {
                        MessageBox.Show("mysql ERROR: " + mysqle.ToString());
                        return;
                    }
                    catch (Exception m2ex)
                    {
                        MessageBox.Show("M2_ERROR: " + m2ex.ToString());
                        return;
                    }

                    dgvTasks.CurrentCell.Selected = false;
                }

                if (chkOnlyShowUnfinishedTasks.Checked)
                    resetForm();
                else
                    dgvTasks.Refresh();
            }));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tsmiVersion_Click(object sender, EventArgs e)
        {
            Version appversion = Assembly.GetExecutingAssembly().GetName().Version;
            MessageBox.Show("Task Manager\nVersion " + appversion.Major + "." + appversion.Minor + 
                "\nBuild # " + appversion.Build + "\nRevision # " + appversion.Revision);
        }

        private void btnReportsMenu_Click(object sender, EventArgs e)
        {
            frmReportsMenu f = (frmReportsMenu)Application.OpenForms["frmReportsMenu"];
            if (f != null)
                f.BringToFront();
            else
            {
                frmReportsMenu frmRpts = new frmReportsMenu();
                frmRpts.Show();
            }
        }

        private void chkOnlyShowUnfinishedTasks_CheckedChanged(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            chkOnlyShowUnfinishedTasks.Checked = !chkOnlyShowUnfinishedTasks.Checked;
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            frmAddNewTask f = new frmAddNewTask(this);
            f.ShowDialog();
        }

        private void dgvTasks_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewCell clickedCell = (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex];
                    this.dgvTasks.CurrentCell = clickedCell;
                }
            }
        }

        public static string GetMsiInfo(string msiPath, string Info)
        {
            //string retVal = string.Empty;

            //Type classType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            //Object installerObj = Activator.CreateInstance(classType);
            //Installer installer = installerObj as Installer;

            //// Open msi file
            //Database db = installer.OpenDatabase(msiPath, 0);

            //// Fetch the property
            //string sql = String.Format("SELECT Value FROM Property WHERE Property='{0}'", Info);
            //WindowsInstaller.View view = db.OpenView(sql);
            //view.Execute(null);

            //// Read in the record
            //Record rec = view.Fetch();
            //if (rec != null)
            //    retVal = rec.get_StringData(1);

            //return retVal;
            return "";
        }

        private Bitmap bmp;
        private void btnPrintDGV_Click(object sender, EventArgs e)
        {
            dgvTasks.ScrollBars = ScrollBars.None;
            int height = dgvTasks.Height;
            int width = this.dgvTasks.Width;
            dgvTasks.Height = (dgvTasks.RowCount + 2) * dgvTasks.RowTemplate.Height;
            int tmpwidth = 0;
            foreach (DataGridViewColumn dcol in dgvTasks.Columns)
            {
                tmpwidth += dcol.Width;
            }
            dgvTasks.Width = tmpwidth;

            bmp = new Bitmap(this.dgvTasks.Width, this.dgvTasks.Height);
            dgvTasks.DrawToBitmap(bmp, new Rectangle(0, 0, this.dgvTasks.Width, this.dgvTasks.Height));

            dgvTasks.Height = height;
            dgvTasks.Width = width;
            dgvTasks.ScrollBars = ScrollBars.Both;

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Bitmap Image|*.bmp"; 
            dialog.DefaultExt = "bmp";
            dialog.AddExtension = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                bmp.Save(dialog.FileName, ImageFormat.Bmp);
            }

            //printPreviewDialog1.Document = printDocument1;
            //printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
