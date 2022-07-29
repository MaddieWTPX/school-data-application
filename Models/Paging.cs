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

        public Paging(int recordCount, int currentPage = 1, int recordsToSelect = 5)
        {
            RecordCount = recordCount;
            CurrentPage = currentPage;
            RecordsToSelect = recordsToSelect;
            NumberOfPages = CalculateNumberOfPages(recordCount, recordsToSelect);
            RecordsToSkip = CalculateRecordsToSkip(currentPage, recordsToSelect);
        }
        public int CurrentPage { get; set; } = 1;
        public int NumberOfPages { get; set; }
        public int RecordCount { get; set; }
        public int RecordsToSkip { get; set; } = 0;
        public int RecordsToSelect { get; set; } = 5;


        public int CalculateRecordsToSkip(int currentPage, int recordsToSelect)
        {
            if (currentPage == 1)
            {
                return 0;
            }
            else
            {
                return (currentPage - 1) * recordsToSelect;
            }
        }

        public int CalculateNumberOfPages(int recordCount, int recordsToSelect)
        {
            return (int)Math.Ceiling((decimal)recordCount / (decimal)recordsToSelect);
        }
    }
}
