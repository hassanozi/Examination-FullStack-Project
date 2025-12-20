using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.ViewModels.Exams
{
    public class GetExamsViewModel
    {
        public int ExamId { get; set; }
        public required string Title { get; set;}
    }
}