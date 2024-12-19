using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseCategoryRepository:IRepository<CourseCategory>
    {
        void ShowOnHome(int id);
        void DontShowOnHome(int id);
    }
}
