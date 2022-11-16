using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAPI;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
           {
               new Student()
               {
                   Id=1,
                   Name="khaled",
                   Age=22,
                   city="kjhkel"
               },
               new Student()
               {
                   Id=2,
                   Name="aaed",
                   Age=25,
                   city="kSSLKel"
               }

           };
        [HttpGet]
        [Route("GetStudents")]
        
        public async Task<ActionResult<Student>> GetStudents()
        {
           
            return Ok(students);
        }
        [HttpGet]
        [Route("GetStudent")]

        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = students.Find(x => x.Id == id);
            if(student == null)
            {
                return BadRequest("no student found");
            }
            return Ok(student);
        }
        [HttpPost]
        [Route("addStudent")]
        public async Task<ActionResult<Student>> AddStudent(Student request)
        {
            students.Add(request);
            return Ok(students);
        }
        [HttpPut]
        [Route("UpdateStudent")]

        public async Task<ActionResult<Student>> UpdateStudent(Student request)
        {
            var student = students.Find(x => x.Id == request.Id);
            if (student == null)
            {
                return BadRequest("no student found");
            }
            student.Name= request.Name;
            student.Id = request.Id;
            student.Age = request.Age;
            student.city = request.city;
            return Ok(student);
        }
        [HttpDelete]
        [Route("RemoveStudent")]
        public async Task<ActionResult<Student>> RemoveStudent(int id)
        {
            var student = students.Find(x => x.Id ==id);
            if (student == null)
            {
                return BadRequest("no student found");
            }
            students.Remove(student);
            return Ok(students);
        }
    }
}
