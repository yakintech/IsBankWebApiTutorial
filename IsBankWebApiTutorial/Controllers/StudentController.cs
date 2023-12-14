using IsBankWebApiTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace IsBankWebApiTutorial.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        List<Student> students;

        public StudentController()
        {
            students = new List<Student>();

            students.Add(new Student()
            {
                Id = 1,
                Name = "Cagatay",
                Surname = "Yildiz"
            });

            students.Add(new Student()
            {
                Id = 2,
                Name = "Ertan",
                Surname = "Caliskan"
            });

            students.Add(new Student()
            {
                Id = 3,
                Name = "Aykut",
                Surname = "Arslan"
            });
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound(id + " is not found!");
            }
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            student.Id = students.Last().Id + 1;

            students.Add(student);

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(q => q.Id == id);
            if (student != null)
            {
                students.Remove(student);
                return Ok(students);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
