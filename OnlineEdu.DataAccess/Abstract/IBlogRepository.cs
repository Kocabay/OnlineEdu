using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogRepository : IRepository<Blog>
    {
        List<Blog> GetBlogsWithCategories();
        List<Blog> GetBlogsByCategoryId(int id);
        Blog GetBlogCategory(int id);
        List<Blog> GetBlogsWtihCategoriesByWriterId(int id);
        List<Blog> GetLastFourBlogsWithCategories();
    }
}
