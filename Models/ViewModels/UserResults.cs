using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModels
{
    public class UserResults
    {
        public UserResults()
        {
        }

        public List<User> Users { get; set; }
        public Sorting Sorting { get; set; }
    }
}

