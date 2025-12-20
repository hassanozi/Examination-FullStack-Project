using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class ExamQuestion : BaseModel
    {
        public int ExamId { get; set; }
        public required Exam Exams { get; set; }

        public int QuestionId { get; set; }
        public required Question Questions { get; set; }

        public required HashSet<Answer> Answers { get; set; }

    }
}