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
        
    }
}