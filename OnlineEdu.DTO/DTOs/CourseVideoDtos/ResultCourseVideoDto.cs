using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.CourseVideoDtos
{
    public class ResultCourseVideoDto
    {
        public int CourseVideoId { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
