using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;
using System.Linq.Expressions;

namespace OnlineEdu.Bussiness.Concrete
{
    public class CourseManager : GenericManager<Course>, ICourseService
    {
        private readonly ICourseRepository courseRepository;
        public CourseManager(IRepository<Course> _repository, ICourseRepository courseRepository) : base(_repository)
        {
            this.courseRepository = courseRepository;
        }

        public void TDontShowOnHome(int id)
        {
           courseRepository.DontShowOnHome(id);
        }

        public List<Course> TGetAllCoursesWithCategories()
        {
           return  courseRepository.GetAllCoursesWithCategories();
        }

        public List<Course> TGetAllCoursesWithCategories(Expression<Func<Course, bool>> filter = null)
        {
            return courseRepository.GetAllCoursesWithCategories(filter);
        }

        public List<Course> TGetCourseByTeacherId(int id)
        {
            return courseRepository.GetCourseByTeacherId(id);
        }

        public void TShowOnHome(int id)
        {
            courseRepository.ShowOnHome(id);
        }
    }
}
