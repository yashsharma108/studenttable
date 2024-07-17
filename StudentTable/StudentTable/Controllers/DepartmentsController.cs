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
        
    }
}
