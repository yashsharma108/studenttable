using Microsoft.AspNetCore.Mvc;
using StudentTable.Data;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SchoolDbContext _db;

        public StudentsController(SchoolDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult<List<Students>> GetAllStudents()
        {
            return Ok(_db.Students.ToList());
        }

        [HttpPost]
        public ActionResult<Students> AddStudent([FromBody] Students studentDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Students.Add(studentDetails);
            _db.SaveChanges();
            return Ok(studentDetails);
        }

        [HttpPut("{id}")]
        public ActionResult<Students> UpdateStudent(int id, [FromBody] Students studentDetails)
        {
            if (studentDetails == null)
            {
                return BadRequest(ModelState);
            }
            var student = _db.Students.FirstOrDefault(x => x.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }

            student.StudentNumber = studentDetails.StudentNumber;
            student.FirstName = studentDetails.FirstName;
            student.LastName = studentDetails.LastName;
            student.EnrollmentDate = studentDetails.EnrollmentDate;
            student.GraduationDate = studentDetails.GraduationDate;

            _db.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteStudent(int id)
        {
            var student = _db.Students.FirstOrDefault(x => x.StudentID == id);
            if (student == null)
            {
                return NotFound();
            }
            _db.Students.Remove(student);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
