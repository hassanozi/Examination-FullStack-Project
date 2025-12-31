using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace examinationAPI.Models
{
    public class GroupExam : BaseModel
    {
        public int ExamId { get; set; }
        public Exam Exam { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }
    }

}