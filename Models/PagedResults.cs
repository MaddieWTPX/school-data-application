using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PagedResults<T1, T2>
    {
        public PagedResults()
        {

        }
        public T1 Results { get; set; }
        public TableControls<T2> TableControls { get; set; }
    }
}
