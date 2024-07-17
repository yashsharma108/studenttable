using Microsoft.AspNetCore.Mvc;
using StudentTable.Data;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Studentcourses : ControllerBase
    {
        private SchoolDbContext _db;
        public Studentcourses(SchoolDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public List<StudentCourses> GetAllStCourses()
        {
            return _db.StudentCourses.ToList();
        }
        [HttpPost]
        public ActionResult<StudentCourses> AddSCourse([FromBody] StudentCourses studentCourses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.StudentCourses.Add(studentCourses);
            _db.SaveChanges();
            return Ok(studentCourses);
        }
        [HttpPut]
        public ActionResult<StudentCourses> UpdateStCourses(Int32 id, [FromBody] StudentCourses studentcourses)
        {
            if (studentcourses == null)
            {
                return BadRequest(ModelState);
            }
            var StudentCDetails = _db.StudentCourses.FirstOrDefault(x => x.StudentId == id);
            if (StudentCDetails == null)
            {
                return NotFound();
            }

            StudentCDetails.StudentId = studentcourses.StudentId;
            StudentCDetails.CourseId = studentcourses.CourseId;


            _db.SaveChanges();
            return Ok(StudentCDetails);
        }

        [HttpDelete]
        public ActionResult DeleteStudentCourse(Int32 id)
        {
            var StudentCDetails = _db.StudentCourses.FirstOrDefault(x => x.StudentId == id);
            if (StudentCDetails == null)
            {
                return NotFound();
            }
            _db.Remove(StudentCDetails);
            _db.SaveChanges();
            return NoContent();
        }
    }
}