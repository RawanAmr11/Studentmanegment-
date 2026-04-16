using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }

        public string Title { get; set; }

        public int  CreditHours { get; set; } 

        public List<Student> students { get; set; }
    }
}
