using System;
using System.Data;
using System.Windows.Forms;
using IbisUtils;
using MySql.Data.MySqlClient;

namespace HoldenTaskManager
{
    public partial class frmAddNewTask : Form
    {
        public frmTaskCenter Mommy { get; set; }

        public frmAddNewTask()
        {
            InitializeComponent();
        }

        public frmAddNewTask(object q)
        {
            InitializeComponent();
            Mommy = (frmTaskCenter)q;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string task_cols = "task_job_id, task_type_id, task_taskstatus_id, task_notes, task_assignedemp, task_duedate";
            string task_params = "@job_id, @type_id, @taskstatus_id, @notes, @assignedemp, @duedate";
            Ibis ibisobj = new Ibis();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ibisobj.dbh;
                cmd.CommandText = "INSERT INTO task (" + task_cols + ") VALUES (" + task_params + ")";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@job_id", icbAddTask_JobNum.SelectedValue);
                cmd.Parameters.AddWithValue("@type_id", icbAddTask_Task.SelectedValue);
                cmd.Parameters.AddWithValue("@taskstatus_id", 1);
                cmd.Parameters.AddWithValue("@notes", txtAddTask_Notes.Text);
                cmd.Parameters.AddWithValue("@assignedemp", icbAddTask_Employee.SelectedValue);
                cmd.Parameters.AddWithValue("@duedate", dtpAddTask_DueDate.Value);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException mysqle)
            {
                MessageBox.Show("mysql ERROR: " + mysqle.ToString());
                return;
            }
            catch (Exception m1ex)
            {
                MessageBox.Show("M1_ERROR: " + m1ex.ToString());
                return;
            }
            finally
            {
                MessageBox.Show("New task successfully created.");
                icbAddTask_JobNum.SelectedIndex = 0;
                icbAddTask_Task.SelectedIndex = 0;
                icbAddTask_Employee.SelectedIndex = 0;
                dtpAddTask_DueDate.ResetText();
                txtAddTask_Notes.Text = "";
                Mommy.resetForm();
            }

            this.Close();
        }

        private void frmAddNewTask_Load(object sender, EventArgs e)
        {
            Ibis ibisobj = new Ibis();

            // initialize job numbers combobox.
            string sql = "SELECT job_job_key, job_id FROM job WHERE job_status = 'A' OR job_status = 'P' OR job_status = 1 ORDER BY job_job_key ASC";
            DataTable dtInitJNCmbBx = ibisobj.getDataTable(sql);
            icbAddTask_JobNum.Initialize(dtInitJNCmbBx, "job_job_key", "job_id");

            // initialize tasks combobox.
            sql = "SELECT ibis_tasktype_label, ibis_tasktype_id FROM ibis_tasktype ORDER BY ibis_tasktype_label ASC";
            DataTable dtInitTTCmbBx = ibisobj.getDataTable(sql);
            icbAddTask_Task.Initialize(dtInitTTCmbBx, "ibis_tasktype_label", "ibis_tasktype_id");

            // initialize employee combobox.
            sql = "SELECT employee_e_uname, employee_id FROM employee WHERE employee_active = 1 ORDER BY employee_e_uname ASC";
            DataTable dtInitEMCmbBx = ibisobj.getDataTable(sql);
            icbAddTask_Employee.Initialize(dtInitEMCmbBx, "employee_e_uname", "employee_id");
        }
    }
}
