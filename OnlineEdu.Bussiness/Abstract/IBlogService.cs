using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        List<Blog> TGetLastFourBlogsWithCategories();
        public Blog TGetBlogCategory(int id);
        List<Blog> TGetBlogsWtihCategoriesByWriterId(int id);
        public List<Blog> TGetBlogsByCategoryId(int id);

    }
}
