using System;
using System.Data;
using System.Windows.Forms;
using IbisUtils;
using MySql.Data.MySqlClient;

namespace HoldenTaskManager
{
    public partial class frmEditTaskNotes : Form
    {
        public int TaskID { get; set; }
        public frmTaskCenter Mommy { get; set; }

        public frmEditTaskNotes()
        {
            InitializeComponent();
        }

        public frmEditTaskNotes(object p, object q)
        {
            InitializeComponent();

            TaskID = (int)p;
            Mommy = (frmTaskCenter)q;

            string sqlGetTaskInfo = "SELECT job_job_key, job_descr, job_city, job_addr1, job_due_date, task.*, " + 
                                    "employee_e_uname, ibis_tasktype_label FROM task " +
                                    "LEFT JOIN job ON job_id = task_job_id LEFT JOIN employee ON employee_id = task_assignedemp " +
                                    "LEFT JOIN ibis_tasktype ON ibis_tasktype_id = task_type_id " +
                                    "HAVING task.task_id = " + TaskID;

            Ibis ibisobj = new Ibis();
            try
            {
                DataTable dtTI = ibisobj.getDataTable(sqlGetTaskInfo);
                DataRow dr = dtTI.Rows[0];

                lblJNval.Text = dr.Field<string>("job_job_key");
                lblPNval.Text = dr.Field<string>("job_descr");
                lblTNval.Text = dr.Field<string>("job_city");
                lblLNval.Text = dr.Field<string>("job_addr1");
                lblDDval.Text = dr.Field<DateTime>("job_due_date").ToShortDateString();
                lblTKval.Text = dr.Field<string>("ibis_tasktype_label");
                lblAEval.Text = dr.Field<string>("employee_e_uname");
                lblTDDval.Text = dr.Field<DateTime>("task_duedate").ToShortDateString();

                txtEditTask_Notes.Text = dr.Field<string>("task_notes");
            }
            catch (MySqlException mysqle)
            {
                MessageBox.Show("mysql ERROR: " + mysqle.ToString());
                return;
            }
        }

        private void btnSubmitTaskNotesChanges_Click(object sender, EventArgs e)
        {
            Ibis ibisobj = new Ibis();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = ibisobj.dbh;
                cmd.CommandText = "UPDATE task SET task_notes = @task_notes WHERE task_id = @task_id";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@task_notes", txtEditTask_Notes.Text);
                cmd.Parameters.AddWithValue("@task_id", TaskID);

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
                MessageBox.Show("Notes for task successfully changed.");
                Mommy.resetForm();
            }
        }

        private void btnExitEditTaskNotes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
