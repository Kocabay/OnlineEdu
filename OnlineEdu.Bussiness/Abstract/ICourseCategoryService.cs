using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface ICourseCategoryService : IGenericService<CourseCategory>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}
