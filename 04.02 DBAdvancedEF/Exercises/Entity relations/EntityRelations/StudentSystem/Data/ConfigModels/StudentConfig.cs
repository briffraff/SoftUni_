using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data.ConfigModels
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);
            builder.Property(s => s.Name).HasMaxLength(100).IsUnicode().IsRequired();
            builder.Property(s => s.PhoneNumber).HasColumnName("CHAR(10)").IsUnicode(false).IsRequired(false);
            builder.Property(s => s.RegisteredOn).HasColumnName("GETDATE()");
            builder.Property(s => s.Birthday).IsRequired(false);

            //o StudentId
            //o Name(up to 100 characters, unicode)
            //o PhoneNumber(exactly 10 characters, not unicode, not required)
            //o RegisteredOn
            //o Birthday(not required)

        }
    }
}
