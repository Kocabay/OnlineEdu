using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository : IRepository<Course>
    {
        List<Course> GetCourseByTeacherId(int id);
        List<Course> GetAllCoursesWithCategories();
        List<Course> GetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null);
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}
