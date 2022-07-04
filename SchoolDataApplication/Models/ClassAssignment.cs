using System.ComponentModel.DataAnnotations;

namespace SchoolDataApplication.Models
{
    public class ClassAssignment
    {
        
        public int UserId { get; set; }
        
        public int ClassId { get; set; }

        public int SchoolId { get; set; }


        // 
        // Navigation Properties
        
        public User? User { get; set; }
        public SchoolClass? SchoolClass { get; set; }
    }
}
