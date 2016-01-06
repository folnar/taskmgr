using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoldenTaskManager
{
    class HTMTaskRow : DataGridViewRow
    {
        public int rtype { get; set; }

        // default constructor
        public HTMTaskRow()
        {
            rtype = 2;
        }

        public override object Clone()
        {
            return base.Clone();
        }
    }
}
