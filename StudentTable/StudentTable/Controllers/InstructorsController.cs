using Microsoft.AspNetCore.Mvc;
using StudentTable.Data;
using StudentTable.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StudentTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorsController : ControllerBase
    {
        private readonly SchoolDbContext _db;

        public InstructorsController(SchoolDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Instructors>>> GetAllInstructors()
        {
            return await _db.Instructors.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Instructors>> AddInstructor([FromBody] Instructors instructordetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Instructors.Add(instructordetails);
            await _db.SaveChangesAsync();
            return Ok(instructordetails);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Instructors>> UpdateInstructor(int id, [FromBody] Instructors instructordetails)
        {
            if (instructordetails == null)
            {
                return BadRequest(ModelState);
            }
            var instructorDetails = await _db.Instructors.FirstOrDefaultAsync(x => x.InstructorId == id);
            if (instructorDetails == null)
            {
                return NotFound();
            }

            instructorDetails.LastName = instructordetails.LastName;
            instructorDetails.FirstName = instructordetails.FirstName;
            instructorDetails.Status = instructordetails.Status;
            instructorDetails.HireDate = instructordetails.HireDate;
            instructorDetails.AnnualSalary = instructordetails.AnnualSalary;
            instructorDetails.DepartmentId = instructordetails.DepartmentId;

            await _db.SaveChangesAsync();
            return Ok(instructorDetails);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteInstructor(int id)
        {
            var instructorDetails = await _db.Instructors.FirstOrDefaultAsync(x => x.InstructorId == id);
            if (instructorDetails == null)
            {
                return NotFound();
            }
            _db.Instructors.Remove(instructorDetails);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}
