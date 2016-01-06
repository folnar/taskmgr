using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using MySql.Data.MySqlClient;
using IbisUtils;

namespace HoldenTaskManager
{
    public partial class frmReportTemplate : Form
    {
        public string IbisReportType { get; set; }

        private Dictionary<string, string> ReportTemplates = new Dictionary<string, string>
        {
            { "byjob", "tasks_byjob" },
            { "byemp", "tasks_byemp" },
            { "bytt", "tasks_bytasktype" },
            { "openjobs", "openjobslist"}
        };

        public frmReportTemplate()
        {
            InitializeComponent();
        }

        private void frmReportTemplate_Load(object sender, EventArgs e)
        {
            _populateReport();
        }

        private void _populateReport()
        {
            try
            {
                Ibis ibisobj = new Ibis();
                string sql = "SELECT job_job_key, job_descr, job_city, job_addr1, task.*, " + 
                             "job_due_date, employee_e_uname, ibis_tasktype_label, job_pname FROM task " +
                             "LEFT JOIN job ON job_id = task_job_id " +
                             "LEFT JOIN employee ON employee_id = task_assignedemp " +
                             "LEFT JOIN ibis_tasktype ON ibis_tasktype_id = task_type_id " +
                             "HAVING task_taskstatus_id = 1 " +
                             "ORDER BY job_job_key ASC";

                MySqlDataAdapter da = new MySqlDataAdapter(sql, ibisobj.dbh);
                DataTable dt = new DataTable();
                //dt.TableName = "DataSet1";
                da.Fill(dt);

                reportViewer1.ProcessingMode = ProcessingMode.Local;

                LocalReport lr = reportViewer1.LocalReport;

                lr.ReportEmbeddedResource = "HoldenTaskManager.Reports." + ReportTemplates[IbisReportType] + ".rdlc";
                lr.ReportPath = ReportTemplates[IbisReportType] + ".rdlc";

                // Create a report data source for the sales order data
                ReportDataSource dsRptData = new ReportDataSource();
                dsRptData.Name = "DataSet1";
                dsRptData.Value = dt;

                lr.DataSources.Clear();
                lr.DataSources.Add(dsRptData);

                lr.Refresh();
            }
            catch (MySqlException mysqlex)
            {
                MessageBox.Show("msex3: " + mysqlex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex_cl_gen1: " + ex.ToString());
            }

            System.Drawing.Printing.PageSettings ps = new System.Drawing.Printing.PageSettings();
            ps.Landscape = true;
            reportViewer1.SetPageSettings(ps);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            _populateReport();
        }
    }
}
