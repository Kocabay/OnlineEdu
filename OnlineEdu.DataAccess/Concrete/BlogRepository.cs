using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        private readonly OnlineEduContext _educontext;
        public BlogRepository(OnlineEduContext _context) : base(_context)
        {
            _educontext = _context;
        }
        List<Blog> IBlogRepository.GetBlogsWithCategories()
        {
           return _educontext.Blogs.Include(x=>x.BlogCategory).ToList();
        }
    }
}
