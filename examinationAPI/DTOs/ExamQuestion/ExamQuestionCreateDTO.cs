using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.DTOs.ExamQuestion
{
    public class ExamQuestionCreateDTO
    {
        public int ExamId { get; set; }
        public int QuestionId { get; set; }
        public int Points { get; set; }
        public bool IsManadatory { get; set; }
    }
}