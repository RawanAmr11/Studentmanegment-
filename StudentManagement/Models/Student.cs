using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        public string Name { get; set; }

        public int Age  { get; set; }

        public StudentProfile Profile { get; set; }  //Navigation Property 
        

        public List<Courses> Courses { get; set; }





    } 
}
