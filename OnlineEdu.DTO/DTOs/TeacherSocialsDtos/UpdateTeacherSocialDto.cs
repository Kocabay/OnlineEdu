﻿using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DTO.DTOs.TeacherSocialsDtos
{
    public class UpdateTeacherSocialDto
    {
        public int TeacherSocialId { get; set; }
        public string Url { get; set; }
        public string SocialMediaName { get; set; }
        public string Icon { get; set; }
        public int TeacherId { get; set; }
     
    }
}