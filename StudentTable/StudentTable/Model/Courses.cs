using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentTable.Model
{
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }
        public string? CourseName { get; set; }
        public int CourseNumber { get; set; }
        public string? CourseDescription { get; set; }
        public int CourseUnits { get; set; }
        [ForeignKey("DepartmentsId")]
        public int DepartmentId { get; set; }

        [ForeignKey("InstructorId")]
        public int InstructorID {  get; set; }
        
    }
}
