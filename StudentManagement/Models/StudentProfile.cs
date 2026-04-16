using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentManagement.Models
{
    public class StudentProfile
    {
        [Key]
        public int StudentProfileID { get; set; }

        public string Address { get; set; }

        public string PhoneNo { get; set; }

        [ForeignKey ("StudentID")] // Data Annotaion
        public int StudentID { get; set; }
        public Student student { get; set; } 

    }
}
