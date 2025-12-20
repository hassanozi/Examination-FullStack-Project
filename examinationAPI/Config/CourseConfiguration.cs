using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examinationAPI.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder
                .HasOne(c => c.PrerequisiteCourse)
                .WithMany(c => c.DependentCourses)
                .HasForeignKey(c => c.PrerequisiteCourseId)
                .OnDelete(DeleteBehavior.Restrict);

             builder
                .HasIndex(c => c.Title)
                .IsUnique();
        }

    }
}