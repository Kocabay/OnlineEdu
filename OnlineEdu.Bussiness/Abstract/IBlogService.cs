using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> TGetBlogsWithCategories();
        List<Blog> TGetLastFourBlogsWithCategories();
        List<Blog> TGetBlogsWtihCategoriesByWriterId(int id);

    }
}
