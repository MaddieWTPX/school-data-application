using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class SchoolClass
    {

        [Key]
        public int ClassId { get; set; }
        
        public string? ClassName { get; set; }

        public string? ClassDescription { get; set; }

        //
        // Navigation Properties
        public ICollection<ClassAssignment>? ClassAssignments { get; set; }

    }
}
