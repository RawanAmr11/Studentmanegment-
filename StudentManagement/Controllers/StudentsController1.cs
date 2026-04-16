using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("Students")] //Attribute routing, All routes starts from students 
    public class StudentsController1 : Controller
    {
        private readonly AppDbContext _context; //to interact with db

        public StudentsController1(AppDbContext context) //Dependency Injection 
        {
            _context = context;
        }

        [HttpGet("all")] //get /students/all  
        public IActionResult GetAll()
        {
            var students = _context.students.ToList();

            return View(students);// view HTML page
        }

        [HttpGet("{id}")] //Get /students/7  

        public IActionResult GetById(int id) // ID gay mn el route 
        {
            var student = _context.students.Find(id);

            if (student == null)
                return Content("Student Not found");// return content

            return Json(student); //return JSON 

        }

        [HttpPost("Create")] //POST -> /students/Create 

        public IActionResult Create(Student student)
        {
            _context.students.Add(student);
            _context.SaveChanges();

            return RedirectToAction("GetAll"); //Redirect to another page 
        }

        [HttpGet("Search")]//Get /students/search?name=rawan&age=22
        public IActionResult Search (string name , int age)
        {
            var result = _context.students // starts with query 
                .Where(s => s.Name == name && s.Age == age).ToList();

             return Json(result); 
                      
        }

        [HttpPut("update/{id}")] // PUT /students/update/5

        public IActionResult Update(int id , Student updated ) // Id mn route ,, updated student from body 
        {
            var student = _context.students.Find(id);
            if (student == null)
                return NotFound(); 

            student.Name = updated.Name;
            student.Age = updated.Age; 

            _context.SaveChanges();

            return Json(student); 
        }

        [HttpDelete("delete/{id}")] //DELETE /students/delete/6

        public IActionResult Delete(int id) //id mn route 
        {
            var student= _context.students.Find(id); 
            if (student == null)
                return NotFound(); //404 
            _context.students.Remove(student);
            _context.SaveChanges();

            return Content("Deleted Successfully");
        }

        [HttpGet("with-courses")] // Get /students/with-courses 
        public IActionResult GetWithCourses()
        {
            var students = _context.students
            .Include(s => s.Courses)//EAGER LOADING 
            .Include(s=>s.Profile)//Eager Loading
            .ToList(); 

            return Json(students);
        }

        [HttpPost("Full-Example /{id}")] //POST /students/full-example/5?name=rawan

         public IActionResult FullExample( int id, [FromQuery] string name, [FromBody] Student student )
        {
            return Json(new
            {
                RouteID = id, 
                QueryName = name,
                Body = student
            });
        }
















        





    }
}
