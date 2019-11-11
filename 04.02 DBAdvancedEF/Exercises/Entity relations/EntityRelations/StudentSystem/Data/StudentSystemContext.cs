using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.ConfigModels;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
        : base(options)
        {

        }


        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(Config.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfig());
            modelBuilder.ApplyConfiguration(new CourseConfig());
            modelBuilder.ApplyConfiguration(new HomeworksConfig());
            modelBuilder.ApplyConfiguration(new ResourceConfig());
            modelBuilder.ApplyConfiguration(new StudentCourseConfig());

        }

    }
}
