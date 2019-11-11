using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ConfigModels
{
   public  class HomeworksConfig : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(h => h.HomeworkId);
            builder.Property(h => h.Content).IsUnicode(false).IsRequired();
            builder.HasOne(s => s.Student).WithMany(h => h.HomeworkSubmissions);
            builder.HasOne(c => c.Course).WithMany(c => c.HomeworkSubmissions);

            //o HomeworkId
            //o Content(string, linking to a file, not unicode)
            //o ContentType(enum – can be Application, Pdf or Zip)
            //o SubmissionTime
            //o StudentId
            //o CourseId
        }
    }
}
