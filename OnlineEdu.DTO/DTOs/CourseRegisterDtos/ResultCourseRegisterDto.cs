using OnlineEdu.DTO.DTOs.CourseDtos;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDtos
{
    public class ResultCourseRegisterDto
    {
        public int CourseRegisterId { get; set; }
        public int AppUserId { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
