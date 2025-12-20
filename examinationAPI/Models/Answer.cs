using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class Answer : BaseModel
    {
        public double? Score { get; set; }
        public double? TotalScore { get; set; }
        public int UserId { get; set; }
        public required User User{ get; set; }
        public int ExamQuestionId { get; set; }
        public required ExamQuestion ExamQuestion { get; set; }
    }
}