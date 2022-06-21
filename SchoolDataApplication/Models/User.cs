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
    public class User
    {


        [Key]
        [DisplayName("User ID")]
        public int UserId { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(50)")]
        [DisplayName("Last Name")]
        public string LastName { get; set; }


        [Column(TypeName = "varchar(200)")]
        [DisplayName("School")]
        public string School { get; set; }

        //
        // Optional
        [DataType(DataType.Date)]
        [DisplayName("Date of Birth")]
        public DateTime? DateOfBirth { get; set; }


        [DisplayName("Year Group")]
        public int? YearGroup { get; set; }


        //
        // Navigation Properties

        [DisplayName("User Type")]
        public int? UserTypeId { get; set; }
        public UserType? UserType { get; set; }

        public ICollection<ClassAssignment>? ClassAssignments { get; set; }
      
    }
}
