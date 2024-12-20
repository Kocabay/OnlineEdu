using OnlineEdu.Bussiness.Abstract;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.Entity.Entities;

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

        public void TShowOnHome(int id)
        {
            courseRepository.ShowOnHome(id);
        }
    }
}
