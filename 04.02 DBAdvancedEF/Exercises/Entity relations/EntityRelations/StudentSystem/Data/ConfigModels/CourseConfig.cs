using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ConfigModels
{
    public class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {

            builder.HasKey(c => c.CourseId);
            builder.Property(c => c.Name).HasMaxLength(80).IsUnicode().IsRequired();
            builder.Property(c => c.Description).IsUnicode().IsRequired(false);
            
            //o CourseId
            //o Name(up to 80 characters, unicode)
            //o Description(unicode, not required)
            //o StartDate
            //o EndDate
            //o Price
        }
    }
}
