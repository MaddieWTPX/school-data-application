using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TableControls<T>
    {
        public TableControls()
        {

        }
        public Sorting<T> Sorting { get; set; }
        public Paging Paging { get; set; }
    }
}
