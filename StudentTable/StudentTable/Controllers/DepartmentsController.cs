using Microsoft.AspNetCore.Mvc;
using StudentTable.Data;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;

namespace StudentTable.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private SchoolDbContext _db;

        public DepartmentsController(SchoolDbContext context)
        {
            _db = context;
        }
        [HttpGet]

        public List<Departments> GetAllDepartments()

        {
            return _db.Departments.ToList();

        }
        [HttpPost]
        public ActionResult<Departments> AddDeparment(Departments department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _db.Departments.Add(department);
            _db.SaveChanges();
            return Ok(department);
        }
        [HttpPut]
        public ActionResult<Departments> UpdateStCourses(Int32 id, [FromBody] Departments studentcourses)
        {
            if (studentcourses == null)
            {
                return BadRequest(ModelState);
            }
            var DepartmentsDetails = _db.Departments.FirstOrDefault(x => x.DepartmentsId == id);
            if (DepartmentsDetails == null)
            {
                return NotFound();
            }

            DepartmentsDetails.DepartmentsId = studentcourses.DepartmentsId;
            DepartmentsDetails.DepartmentsName = studentcourses.DepartmentsName;


            _db.SaveChanges();
            return Ok(DepartmentsDetails);
        }
        [HttpDelete]
        public ActionResult DeleteDepartments(Int32 id)
        {
            var DepartmentDetails = _db.StudentCourses.FirstOrDefault(x => x.StudentId == id);
            if (DepartmentDetails == null)
            {
                return NotFound();
            }
            _db.Remove(DepartmentDetails);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
