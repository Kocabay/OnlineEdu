using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IBlogCategoryRepository : IRepository<BlogCategory>
    {
        List<BlogCategory> GetCategoriesWithBlogs();

    }
}
