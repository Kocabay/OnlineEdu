using OnlineEdu.DTO.DTOs.CourseDtos;

namespace OnlineEdu.DTO.DTOs.CourseCategoryDtos
{
    public class ResultCourseCategoryDto
    {
        public int CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public bool IsShown { get; set; }
        public List<ResultCourseDto> Courses { get; set; }

    }
}
