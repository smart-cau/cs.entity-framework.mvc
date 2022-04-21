using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models;

public class Course
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)] // DB가 자동생성해주는 값이 아니라, CourseID를 pk로 쓸 것임을 명시
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
    
    public ICollection<Enrollment> Enrollments { get; set; }
}