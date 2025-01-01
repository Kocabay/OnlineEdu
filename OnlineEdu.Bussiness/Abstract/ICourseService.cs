using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        List<Course> TGetCourseByTeacherId(int id);
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
        List<Course> TGetAllCoursesWithCategories();
    }
}
