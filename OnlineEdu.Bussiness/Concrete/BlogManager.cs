using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Concrete
{
    public class BlogManager : GenericManager<Blog>, IBlogService
    {
        private readonly IBlogRepository _blogRepository;
        public BlogManager(IRepository<Blog> _repository, IBlogRepository blogRepository) : base(_repository)
        {
            _blogRepository = blogRepository;
        }

        public Blog TGetBlogCategory(int id)
        {
            return _blogRepository.GetBlogCategory(id);
        }

        public List<Blog> TGetBlogsByCategoryId(int id)
        {
            return _blogRepository.GetBlogsByCategoryId(id);
        }

        public List<Blog> TGetBlogsWtihCategoriesByWriterId(int id)
        {
            return _blogRepository.GetBlogsWtihCategoriesByWriterId(id);
        }

        public List<Blog> TGetLastFourBlogsWithCategories()
        {
            return _blogRepository.GetLastFourBlogsWithCategories();
        }

        List<Blog> IBlogService.TGetBlogsWithCategories()
        {
            return _blogRepository.GetBlogsWithCategories();
        }
    }
}
