using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        List<Course> TGetCourseByTeacherId(int id);
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        List<Course> TGetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null);
        List<Course> TGetAllCoursesWithCategories();
    }
}
