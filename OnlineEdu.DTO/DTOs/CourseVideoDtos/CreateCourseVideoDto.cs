using OnlineEdu.DTO.DTOs.CourseDtos;

namespace OnlineEdu.DTO.DTOs.CourseVideoDtos
{
    public class CreateCourseVideoDto
    {
        public int CourseId { get; set; }
      //  public ResultCourseDto Course { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
