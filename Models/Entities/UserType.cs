using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDataApplication.Models
{
    public class UserType
    {
        
        [Key]
        [DisplayName("User Type ID")]
        public int UserTypeId { get; set; }
        
        [DisplayName("Name")]
        public string Name { get; set; }

        //
        // Navigation Properties
        public ICollection<User>? Users { get; set; }
    }
}
