namespace OnlineEdu.Entity.Entities
{
    public class TeacherSocial
    {
        public int TeacherSocialId{ get; set; }
        public string Url { get; set; }
        public string SocialMediaName { get; set; }
        public string Icon { get; set; }
        public int TeacherId{ get; set; }
        public AppUser Teacher { get; set; }
    }
}
