using OnlineEdu.WebUI.DTOs.BlogDtos;

namespace OnlineEdu.WebUI.DTOs.BlogCategoryDtos
{
    public class ResultBlogCategoryDto
    {
        public int BlogCategoryId { get; set; }
        public string Name { get; set; }

        public List<ResultBlogDto> Blogs { get; set; }
    }
}
