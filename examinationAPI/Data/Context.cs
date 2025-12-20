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
        DbSet<Role> Roles { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<RolePermission> RolePermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);
        }

    }
}