using System.Linq.Dynamic.Core;
namespace Models
{
    public class Sorting<T>
    {
        public Sorting()
        {
        }

        public string SortColumn { get; set; }
        public string SortDirection { get; set; }
        public T SortingFields { get; set; }


        //this will return a query again for us. 
        public IQueryable SortUserResults(Sorting<T> sorting, Paging paging, IQueryable query)
        {
            query = query
                .OrderBy($"{sorting.SortColumn} {sorting.SortDirection}")
                .Skip(paging.RecordsToSkip)
                .Take(paging.RecordsToSelect);
            return query;
        }
    }
}



