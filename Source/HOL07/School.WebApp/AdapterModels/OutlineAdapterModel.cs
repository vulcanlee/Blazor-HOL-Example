﻿using System.ComponentModel.DataAnnotations;

namespace School.WebApp.AdapterModels
{
    public class OutlineAdapterModel
    {
        public int OutlineId { get; set; }
        [Required(ErrorMessage = "課程大綱名稱 欄位必須要輸入值")]
        public string Title { get; set; }
        public int CourseId { get; set; }

        public string CourseName { get; set; } = "";

        public CourseAdapterModel Course { get; set; }
    }
}
