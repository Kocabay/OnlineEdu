using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        public CourseRepository(OnlineEduContext context) : base(context)
        {
        }

        public void DontShowOnHome(int id)
        {
            var value = _context.Courses.Find(id);
            value.IsShown = false;
            _context.SaveChanges();
        }

        public List<Course> GetAllCoursesWithCategories()
        {
           return _context.Courses.Include(x => x.CourseCategory).ToList();
        }

        public List<Course> GetCourseByTeacherId(int id)
        {
            return _context.Courses.Include(x => x.CourseCategory).Where(x => x.AppUserId == id).ToList();
        }

        public void ShowOnHome(int id)
        {
            var value = _context.Courses.Find(id);
            value.IsShown = true;
            _context.SaveChanges();
        }
    }
}
