using Microsoft.AspNetCore.Mvc;
using StudentTable.Data;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;

namespace CoursesController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course : ControllerBase
    {
        private SchoolDbContext _db;
        public Course(SchoolDbContext context)
        {
            _db = context;
        }
        [HttpGet]
        public List<Courses> GetAllCourses()
        {
            return _db.Courses.ToList();
        }
        [HttpPost]
        public ActionResult<Courses> AddCourse([FromBody] Courses course)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Courses.Add(course);
            _db.SaveChanges();
            return Ok(course);

        }
        [HttpPut]
        public ActionResult<Courses> UpdateCourse(Int32 id, [FromBody] Courses coursedetails)
        {
            if (coursedetails == null)
            {
                return BadRequest(ModelState);
            }
            var CourseDetails = _db.Courses.FirstOrDefault(x => x.CourseID == id);
            if (CourseDetails == null)
            {
                return NotFound();
            }


            CourseDetails.CourseName = coursedetails.CourseName;
            CourseDetails.CourseDescription = coursedetails.CourseDescription;
            CourseDetails.CourseUnits = coursedetails.CourseUnits;
            CourseDetails.DepartmentId = coursedetails.DepartmentId;
            CourseDetails.InstructorID = coursedetails.InstructorID;

            _db.SaveChanges();
            return Ok(CourseDetails);
        }
        [HttpDelete]
        public ActionResult DeleteCourse(Int32 id, [FromBody] Courses coursedetails)
        {
            if (coursedetails == null)
            {
                return NotFound();
            }
            _db.Remove(coursedetails);
            _db.SaveChanges();
            return NoContent();
        }
    }
}