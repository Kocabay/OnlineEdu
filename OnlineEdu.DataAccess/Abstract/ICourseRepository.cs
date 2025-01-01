using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRepository:IRepository<Course>
    {
        List<Course> GetCourseByTeacherId(int id);
        List<Course> GetAllCoursesWithCategories();
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}
