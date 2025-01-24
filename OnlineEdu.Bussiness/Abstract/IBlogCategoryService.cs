using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface IBlogCategoryService : IGenericService<BlogCategory>
    {
        List<BlogCategory> TGetCategoriesWithBlogs();
    }
}
