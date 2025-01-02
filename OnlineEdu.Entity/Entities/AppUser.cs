﻿using Microsoft.AspNetCore.Identity;

namespace OnlineEdu.Entity.Entities
{
    public class AppUser:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageUrl { get; set; }
        public List<Course> Courses { get; set; }
        public List<CourseRegister> CourseRegisters { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<TeacherSocial> TeacherSocials { get; set; }
    }
}
