using System.ComponentModel.DataAnnotations;

namespace StudentTable.Model
{
    public class Departments
    {
        [Key]
        public int DepartmentsId { get; set; }
        public string? DepartmentsName { get; set; }
    }
}
