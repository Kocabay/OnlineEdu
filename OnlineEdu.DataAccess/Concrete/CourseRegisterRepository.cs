using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Concrete
{
    public class CourseRegisterRepository : GenericRepository<CourseRegister>, ICourseRegisterRepository
    {
        public CourseRegisterRepository(OnlineEduContext context) : base(context)
        {
        }

        public List<CourseRegister> GetAllWithCourseAndCategory(Expression<Func<CourseRegister, bool>> filter)
        {
            return _context.CourseRegisters.Where(filter).Include(x => x.Course).ThenInclude(x => x.CourseCategory).ToList();
        }
    }
}
