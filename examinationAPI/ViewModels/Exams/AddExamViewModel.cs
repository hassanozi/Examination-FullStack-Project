using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using examinationAPI.Models;

namespace examinationAPI.ViewModels.Exams
{
    public class AddExamViewModel
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public ExamType Type { get; set; }
        public TimeOnly Duration { get; set; }
        public short NoOfQuestions { get; set; }
        public short ScorePerQuestion { get; set; }
        public short TotalGrade { get; set; }
        public DateTime Schedule { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public CategoryType CategoryType { get; set; }
        
    }
}