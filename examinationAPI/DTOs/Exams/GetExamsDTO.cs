using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.DTOs.Exams
{
    public class GetExamsDTO
    {
        public int ExamId { get; set; }
        public required string Title { get; set;}
    }
}