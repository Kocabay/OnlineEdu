using OnlineEdu.WebUI.DTOs.CourseDtos;

namespace OnlineEdu.WebUI.DTOs.CourseVideoDtos
{
    public class UpdateCourseVideoDto
    {
        public int CourseId { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
