﻿using OnlineEdu.DTO.DTOs.CourseDtos;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.CourseRegisterDtos
{
    public class UpdateCourseRegisterDto
    {
        public AppUser AppUser { get; set; }
        public int CourseRegisterId { get; set; }
        public int AppUserId { get; set; }
        public int CourseId { get; set; }
        public ResultCourseDto Course { get; set; }
    }
}
