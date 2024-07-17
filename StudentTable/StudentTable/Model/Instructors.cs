using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class Instructors
    {
        [Key]
        public int InstructorId { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public string? Status { get; set; }
        public DateTime? HireDate { get; set; }
        public double? AnnualSalary { get; set; }

        [ForeignKey("DepartmentsId")]
        public int DepartmentId { get; set; }
    }
}
