using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
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

        [DisplayName("User Type")]
        public int UserTypeId { get; set; }

        [DisplayName("School")]
        public int SchoolId { get; set; }

        //
        // Optional
        [DisplayName("Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? DateOfBirth { get; set; }


        [DisplayName("Year Group")]
        public int? YearGroupId { get; set; }


        //
        // Navigation Properties


        public UserType? UserType { get; set; }
        public YearGroup? YearGroup { get; set; }
        
        public School? School { get; set; }

        public ICollection<ClassAssignment>? ClassAssignments { get; set; }
    }
}
