using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Config;
using examinationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace examinationAPI.Data
{
    public class Context(DbContextOptions options) : DbContext(options)
    {
        DbSet<Choice> Choices { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<ExamQuestion> ExamQuestions { get; set; }
        DbSet<Exam> Exams { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserExam> UserExams { get; set; }
        DbSet<Answer> Answers { get; set; }
        DbSet<UserCourse> UserCourses { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseModel>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;

                    // Prevent CreatedAt from being overwritten
                    entry.Property(e => e.CreatedAt).IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}