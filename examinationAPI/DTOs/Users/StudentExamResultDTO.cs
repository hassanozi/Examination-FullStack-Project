using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.DTOs.StudentExam
{
    public class StudentExamResultDTO
    {
        public int ExamId { get; set; }          // The exam the results belong to
        public int UserId { get; set; }          // The student
        public double StudentScore { get; set; } // The total score the student achieved
        public double TotalScore { get; set; }   // The total possible score for the exam
        public double Percentage { get; set; }   // Optional: calculated percentage
    }

}