using System;
using System.Windows.Forms;

namespace HoldenTaskManager
{
    public partial class frmReportsMenu : Form
    {
        public frmReportsMenu()
        {
            InitializeComponent();
        }

        private void btnRptbyJobNum_Click(object sender, EventArgs e)
        {
            frmReportTemplate frmTaskReport_byJobNum = new frmReportTemplate();
            frmTaskReport_byJobNum.IbisReportType = "byjob";
            frmTaskReport_byJobNum.Show();
        }

        private void btnRptbyEmployee_Click(object sender, EventArgs e)
        {
            frmReportTemplate frmTaskReport_byEmployee = new frmReportTemplate();
            frmTaskReport_byEmployee.IbisReportType = "byemp";
            frmTaskReport_byEmployee.Show();
        }

        private void btnRptbyTaskType_Click(object sender, EventArgs e)
        {
            frmReportTemplate frmTaskReport_byEmployee = new frmReportTemplate();
            frmTaskReport_byEmployee.IbisReportType = "bytt";
            frmTaskReport_byEmployee.Show();
        }

        private void btnOpenJobsReport_Click(object sender, EventArgs e)
        {
            frmReportTemplate frmTaskReport_byEmployee = new frmReportTemplate();
            frmTaskReport_byEmployee.IbisReportType = "openjobs";
            frmTaskReport_byEmployee.Show();
        }
    }
}
