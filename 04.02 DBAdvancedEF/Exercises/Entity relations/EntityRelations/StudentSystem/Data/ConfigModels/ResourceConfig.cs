using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ConfigModels
{
    public class ResourceConfig : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);
            builder.Property(r => r.Name).HasMaxLength(50).IsUnicode().IsRequired();
            builder.Property(r => r.Url).IsUnicode(false).IsRequired();
            builder.HasOne(c => c.Course).WithMany(r => r.Resources);

            //o ResourceId
            //o Name(up to 50 characters, unicode)
            //o Url(not unicode)
            //o ResourceType(enum – can be Video, Presentation, Document or Other)
            //o CourseId
        }
    }
}
