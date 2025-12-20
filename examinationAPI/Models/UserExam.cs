using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class UserExam : BaseModel
    {
        public DateTime? CompletedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public required User User{ get; set; }
        public int ExamId { get; set; } = 0;    
        public required Exam Exam{ get; set; }
    }
}