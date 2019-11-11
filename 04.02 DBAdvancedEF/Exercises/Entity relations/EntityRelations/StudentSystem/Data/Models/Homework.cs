﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
        
        //o HomeworkId
        //o Content(string, linking to a file, not unicode)
        //o ContentType(enum – can be Application, Pdf or Zip)
        //o SubmissionTime
        //o StudentId
        //o CourseId

    }
}
