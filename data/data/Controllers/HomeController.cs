using data.Data;
using data.Models;
using Microsoft.AspNetCore.Mvc;

namespace data.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        
        public HomeController(MyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        // Create
        [HttpPost]
        public IActionResult Index(Student std) 
        {
            _context.tbl_students.Add(std);
            _context.SaveChanges();
            return RedirectToAction("ShowStudents");
        }
        // Read
        public IActionResult ShowStudents()
        {
            var students = _context.tbl_students.ToList();
            return View(students);
        }
        // Update
        public IActionResult Edit(int id)
        {
            var student = _context.tbl_students.Find(id);

            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(Student updateStudent)
        {
            _context.tbl_students.Update(updateStudent);
            _context.SaveChanges();

            return RedirectToAction("ShowStudents");
        }
        // Delete
        public IActionResult Delete(int id)
        {
            var student = _context.tbl_students.Find(id);
            _context.tbl_students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("ShowStudents");
        }
        // Login
        public IActionResult Login() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string std_name, string std_class)
        {
            var student = _context.tbl_students.FirstOrDefault(u => u.std_name == std_name && u.std_class == std_class);
            if (student != null)
            {
                return RedirectToAction("ShowStudents");
            }
            else
            {
                ViewBag.Error = "Invalid Credentials!";
                return View();
            }
        }
    }
}
