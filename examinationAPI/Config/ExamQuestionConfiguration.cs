using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace examinationAPI.Config
{
    public class ExamQuestionConfiguration : IEntityTypeConfiguration<ExamQuestion>
    {
        public void Configure(EntityTypeBuilder<ExamQuestion> builder)
        {
            builder.HasOne(e => e.Exams)
                .WithMany(eq => eq.ExamQuestions)
                .HasForeignKey(e => e.ExamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Questions)
                .WithMany(eq => eq.ExamQuestions)
                .HasForeignKey(e => e.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}