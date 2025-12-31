using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Exam : BaseModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public ExamType Type { get; set; }
        public TimeSpan Duration { get; set; }
        public short NoOfQuestions { get; set; }
        public short ScorePerQuestion { get; set; }
        public short TotalGrade { get; set; }
        public DateTime Schedule { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public CategoryType CategoryType { get; set; }
        public TimeOnly TimeSubmitted { get; set; }

        public int? CourseId { get; set; }
        public  Course? Courses { get; set; }
        public HashSet<ExamQuestion> ExamQuestions { get; set; } = new();
        public HashSet<UserExam> UserExams { get; set; } = new();
        public HashSet<GroupExam> GroupExams { get; set; } = new();
    }
}