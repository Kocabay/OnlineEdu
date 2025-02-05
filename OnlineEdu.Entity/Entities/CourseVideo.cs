namespace OnlineEdu.Entity.Entities
{
    public class CourseVideo
    {
        public int CourseVideoId { get; set; }
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public int VideoNumber { get; set; }
        public string VideoUrl { get; set; }
    }
}
