﻿using Microsoft.EntityFrameworkCore;
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

        public Blog GetBlogCategory(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Writer).ThenInclude(x => x.TeacherSocials).FirstOrDefault(x => x.BlogId == id);
        }

        public List<Blog> GetBlogsByCategoryId(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Writer).Where(x => x.BlogCategoryId == id).ToList();
        }

        public List<Blog> GetBlogsWtihCategoriesByWriterId(int id)
        {
            return _context.Blogs.Include(x => x.BlogCategory).Where(x => x.WriterId == id).ToList();
        }

        public List<Blog> GetLastFourBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).OrderByDescending(x => x.BlogId).Take(4).ToList();
        }

        List<Blog> IBlogRepository.GetBlogsWithCategories()
        {
            return _context.Blogs.Include(x => x.BlogCategory).Include(x => x.Writer).ToList();
        }
    }
}
