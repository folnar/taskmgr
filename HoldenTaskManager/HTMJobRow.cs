using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoldenTaskManager
{
    class HTMJobRow : DataGridViewRow
    {
        private Dictionary<string, int> RowInfo { get; set; }

        // NEED ADD COLUMNS METHOD.
        // THIS SHOULD BE PRIVATE AND CALLED BY A MORE GENERAL
        // UI METHOD CALLED ADDTASK WHICH ALSO ADDS A ROW AND 
        // ADDS THE APPROPRIATE NUMBER OF BLANK CELLS TO MAKE
        // SURE COLUMNS LINE UP IN THE DATAGRIDVIEW COMPONENT.

        // default constructor
        public HTMJobRow()
        {
        }

        public HTMJobRow(string jn, string pn, string tn, string ln)
        {
            RowInfo = new Dictionary<string,int>();
            RowInfo.Add(jn, 0);
            RowInfo.Add(pn, 1);
            RowInfo.Add(tn, 2);
            RowInfo.Add(ln, 3);

            this.Cells.Add(new DataGridViewTextBoxCell());
            this.Cells.Add(new DataGridViewTextBoxCell());
            this.Cells.Add(new DataGridViewTextBoxCell());
            this.Cells.Add(new DataGridViewTextBoxCell());

            AssertData();
        }

        public void AssertData()
        {
            foreach (string key in RowInfo.Keys)
            {
                this.Cells[RowInfo[key]].Value = key;
            }
        }
    }
}
