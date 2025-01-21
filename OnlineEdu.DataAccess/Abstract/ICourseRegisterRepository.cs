using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface ICourseRegisterRepository : IRepository<CourseRegister>
    {
        List<CourseRegister> GetAllWithCourseAndCategory(Expression<Func<CourseRegister,bool>> filter);
    }
}
