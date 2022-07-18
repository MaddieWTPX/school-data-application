using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Paging
    {
        public Paging()
        {
        }
        public int CurrentPage { get; set; }
        public int NumberOfPages { get; set; }
        public int RecordCount { get; set; }
        public int RecordsToSkip { get; set; }
        public int RecordsToSelect { get; set; }


    }
}
