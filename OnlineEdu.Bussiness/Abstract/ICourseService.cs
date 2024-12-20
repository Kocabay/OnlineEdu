using OnlineEdu.Entity.Entities;

namespace OnlineEdu.Bussiness.Abstract
{
    public interface ICourseService : IGenericService<Course>
    {
        void TShowOnHome(int id);
        void TDontShowOnHome(int id);
    }
}
