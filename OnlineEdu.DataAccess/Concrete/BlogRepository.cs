using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {
             
        }

        public List<Blog> GetBlogsWtihCategoriesByWriterId(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Where(x => x.WriterId == id).ToList();
        }

        List<Blog> IBlogRepository.GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).ToList();
        }
    }
}
